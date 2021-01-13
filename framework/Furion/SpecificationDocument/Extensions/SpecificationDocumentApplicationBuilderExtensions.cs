﻿using Furion;
using Furion.DependencyInjection;
using Furion.SpecificationDocument;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// 规范化文档中间件拓展
    /// </summary>
    [SkipScan]
    public static class SpecificationDocumentApplicationBuilderExtensions
    {
        /// <summary>
        /// 添加规范化文档中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="routePrefix"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSpecificationDocuments(this IApplicationBuilder app, string routePrefix = default)
        {
            // 判断是否启用规范化文档
            if (App.Settings.InjectSpecificationDocument != true) return app;

            // 配置 Swagger 全局参数
            app.UseSwagger(options => SpecificationDocumentBuilder.Build(options));

            // 配置 Swagger UI 参数
            app.UseSwaggerUI(options => SpecificationDocumentBuilder.BuildUI(options, routePrefix));

            return app;
        }
    }
}