﻿// MIT License
//
// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd and Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Furion.FriendlyException;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Furion.Schedule;

/// <summary>
/// 作业调度器后台主机服务
/// </summary>
internal sealed class ScheduleHostedService : BackgroundService
{
    /// <summary>
    /// 避免由 CLR 的终结器捕获该异常从而终止应用程序，让所有未觉察异常被觉察
    /// </summary>
    internal event EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException;

    /// <summary>
    /// 作业调度器日志服务
    /// </summary>
    private readonly IScheduleLogger _logger;

    /// <summary>
    /// 作业计划工厂服务
    /// </summary>
    private readonly ISchedulerFactory _schedulerFactory;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="logger">作业调度器日志服务</param>
    /// <param name="schedulerFactory">作业计划工厂服务</param>
    /// <param name="useUtcTimestamp">是否使用 Utc 时间</param>
    public ScheduleHostedService(IServiceProvider serviceProvider
        , IScheduleLogger logger
        , ISchedulerFactory schedulerFactory
        , bool useUtcTimestamp)
    {
        _logger = logger;
        _schedulerFactory = schedulerFactory;

        Monitor = serviceProvider.GetService<IJobMonitor>();
        Executor = serviceProvider.GetService<IJobExecutor>();
        UseUtcTimestamp = useUtcTimestamp;
    }

    /// <summary>
    /// 作业处理程序监视器
    /// </summary>
    private IJobMonitor Monitor { get; }

    /// <summary>
    /// 作业处理程序执行器
    /// </summary>
    private IJobExecutor Executor { get; }

    /// <summary>
    /// 是否使用 UTC 时间
    /// </summary>
    private bool UseUtcTimestamp { get; }

    /// <summary>
    /// 执行后台任务
    /// </summary>
    /// <param name="stoppingToken">后台主机服务停止时取消任务 Token</param>
    /// <returns><see cref="Task"/> 实例</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Schedule Hosted Service is running.");

        // 注册后台主机服务停止监听
        stoppingToken.Register(() =>
           _logger.LogDebug($"Schedule Hosted Service is stopping."));

        // 作业调度器初始化
        _schedulerFactory.Preload();

        // 监听服务是否取消
        while (!stoppingToken.IsCancellationRequested)
        {
            // 执行具体任务
            await BackgroundProcessing(stoppingToken);
        }

