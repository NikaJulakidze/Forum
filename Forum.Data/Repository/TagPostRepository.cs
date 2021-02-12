using Forum.Data.Entities;
using System.Collections.Generic;

namespace Forum.Data.Repository
{
    public class TagPostRepository:ITagPostRepository
    {
        private readonly ApplicationDbContext _context;

        public TagPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public void AddRange(List<TagPost> tagQuestions)
        {
            _context.AddRange(tagQuestions);
        }

        public void BulkDelete(params Tag[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void BulkInsert(params Tag[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void BulkUpdate(params Tag[] entities)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Tag entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
