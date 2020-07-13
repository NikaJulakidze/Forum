using Forum.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Data.Repository
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(ApplicationDbContext context):base(context)
        {

        }
        public List<Tag> GetTagsByNames(List<string> tagNames)
        {
            var tags = new List<Tag>();
            foreach(var i in tagNames)
            {
                foreach(var item in _entity)
                {
                    if (i == item.Title)
                    {
                        tags.Add(item);
                    }
                }
            }
            return tags;
        }
    }
}
