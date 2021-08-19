﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             http://license.coscl.org.cn/MulanPSL2
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.DependencyInjection;

/// <summary>
/// 不被扫描和发现的特性
/// </summary>
/// <remarks>用于程序集扫描类型或方法时候</remarks>
[SuppressSniffer, AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Enum | AttributeTargets.Struct)]
public class SuppressSnifferAttribute : Attribute
{
}
