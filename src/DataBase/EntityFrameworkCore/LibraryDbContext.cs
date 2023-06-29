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
    /// <summary>
    /// 重写数据库上下文
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class LibraryDbContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        /// <summary>
        /// 属性设置器
        /// </summary>
        public IEntityPropertySetter EntityPropertySetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected LibraryDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
            IServiceProvider applicationServiceProvider = options.FindExtension<CoreOptionsExtension>()?.ApplicationServiceProvider;
            this.EntityPropertySetter = applicationServiceProvider?.GetService<IEntityPropertySetter>() ?? DefaultEntityPropertySetter.Instance;
        }

        /// <summary>
        /// 重写OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.ConfigureIsDeletedQueryFilter(modelBuilder);
        }

        /// <summary>
        /// 重写SaveChanges
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            this.ApplyStateChange();
            return base.SaveChanges();
        }

        /// <summary>
        /// 重写SaveChangesAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyStateChange();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 改变状态
        /// </summary>
        protected virtual void ApplyStateChange()
        {
            foreach (var entry in ChangeTracker.Entries())
                this.ApplyStateChange(entry);
        }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="entry"></param>
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

        /// <summary>
        /// 添加实体状态更改
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void ApplyStateChangeForAddedEntity(EntityEntry entry) => this.SetCreationProperties(entry);

        /// <summary>
        /// 修改实体状态更改
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void ApplyStateChangeForModifiedEntity(EntityEntry entry)
        {
            this.SetModificationProperties(entry);
            if (!(entry.Entity is ISoftDelete) || !((ISoftDelete)entry.Entity).IsDeleted)
                return;
            this.SetDeletionProperties(entry);
        }

        /// <summary>
        /// 删除实体状态更改
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void ApplyStateChangeForDeletedEntity(EntityEntry entry)
        {
            this.CancelDeletionForSoftDelete(entry);
            this.SetDeletionProperties(entry);
        }

        /// <summary>
        /// 设置创建属性
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void SetCreationProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetCreationProperties(entry);

        /// <summary>
        /// 设置修改属性
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void SetModificationProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetModificationProperties(entry);

        /// <summary>
        /// 设置删除属性
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void SetDeletionProperties(EntityEntry entry) =>
            this.EntityPropertySetter.SetDeletionProperties(entry);

        /// <summary>
        /// 更改为软删除
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
                return;
            entry.Reload();
            entry.State = EntityState.Modified;
            ((ISoftDelete)entry.Entity).IsDeleted = true;
        }

        /// <summary>
        /// IsDeleted查询过滤
        /// </summary>
        /// <param name="modelBuilder"></param>
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
