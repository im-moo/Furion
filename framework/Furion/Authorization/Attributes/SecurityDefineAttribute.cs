﻿// MIT License
//
// Copyright (c) 2020-2023 百小僧, Baiqian Co.,Ltd and Contributors
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

namespace Microsoft.AspNetCore.Authorization;

/// <summary>
/// 安全定义特性
/// </summary>
[SuppressSniffer, AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SecurityDefineAttribute : Attribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public SecurityDefineAttribute()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="resourceId"></param>
    public SecurityDefineAttribute(string resourceId)
    {
        ResourceId = resourceId;
    }

    /// <summary>
    /// 资源Id，必须是唯一的
    /// </summary>
    public string ResourceId { get; set; }
}