        _logger.LogCritical($"Schedule Hosted Service is stopped.");
    }

    /// <summary>
    /// 后台调用处理程序
    /// </summary>
    /// <param name="stoppingToken">后台主机服务停止时取消任务 Token</param>
    /// <returns><see cref="Task"/> 实例</returns>
    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        // 获取当前时间作为检查时间
        var checkTime = Penetrates.GetUnspecifiedNowTime(UseUtcTimestamp);

        // 查找所有符合触发的作业
        var nextRunJobs = _schedulerFactory.GetNextRunJobs(checkTime);

        // 创建一个任务工厂并保证执行任务都使用当前的计划程序
        var taskFactory = new TaskFactory(System.Threading.Tasks.TaskScheduler.Current);

        // 逐条遍历所有作业计划集合
        foreach (var schedulerThatShouldRun in nextRunJobs)
        {
            // 解构参数
            var scheduler = (Scheduler)schedulerThatShouldRun;
            var jobId = scheduler.JobId;
            var jobDetail = scheduler.JobDetail;
            var jobHandler = scheduler.JobHandler;
            var triggersThatShouldRun = scheduler.Triggers;

            // 逐条遍历所有符合触发的作业触发器
            foreach (var triggerThatShouldRun in triggersThatShouldRun)
            {
                // 解构参数
                var (triggerId, trigger) = triggerThatShouldRun;

                // 处理串行执行逻辑（默认并行执行）
                if (CheckIsBlocked(jobDetail, trigger, checkTime)) continue;

                // 设置作业触发器状态为运行状态
                trigger.SetStatus(TriggerStatus.Running);

                // 记录运行信息和计算下一个触发时间
                trigger.Increment(UseUtcTimestamp);

                // 将作业触发器运行数据写入持久化
                _schedulerFactory.Shorthand(jobDetail, trigger);

                // 通过并发执行提高吞吐量并解决 Thread.Sleep 问题
                Parallel.For(0, 1, _ =>
                {
                    // 创建新的线程执行
                    taskFactory.StartNew(async () =>
                    {
                        // 创建作业执行前上下文
                        var jobExecutingContext = new JobExecutingContext(jobDetail, trigger, checkTime)
                        {
                            ExecutingTime = Penetrates.GetNowTime(UseUtcTimestamp)
                        };

                        // 执行异常对象
                        InvalidOperationException executionException = default;

                        try
                        {
                            // 调用执行前监视器
                            if (Monitor != default)
                            {
                                await Monitor.OnExecutingAsync(jobExecutingContext, stoppingToken);
                            }

                            // 判断是否自定义了执行器
                            if (Executor == default)
                            {
                                // 调用作业处理程序并配置出错执行重试
                                await Retry.InvokeAsync(async () =>
                                {
                                    await jobHandler.ExecuteAsync(jobExecutingContext, stoppingToken);
                                }, trigger.NumRetries, trigger.RetryTimeout);
                            }
                            else
                            {
                                await Executor.ExecuteAsync(jobExecutingContext, jobHandler, stoppingToken);
                            }

                            // 设置触发器状态为就绪状态
                            trigger.SetStatus(TriggerStatus.Ready);

                            // 将作业触发器运行数据写入持久化
                            _schedulerFactory.Shorthand(jobDetail, trigger);
                        }
                        catch (Exception ex)
                        {
                            // 记录错误信息，包含错误次数和运行状态
                            trigger.IncrementErrors();

                            // 将作业触发器运行数据写入持久化
                            _schedulerFactory.Shorthand(jobDetail, trigger);

                            // 输出异常日志
                            _logger.LogError(ex, "Error occurred executing {jobId} {triggerId}<{trigger}>.", jobId, triggerId, trigger.ToString());

                            // 标记异常
                            executionException = new InvalidOperationException(string.Format("Error occurred executing {0} {1}<{2}>.", jobId, triggerId, trigger.ToString()), ex);

                            // 捕获 Task 任务异常信息并统计所有异常
                            if (UnobservedTaskException != default)
                            {
                                var args = new UnobservedTaskExceptionEventArgs(
                                    ex as AggregateException ?? new AggregateException(ex));

                                UnobservedTaskException.Invoke(this, args);
                            }
                        }
                        finally
                        {
                            // 标记上一个触发器阻塞已完成
                            if (!jobDetail.Concurrent)
                            {
                                jobDetail.Blocked = false;
                            }

                            // 调用执行后监视器
                            if (Monitor != default)
                            {
                                // 创建作业执行后上下文
                                var jobExecutedContext = new JobExecutedContext(jobDetail, trigger, checkTime)
                                {
                                    ExecutedTime = Penetrates.GetNowTime(UseUtcTimestamp),
                                    Exception = executionException
                                };

                                await Monitor.OnExecutedAsync(jobExecutedContext, stoppingToken);
                            }

                            // 将作业信息运行数据写入持久化
                            _schedulerFactory.Shorthand(jobDetail);
                        }
                    }, stoppingToken);
                });
            }
        }

        // 作业调度器进入休眠状态
        await _schedulerFactory.SleepAsync(stoppingToken);
    }

    /// <summary>
    /// 检查是否是串行执行
    /// </summary>
    /// <param name="jobDetail">作业信息</param>
    /// <param name="trigger">作业触发器</param>
    /// <param name="checkTime">检查时间</param>
    /// <returns>返回 true 是串行执行，则阻塞并进入下一轮，返回 false 则继续执行</returns>
    private bool CheckIsBlocked(JobDetail jobDetail, JobTrigger trigger, DateTime checkTime)
    {
        // 如果是并行执行则跳过
        if (jobDetail.Concurrent) return false;

        // 标记当前作业已经有触发器正在执行
        if (!jobDetail.Blocked)
        {
            jobDetail.Blocked = true;

            // 将作业信息运行数据写入持久化
            _schedulerFactory.Shorthand(jobDetail);

            return false;
        }
        // 标记当前作业的当前触发器【本该执行未执行】
        else
        {
            // 设置触发器状态为阻塞状态
            trigger.SetStatus(TriggerStatus.Blocked);

            // 记录运行信息和计算下一个触发时间
            trigger.Increment(UseUtcTimestamp);

            // 将作业触发器运行数据写入持久化
            _schedulerFactory.Shorthand(jobDetail, trigger);

            // 输出阻塞日志
            _logger.LogWarning("{checkTime}: The <{triggerId}> trigger of job <{jobId}> failed to execute as scheduled due to blocking.", checkTime, trigger.TriggerId, jobDetail.JobId);

            return true;
        }
    }
}