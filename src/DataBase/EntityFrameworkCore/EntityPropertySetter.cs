using System;
using Bubble.Library.DataBase.Interface;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Timing;

namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    /// <summary>
    /// 实体属性设置器
    /// </summary>
    public class EntityPropertySetter : IEntityPropertySetter, ITransientDependency
    {
        private readonly IClock _clock;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clock"></param>
        public EntityPropertySetter(IClock clock) => this._clock = clock;

        /// <summary>
        /// 设置创建属性
        /// </summary>
        /// <param name="targetObject"></param>
        public void SetCreationProperties(object targetObject) => this.SetCreationTime(targetObject);

        /// <summary>
        /// 设置修改属性
        /// </summary>
        /// <param name="targetObject"></param>
        public void SetModificationProperties(object targetObject) => this.SetLastModificationTime(targetObject);

        /// <summary>
        /// 设置删除属性
        /// </summary>
        /// <param name="targetObject"></param>
        public void SetDeletionProperties(object targetObject)
        {
            this.SetLastModificationTime(targetObject);
            this.SetDeletionTime(targetObject);
        }

        private void SetCreationTime(object targetObject)
        {
            if (!(targetObject is IHasCreationTime hasCreationTime) || !(hasCreationTime.CreationTime == new DateTime()))
                return;
            hasCreationTime.CreationTime = this._clock.Now;
        }

        private void SetLastModificationTime(object targetObject)
        {
            if (!(targetObject is IHasModificationTime modificationTime))
                return;
            modificationTime.LastModificationTime = this._clock.Now;
        }

        private void SetDeletionTime(object targetObject)
        {
            if (!(targetObject is IHasDeletionTime hasDeletionTime) || hasDeletionTime.DeletionTime.HasValue)
                return;
            hasDeletionTime.DeletionTime = this._clock.Now;
        }
    }
}
