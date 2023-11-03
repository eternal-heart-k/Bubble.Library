using Bubble.Library.DataBase.Interface;
using Bubble.Library.DependencyInjection;
using System;

namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    /// <summary>
    /// 默认的实体属性设置器
    /// </summary>
    public class DefaultEntityPropertySetter : IEntityPropertySetter, ITransientDependency
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static readonly DefaultEntityPropertySetter Instance = new DefaultEntityPropertySetter();

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
            hasCreationTime.CreationTime = DateTime.Now;
        }

        private void SetLastModificationTime(object targetObject)
        {
            if (!(targetObject is IHasModificationTime modificationTime))
                return;
            modificationTime.LastModificationTime = DateTime.Now;
        }

        private void SetDeletionTime(object targetObject)
        {
            if (!(targetObject is IHasDeletionTime hasDeletionTime) || hasDeletionTime.DeletionTime.HasValue)
                return;
            hasDeletionTime.DeletionTime = DateTime.Now;
        }
    }
}
