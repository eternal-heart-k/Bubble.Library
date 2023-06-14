using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Bubble.Library.DataBase.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


namespace Bubble.Library.DataBase.EntityFrameworkCore
{
    public abstract class LibraryDbContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        public IEntityPropertySetter EntityPropertySetter { get; set; }

        protected LibraryDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
            IServiceProvider applicationServiceProvider = options.FindExtension<CoreOptionsExtension>()?.ApplicationServiceProvider;
            this.EntityPropertySetter = applicationServiceProvider?.GetService<IEntityPropertySetter>() ?? DefaultEntityPropertySetter.Instance;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.ConfigureIsDeletedQueryFilter(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ApplyStateChange();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyStateChange();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void ApplyStateChange()
        {
            foreach (var entry in ChangeTracker.Entries())
                this.ApplyStateChange(entry);
        }

        protected virtual void ApplyStateChange(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    this.ApplyStateChangeForAddedEntity(entry);
                    break;
                case EntityState.Modified:
                    this.ApplyStateChangeForModifiedEntity(entry);
                    break;
                case EntityState.Deleted:
                    this.ApplyStateChangeForDeletedEntity(entry);
                    break;
            }
        }

        protected virtual void ApplyStateChangeForAddedEntity(EntityEntry entry) => this.SetCreationProperties(entry);

        protected virtual void ApplyStateChangeForModifiedEntity(EntityEntry entry)
        {
            this.SetModificationProperties(entry);
            if (!(entry.Entity is ISoftDelete) || !((ISoftDelete)entry.Entity).IsDeleted)
                return;
            this.SetDeletionProperties(entry);
        }

        protected virtual void ApplyStateChangeForDeletedEntity(EntityEntry entry)
        {
            this.CancelDeletionForSoftDelete(entry);
            this.SetDeletionProperties(entry);
        }

        protected virtual void SetCreationProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetCreationProperties(entry);

        protected virtual void SetModificationProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetModificationProperties(entry);

        protected virtual void SetDeletionProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetDeletionProperties(entry);

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
                return;
            entry.Reload();
            entry.State = EntityState.Modified;
            ((ISoftDelete)entry.Entity).IsDeleted = true;
        }

        protected virtual void ConfigureIsDeletedQueryFilter(ModelBuilder modelBuilder)
        {
            Expression<Func<ISoftDelete, bool>> expression = e => !EF.Property<bool>(e, "IsDeleted");
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => typeof(ISoftDelete).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(expression);
            }
        }
    }
}
