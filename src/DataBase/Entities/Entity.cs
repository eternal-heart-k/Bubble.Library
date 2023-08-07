using System;

namespace Bubble.Library.DataBase.Entities
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public abstract class Entity : Entity<int>
    {
    }

    /// <summary>
    /// 实体泛型类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        protected Entity(TKey id)
        {
            Id = id;
        }
    }
}
