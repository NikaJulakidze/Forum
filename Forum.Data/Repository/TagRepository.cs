using Forum.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Forum.Data.Repository
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(ApplicationDbContext context):base(context)
        {

        }
        public IEnumerable<Tag> GetTagsByNames(List<string> tagNames)
        {
            var names = (_entities.SelectMany(i => tagNames.Where(item => i.Title == item).Select(item => i))).ToList();
            return names;
        }
    }
}
