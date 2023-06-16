[中](https://gitee.com/dotnetchina/Furion) | **En** | Commercial use is allowed, generous [sponsorship](http://furion.baiqian.ltd/docs/donate)

# Furion

An application framework that you can integrate into any .NET/C# application.

## Installation

```powershell
dotnet add package Furion
```

## Examples

We have several examples [on the website](http://furion.baiqian.ltd). Here is the first one to get you started:

```cs
Serve.Run();

[DynamicApiController]
public class HelloService
{
    public string Say() => "Hello, Furion";
}
```

Open browser access `http://localhost:5000`.

## Documentation

You can find the [Furion](https://gitee.com/dotnetchina/Furion) documentation [on the website](http://furion.baiqian.ltd).

## Contributing

The main purpose of this repository is to continue evolving [Furion](https://gitee.com/dotnetchina/Furion) core, making it faster and easier to use. Development of [Furion](https://gitee.com/dotnetchina/Furion) happens in the open on [Gitee](https://gitee.com/dotnetchina/Furion), and we are grateful to the community for contributing bugfixes and improvements.

Read [contribution documents](http://furion.baiqian.ltd/docs/contribute) to learn how you can take part in improving [Furion](https://gitee.com/dotnetchina/Furion).

## Subscribe

Open WeChat and scan the QR code to follow the Furion official account and subscribe to the latest information.

![微信公众号](https://gitee.com/dotnetchina/Furion/raw/v4/handbook/static/img/weixin_qrcode.jpg)

## License

[Furion](https://gitee.com/dotnetchina/Furion) uses the [MIT](https://gitee.com/dotnetchina/Furion/blob/v4/LICENSE) open source license.
