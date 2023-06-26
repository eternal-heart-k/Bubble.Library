namespace Bubble.Library.DataBase.Entities
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// 定义一个实体主键为Id
        /// </summary>
        TKey Id { get; }
    }
}
