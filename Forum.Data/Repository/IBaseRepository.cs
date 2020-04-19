using System.Linq;

namespace Forum.Data.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}