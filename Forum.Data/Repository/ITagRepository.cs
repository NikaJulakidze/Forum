using Forum.Data.Entities;
using Forum.Models.Filters;
using Forum.Models.Tag;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<(List<TagListingModel>, int)> GetTags(BaseFilterModel filterModel);
        List<Tag> GetTagsByNames(List<string> tagNames);
        Task<List<Tag>> GetTagsByQuestionId(int quetionId);
    }
}