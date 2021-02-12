using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);
        void BulkDelete(params TEntity[] entities);
        void BulkInsert(params TEntity[] entities);
        void BulkUpdate(params TEntity[] entities);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}