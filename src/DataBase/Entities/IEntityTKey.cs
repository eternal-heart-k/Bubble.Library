namespace Bubble.Library.DataBase.Entities
{
    /// <summary>
    /// 定义一个实体主键为Id
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
