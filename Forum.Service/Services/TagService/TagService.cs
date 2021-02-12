using CommonModels.Paging;
using Forum.Data.Repository;
using Forum.Models.Filters;
using Forum.Models.NewFolder;
using Forum.Models.Tag;
using Forum.Service.Uri;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Forum.Service.Services.TagService
{
    public class TagService:ITagService
    {
        private readonly AppSettings _options;
        private readonly IUriService _uriService;
        private readonly ITagRepository _tagRepository;

        public TagService(IOptionsSnapshot<AppSettings> options,IUriService uriService,ITagRepository tagRepository)
        {
            _options = options.Value;
            _uriService = uriService;
            _tagRepository = tagRepository;
        }

        public async Task<PagedResult<TagListingModel>> GetPagedTags(BaseFilterModel filterModel,string route)
        {
            //filterModel.PageSize = int.Parse(_options.PagingSettings.PerPage);
            var result = await _tagRepository.GetTags(filterModel);
            var pagedResult = Helpers.PagingHelper.CreatePagedReponse(result.Item1, filterModel, result.Item2, _uriService, route);
            return pagedResult;
        }
    }
}
