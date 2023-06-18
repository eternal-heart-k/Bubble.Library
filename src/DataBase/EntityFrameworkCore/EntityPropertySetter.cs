using System;
using Bubble.Library.DataBase.Interface;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Timing;

namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    public class EntityPropertySetter : IEntityPropertySetter, ITransientDependency
    {
        private readonly IClock _clock;

        public EntityPropertySetter(IClock clock) => this._clock = clock;

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
