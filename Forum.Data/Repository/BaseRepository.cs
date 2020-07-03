using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace Forum.Data.Repository
{
    public abstract class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

    }
}
