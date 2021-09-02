﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.Options;

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
public interface IAppOptions<TOptions> : IAppOptions
    where TOptions : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    void PostConfigure(TOptions options);
}

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
/// <typeparam name="TDep"></typeparam>
public interface IAppOptions<TOptions, TDep> : IAppOptions
    where TOptions : class
    where TDep : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    /// <param name="dep"></param>
    void PostConfigure(TOptions options, TDep dep);
}

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
/// <typeparam name="TDep1"></typeparam>
/// <typeparam name="TDep2"></typeparam>
public interface IAppOptions<TOptions, TDep1, TDep2> : IAppOptions
    where TOptions : class
    where TDep1 : class
    where TDep2 : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    /// <param name="dep1"></param>
    /// <param name="dep2"></param>
    void PostConfigure(TOptions options, TDep1 dep1, TDep2 dep2);
}

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
/// <typeparam name="TDep1"></typeparam>
/// <typeparam name="TDep2"></typeparam>
/// <typeparam name="TDep3"></typeparam>
public interface IAppOptions<TOptions, TDep1, TDep2, TDep3> : IAppOptions
    where TOptions : class
    where TDep1 : class
    where TDep2 : class
    where TDep3 : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    /// <param name="dep1"></param>
    /// <param name="dep2"></param>
    /// <param name="dep3"></param>
    void PostConfigure(TOptions options, TDep1 dep1, TDep2 dep2, TDep3 dep3);
}

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
/// <typeparam name="TDep1"></typeparam>
/// <typeparam name="TDep2"></typeparam>
/// <typeparam name="TDep3"></typeparam>
/// <typeparam name="TDep4"></typeparam>
public interface IAppOptions<TOptions, TDep1, TDep2, TDep3, TDep4> : IAppOptions
    where TOptions : class
    where TDep1 : class
    where TDep2 : class
    where TDep3 : class
    where TDep4 : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    /// <param name="dep1"></param>
    /// <param name="dep2"></param>
    /// <param name="dep3"></param>
    /// <param name="dep4"></param>
    void PostConfigure(TOptions options, TDep1 dep1, TDep2 dep2, TDep3 dep3, TDep4 dep4);
}

/// <summary>
/// 选项依赖接口
/// </summary>
/// <typeparam name="TOptions"></typeparam>
/// <typeparam name="TDep1"></typeparam>
/// <typeparam name="TDep2"></typeparam>
/// <typeparam name="TDep3"></typeparam>
/// <typeparam name="TDep4"></typeparam>
/// <typeparam name="TDep5"></typeparam>
public interface IAppOptions<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> : IAppOptions
    where TOptions : class
    where TDep1 : class
    where TDep2 : class
    where TDep3 : class
    where TDep4 : class
    where TDep5 : class
{
    /// <summary>
    /// 后置配置
    /// </summary>
    /// <param name="options"></param>
    /// <param name="dep1"></param>
    /// <param name="dep2"></param>
    /// <param name="dep3"></param>
    /// <param name="dep4"></param>
    /// <param name="dep5"></param>
    void PostConfigure(TOptions options, TDep1 dep1, TDep2 dep2, TDep3 dep3, TDep4 dep4, TDep5 dep5);
}

/// <summary>
/// 选项依赖接口根接口
/// </summary>
public interface IAppOptions
{
}