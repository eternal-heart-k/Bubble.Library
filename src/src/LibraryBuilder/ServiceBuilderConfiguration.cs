using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bubble.Library.LibraryBuilder
{
    public static class ServiceBuilderConfiguration
    {
        public static IServiceCollection Configuration(this IServiceCollection services, LibraryBuilderConfiguration libraryBuilderConfiguration)
        {
            services.AddMvcOptions();

            services.AddLibrarySwagger();

            if (libraryBuilderConfiguration.DbContextConfiguration is not null) 
                libraryBuilderConfiguration.DbContextConfiguration(services);

            if (libraryBuilderConfiguration.RedisConfiguration is not null)
                libraryBuilderConfiguration.RedisConfiguration(services);

            if (libraryBuilderConfiguration.CorsPolicyConfiguration is not null)
                libraryBuilderConfiguration.CorsPolicyConfiguration(services);

            if (libraryBuilderConfiguration.UseAutoMapper)
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            if (libraryBuilderConfiguration.UseLowerCaseUrls)
                services.AddRouting(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
