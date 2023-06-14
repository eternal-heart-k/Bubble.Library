using System;

namespace Bubble.Library.DataBase.Entities
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        protected Entity()
        {
        }

        protected Entity(TKey id) => this.Id = id;
    }
}
