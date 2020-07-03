using Forum.Data.Entities;
using System.Collections.Generic;

namespace Forum.Data.Repository
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        IEnumerable<Tag> GetTagsByNames(List<string> tagNames);
    }
}