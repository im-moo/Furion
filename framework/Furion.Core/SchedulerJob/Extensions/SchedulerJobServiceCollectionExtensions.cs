// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.SchedulerJob;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// SchedulerJob 模块服务拓展
/// </summary>
public static class SchedulerJobServiceCollectionExtensions
{
    /// <summary>
    /// 添加 SchedulerJob 模块注册
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="configureOptionsBuilder">调度作业配置选项构建器委托</param>
    /// <returns>服务集合实例</returns>
    public static IServiceCollection AddSchedulerJob(this IServiceCollection services, Action<SchedulerJobOptionsBuilder> configureOptionsBuilder)
    {
        // 创建初始事件总线配置选项构建器
        var schedulerJobOptionsBuilder = new SchedulerJobOptionsBuilder();
        configureOptionsBuilder.Invoke(schedulerJobOptionsBuilder);

        return services.AddSchedulerJob(schedulerJobOptionsBuilder);
    }

    /// <summary>
    /// 添加 SchedulerJob 模块注册
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="schedulerJobOptionsBuilder">调度作业配置选项构建器</param>
    /// <returns>服务集合实例</returns>
    public static IServiceCollection AddSchedulerJob(this IServiceCollection services, SchedulerJobOptionsBuilder? schedulerJobOptionsBuilder = default)
    {
        // 初始化事件总线配置项
        schedulerJobOptionsBuilder ??= new SchedulerJobOptionsBuilder();

        // 注册内部服务
        services.AddInternalService(schedulerJobOptionsBuilder);

        // 构建调度作业服务
        schedulerJobOptionsBuilder.Build(services);

        return services;
    }

    /// <summary>
    /// 注册内部服务
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="schedulerJobOptions">调度作业配置选项</param>
    /// <returns>服务集合实例</returns>
    private static IServiceCollection AddInternalService(this IServiceCollection services, SchedulerJobOptionsBuilder schedulerJobOptions)
    {
        // 注册作业存储器，采用工厂方式创建
        services.AddSingleton<IJobStorer>(_ =>
        {
            // 创建默认基于内存的作业存储器
            return new MemoryJobStorer();
        });

        return services;
    }
}