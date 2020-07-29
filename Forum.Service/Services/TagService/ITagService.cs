using Forum.Models.Filters;
using Forum.Models.Paging;
using Forum.Models.Tag;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.TagService
{
    public interface ITagService
    {
        Task<PagedResult<TagListingModel>> GetPagedTags(BaseFilterModel filterModel,string route);
    }
}
