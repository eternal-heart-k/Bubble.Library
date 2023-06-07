namespace Bubble.Library.DependencyInjection
{
    /// <summary>
    /// 生命周期为每一次请求创建一个实例，同作用域下是单例
    /// </summary>
    public interface IScopeDependency : IDependency
    {
    }
}
