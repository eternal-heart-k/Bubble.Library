using Bubble.Library.Foundation.Filter;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Bubble.Library.LibraryBuilder
{
    public static class ServiceCollectionSwaggerExtensions
    {
        public static IServiceCollection AddLibrarySwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<AdditionOperationFilter>();
                options.OperationFilter<ModifySwaggerEntityOperationFilter>();

                options.CustomSchemaIds(x => x.FullName);

                foreach (var xmlFile in Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.xml"))
                {
                    options.IncludeXmlComments(xmlFile, true);
                }
            });
            
            services.Configure<SwaggerUIOptions>(options =>
            {
                options.EnableDeepLinking(); // 启用深层次的Swagger文档
                options.DocExpansion(DocExpansion.None); // 默认不打开api
                options.DisplayRequestDuration(); // 展示执行时间ms
                options.EnableTryItOutByDefault(); // 显示try it out
            });

            services.Configure<SwaggerGeneratorOptions>(opt =>
            {
                opt.SortKeySelector = a => (a.ActionDescriptor as ControllerActionDescriptor).ControllerName[0].ToString();
            });

            return services;
        }
    }
}
