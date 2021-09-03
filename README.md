# Furion 实验版

🎉 实现彻彻底底无第三方依赖的 Furion 版本。

- 作者：[百小僧](https://gitee.com/monksoul)
- 日期：2021 年 08 月 30 日

## 开发规范

- 采用一切为了依赖注入的设计模式
- 尽可能避免静态类和静态属性定义
- 尽可能保证方法原子性、职责单一性
- 所有 `private` 字段须以 `_` 开头且采用 `小驼峰命名`
- 所有类名、接口须采用 `大驼峰命名`，类型名采用 `名词` 拼接，接口须以 `I` 开头
- 如果类不考虑被继承，设置为 `sealed` 私有类，同时尽可能添加 `partial` 修饰符
- 如果类只是用来标记某个领域的属性，应采用 `结构` 定义
- 所有能够在类构造函数初始化的字典都必须采用 `private readonly` 修饰
- 如果类的属性无需外部赋值设置，应设置为 `{get;}` 或 `{get; internal set;}`
- 所有事件类须以 `EventArgs` 结尾
- 所有特性类须以 `Attribute` 结尾，且明确指定 `AttributeUsage` 特性
- 所有类型拓展类必须以 `{类型}Extensions.cs` 命名，且命名空间均遵循 `Furion.模块.Extensions` 格式，泛型类遵循 `{类型}OfTExtensions.cs` 命名
- 框架内部所有 `Helper` 拓展类及方法都应该是 `internal` 修饰
- `IServiceCollection` 拓展方法须以 `Add` 开头
- `IApplicationBuilder` 拓展方法须以 `Use` 开头
- 对 `.NET` 的拓展尽可能保持和原生一样的命名空间
- 所有中间件须以 `Middleware` 结尾
- 所有筛选器须以 `Filter` 或 `AsyncFilter` 结尾
- 框架内部默认实现须以 `App` 开头
- 所有私有的方法禁止定义为拓展方法
- 所有选项类须以 `SettingsOptions` 结尾
- 尽可能在方法第一行判断参数空，统一采用 `if (parameter == null) throw new ArgumentNullException(nameof(parameter));`
- 框架内部主动抛出内部异常均采用 `throw new InvalidOperationException($"消息.");` 方式
- 框架尽可能在需要输出和调试地方使用 `Trace.WriteLine(消息);` 输出
- 所有三元表达式代码须以 `?` 和 `:` 之前换行
- 进行多条件 `||` 或 `&&` 判断时，每个组须之前换行
- 所有 `Lambda` 操作代码，如果操作方法大于 `1` 个，须在每一个 `.Lambada<>` 之前换行
- 构造函数如果定义超过一个参数，则在第二个开始换行，且以 `,` 开头
- 框架内部尽可能保证模块零依赖性，除了公共 `Helpers`
- 框架内所有的类、属性、方法、接口、事件、字段等成员必须采用 `///` 注释
- 方法内的代码尽可能一组逻辑空一行且添加组注释，采用代码上行 `//` 注释
- 框架内每个文件头部须添加开源协议描述头
- `///` 注释尽可能简单命令，如需更多说明，须在 `<remarks></remarks>` 中编写，如果需要多行，采用 `<para></para>` 或 `<code>/</code>`
- 框架中所有非服务类如果实现某接口方法，须采用 `显式实现`，避免外部调用
- 所有测试方法须以 `Test` 开头，同时建议采用 `[Theory]`，而不是 `[Fact]`

## 状态

我们创建了一个详细的列表来轻松显示 Furion 实验版本的状态和演变。

| 图标 | 描述     |
| ---- | -------- |
| ⚠️   | 待定     |
| ⏳   | 进行中   |
| ✅   | 完成     |
| 💔   | 随时抛弃 |

## 概述

要跟踪正在进行的进度，请过滤处理程序标签。

### 配置 / Configuration

| 功能                                                        | 状态 |
| ----------------------------------------------------------- | ---- |
| 支持添加 `.json;.xml;.ini;` 配置文件                        | ✅   |
| 支持 `AppSettings:CustomizeConfigurationFiles` 节点添加配置 | ✅   |
| 支持系统环境配置（可复写配置文件内容）                      | ✅   |
| 支持系统环境配置前缀符设置                                  | ✅   |
| 支持命令行启动配置                                          | ✅   |
| 支持内存配置                                                | ✅   |
| 支持 `Key-per-file` 模式配置                                | ✅   |
| 支持不同系统环境切换配置文件                                | ✅   |
| 支持后期配置文件添加（物理文件不存在）                      | ✅   |
| 支持配置文件更改通知（热更新）                              | ✅   |
| 支持特定通配符配置文件路径，`@!~.&/`                        | ✅   |
| 支持配置读取单个值、对象、数组、字典、枚举                  | ✅   |
| 支持判断配置节点是否存在                                    | ✅   |
| 支持自定义配置提供程序                                      | ✅   |
| 内置 `EFCore` 默认配置提供程序                              | ⚠️   |
| 支持在主机启动、任何可解析 `IConfiguration` 地方读取        | ✅   |
| 支持不同编码正确读取，如中文（另存文件编码为 UTF-8）        | ✅   |
| 配置集成测试                                                | ✅   |
| 配置使用文档                                                | ⚠️   |
| 配置使用例子                                                | ⚠️   |

### 选项 / Options

| 功能                                                          | 状态 |
| ------------------------------------------------------------- | ---- |
| 支持选项配置功能                                              | ✅   |
| 支持公开类（选项）和节点绑定                                  | ✅   |
| 支持选项属性特性验证（类型、必填、或溢出配置）                | ✅   |
| 支持选项属性 `IValidateOptions<TOptions>` 复杂验证（多个）    | ✅   |
| 支持选项后期配置（且支持最多 5 个依赖服务注入）               | ✅   |
| 支持特性配置选项节点及 `IValidateOptions<TOptions>` 验证类型  | ✅   |
| 支持实现 `IAppOptions<TOptions,[TDep1..5]>` 接口方式配置      | ✅   |
| 支持选项 `IOptions/IOptionsSnapshot/IOptionsMonitor` 接口读取 | ✅   |
| 选项集成测试                                                  | ✅   |
| 选项使用文档                                                  | ⚠️   |
| 选项使用例子                                                  | ⚠️   |

### 依赖注入 / Dependency Injection

| 功能                                                                           | 状态 |
| ------------------------------------------------------------------------------ | ---- |
| 替换 .NET 内置服务提供器工厂、并兼容 .NET 原生所有功能                         | ✅   |
| 支持单例、作用域、瞬时生存周期注册                                             | ✅   |
| 支持构造函数注入                                                               | ✅   |
| 支持函数参数 `[FromServices]` 注入                                             | ✅   |
| 支持属性 `[AutowiredServices]` 注入                                            | ✅   |
| 支持包装 `.NET` 原生 `IServiceCollection` 和 `IServiceProvider` 对象           | ✅   |
| 支持依赖接口解析生存周期接口并注册                                             | ✅   |
| 支持配置外部程序集扫描注册                                                     | ✅   |
| 支持泛型注入                                                                   | ✅   |
| 支持多实现注入                                                                 | ✅   |
| 支持 `INamedServiceProvider`、`IAppServiceProvider` 服务提供器，解析多服务实例 | ✅   |
| 支持 `AOP` 切面拦截                                                            | ⚠️   |
| 依赖注入集成测试                                                               | ✅   |
| 依赖注入使用文档                                                               | ⚠️   |
| 依赖注入使用例子                                                               | ⚠️   |

### 模块 / Module

| 功能                                                         | 状态 |
| ------------------------------------------------------------ | ---- |
| 支持特性配置                                                 | ⚠️   |
| 支持 `ConfigureServices` 和 `Configure` 分割、合并、依赖排序 | ⚠️   |
| 支持扫描程序集自动调用                                       | ⚠️   |
