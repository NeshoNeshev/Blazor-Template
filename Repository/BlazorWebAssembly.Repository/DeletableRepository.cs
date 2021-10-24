using BlazorWebAssembly.Data;
using BlazorWebAssembly.Data.Models.DeletableModels.Interfaces;
using BlazorWebAssembly.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlazorWebAssembly.Repository
{
    public class DeletableRepository<TEntity> : Repository<TEntity>, IDeletableRepository<TEntity>
        where TEntity : class, IDeletable
    {
        public DeletableRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);

        public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void UnDelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            this.Update(entity);
        }
    }
}
