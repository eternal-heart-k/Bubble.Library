using Bubble.Library.DataBase.Interface;
using Bubble.Library.DependencyInjection;
using System;

namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    public class DefaultEntityPropertySetter : IEntityPropertySetter, ITransientDependency
    {
        public static readonly DefaultEntityPropertySetter Instance = new DefaultEntityPropertySetter();

        public void SetCreationProperties(object targetObject) => this.SetCreationTime(targetObject);

        public void SetModificationProperties(object targetObject) => this.SetLastModificationTime(targetObject);

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
