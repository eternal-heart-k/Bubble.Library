using Autofac.Extensions.DependencyInjection;
using Autofac;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Foundation.Constant;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Bubble.Library.LibraryBuilder
{
    public static class HostBuilderConfiguration
    {
        public static IHostBuilder Configuration(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging((hostingContext, builder) =>
            {
                var env = hostingContext.HostingEnvironment;
                if (!env.IsEnvironment(Constants.Environment.Production))
                {
                    builder.AddConsole();
                    builder.AddDebug();
                }
                builder.AddEventSourceLogger();
            });

            hostBuilder.ConfigureServices((_, services) =>
            {
                services.AddOptions();

                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders =
                        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                    options.KnownProxies.Clear();
                    options.KnownNetworks.Clear();
                });
            });

            hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            hostBuilder.ConfigureContainer<ContainerBuilder>(b => { b.RegisterModule<DependencyModule>(); });

            return hostBuilder;
        }
    }
}
