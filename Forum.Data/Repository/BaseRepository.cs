using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entity;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public void BulkUpdate(params TEntity[] entities)
        {
            _entity.UpdateRange(entities);
        }

        public void BulkInsert(params TEntity[] entities)
        {
            _entity.AddRange(entities);
        }

        public void BulkDelete(params TEntity[] entities)
        {
            _entity.RemoveRange(entities);
        }

        public virtual async Task<TEntity> GetByIdAsync<T>(T id)
        {
           return await _entity.FindAsync(id);
        }
    }
}
