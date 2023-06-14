namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    public interface IEntityPropertySetter
    {
        void SetCreationProperties(object targetObject);

        void SetModificationProperties(object targetObject);

        void SetDeletionProperties(object targetObject);
    }
}
