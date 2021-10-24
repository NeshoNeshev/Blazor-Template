using BlazorWebAssembly.Data.Models.DeletableModels.Interfaces;
using System.Linq;

namespace BlazorWebAssembly.Repository.Interfaces
{
    public interface IDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletable
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void UnDelete(TEntity entity);
    }
}
