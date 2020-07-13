using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);
        Task<TEntity> GetByIdAsync<T>(T id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}