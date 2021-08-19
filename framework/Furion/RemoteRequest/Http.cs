// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             http://license.coscl.org.cn/MulanPSL2
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.DependencyInjection;

namespace Furion.RemoteRequest;

/// <summary>
/// 远程请求静态类
/// </summary>
[SuppressSniffer]
public static class Http
{
    /// <summary>
    /// 获取远程请求代理
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns>IHttpDispatchProxy</returns>
    public static THttpDispatchProxy GetRemoteRequestProxy<THttpDispatchProxy>(IServiceProvider serviceProvider = default)
        where THttpDispatchProxy : class, IHttpDispatchProxy
    {
        return App.GetService<THttpDispatchProxy>(serviceProvider);
    }
}
