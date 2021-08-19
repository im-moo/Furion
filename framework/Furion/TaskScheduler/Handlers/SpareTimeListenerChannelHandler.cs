﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             http://license.coscl.org.cn/MulanPSL2
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.IPCChannel;

namespace Furion.TaskScheduler;

/// <summary>
/// 定时器监听管道处理程序
/// </summary>
internal sealed class SpareTimeListenerChannelHandler : ChannelHandler<SpareTimerExecuter>
{
    /// <summary>
    /// 触发程序
    /// </summary>
    /// <param name="executer"></param>
    /// <returns></returns>
    public async override Task InvokeAsync(SpareTimerExecuter executer)
    {
        var spareTimeListener = App.GetService<ISpareTimeListener>(App.RootServices);
        if (spareTimeListener == null) return;

        await spareTimeListener.OnListener(executer);
    }
}
