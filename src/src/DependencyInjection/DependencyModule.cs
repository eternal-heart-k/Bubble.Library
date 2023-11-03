using Autofac;
using System;
using System.Reflection;

namespace Bubble.Library.DependencyInjection
{
    /// <summary>
    /// Autofac依赖注入模块
    /// </summary>
    public class DependencyModule : Autofac.Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            //每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
            var transientDependency = typeof(ITransientDependency);
            builder.RegisterAssemblyTypes(currentAssemblies)
                .Where(t => transientDependency.GetTypeInfo().IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsGenericType)
                .AsImplementedInterfaces().InstancePerDependency();

            //同一个Lifetime生成的对象是同一个实例
            var scopeDependency = typeof(IScopeDependency);
            builder.RegisterAssemblyTypes(currentAssemblies)
                .Where(t => scopeDependency.GetTypeInfo().IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsGenericType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            //单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象；
            var singletonDependency = typeof(ISingletonDependency);
            builder.RegisterAssemblyTypes(currentAssemblies)
                .Where(t => singletonDependency.GetTypeInfo().IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsGenericType)
                .AsImplementedInterfaces().SingleInstance();

        }
    }
}
