using CommonModels.Paging;
using Forum.Models.Filters;
using Forum.Models.Tag;
using System.Threading.Tasks;

namespace Forum.Service.Services.TagService
{
    public interface ITagService
    {
        Task<PagedResult<TagListingModel>> GetPagedTags(BaseFilterModel filterModel,string route);
    }
}
