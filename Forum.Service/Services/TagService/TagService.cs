using Forum.Data.Uow;
using Forum.Models.Filters;
using Forum.Models.NewFolder;
using Forum.Models.Paging;
using Forum.Models.Tag;
using Forum.Service.Uri;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Forum.Service.Services.TagService
{
    public class TagService:ITagService
    {
        private readonly ITagUow _tagUow;
        private readonly AppSettings _options;
        private readonly IUriService _uriService;

        public TagService(ITagUow tagUow,IOptionsSnapshot<AppSettings> options,IUriService uriService)
        {
            _tagUow = tagUow;
            _options = options.Value;
            _uriService = uriService;
        }

        public async Task<PagedResult<TagListingModel>> GetPagedTags(BaseFilterModel filterModel,string route)
        {
            filterModel.PageSize = int.Parse(_options.PagingSettings.PerPage);
            var result = await _tagUow.TagRepository.GetTags(filterModel);
            var pagedResult = Helpers.PagingHelper.CreatePagedReponse(result.Item1, filterModel, result.Item2, _uriService, route);
            return pagedResult;
        }
    }
}
