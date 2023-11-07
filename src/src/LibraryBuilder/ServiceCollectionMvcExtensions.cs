using Bubble.Library.Foundation.Filter;
using Microsoft.Extensions.DependencyInjection;

namespace Bubble.Library.LibraryBuilder
{
    public static class ServiceCollectionMvcExtensions
    {
        public static IServiceCollection AddMvcOptions(this IServiceCollection service)
        {
            var mvcBuilder = service.AddControllers();

            mvcBuilder.AddMvcOptions(options =>
            {
                options.Filters.Add<ApiResultAttachFilter>();
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<RequestContextFilter>(16);
            });

            mvcBuilder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition =
                    System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            return service;
        }
    }
}
