using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Bubble.Library.LibraryBuilder
{
    /// <summary>
    /// 项目构建的其他配置
    /// </summary>
    public class LibraryBuilderConfiguration
    {
        /// <summary>
        /// Apollo配置
        /// </summary>
        public Action<WebApplicationBuilder> ApolloConfiguration { get; set; }

        /// <summary>
        /// 数据库配置
        /// </summary>
        public Action<IServiceCollection> DbContextConfiguration { get; set; }

        /// <summary>
        /// Redis缓存配置
        /// </summary>
        public Action<IServiceCollection> RedisConfiguration { get; set; }

        /// <summary>
        /// 跨域策略配置
        /// </summary>
        public Action<IServiceCollection> CorsPolicyConfiguration { get; set; }

        /// <summary>
        /// 跨域策略配置名称
        /// </summary>
        public string CorsPolicyName { get; set; }

        /// <summary>
        /// 是否使用AutoMapper
        /// </summary>
        public bool UseAutoMapper { get; set; } = true;

        /// <summary>
        /// 接口路由是否使用小写形式
        /// </summary>
        public bool UseLowerCaseUrls { get; set; } = true;
    }
}
