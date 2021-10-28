﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.TimeCrontab;

internal interface ICronFilter
{
    /// <summary>
    /// Cron 表达式字段种类
    /// </summary>
    CrontabFieldKind Kind { get; }

    /// <summary>
    /// Checks if the value is accepted by the filter
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>True if the value matches the condition, False if it does not match.</returns>
    bool IsMatch(DateTime value);
}