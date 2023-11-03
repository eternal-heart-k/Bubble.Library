using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bubble.Library.DependencyInjection
{
    /// <summary>
    /// 注册生命周期
    /// </summary>
    public static class RegisterLifeCycle
    {
        /// <summary>
        /// program中调用来自动注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.RegisterLifeCycleByInherit(typeof(ISingletonDependency));
            services.RegisterLifeCycleByInherit(typeof(IScopeDependency));
            services.RegisterLifeCycleByInherit(typeof(ITransientDependency));
        }

        private static void RegisterLifeCycleByInherit(this IServiceCollection services, Type lifeCycleType)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var types = Directory.GetFiles(path, "*.dll")
                .Select(Assembly.LoadFrom)
                .SelectMany(x => x.GetTypes())
                .Where(t => lifeCycleType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();
            foreach (var type in types)
            {
                type.GetInterfaces().ToList().ForEach(r =>
                {
                    if (lifeCycleType == typeof(ISingletonDependency)) services.AddSingleton(r, type);
                    else if (lifeCycleType == typeof(IScopeDependency)) services.AddScoped(r, type);
                    else if (lifeCycleType == typeof(ITransientDependency)) services.AddTransient(r, type);
                });
            }
        }
    }
}
