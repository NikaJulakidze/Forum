using Forum.Api.Attributes;
using Forum.Models.Filters;
using Forum.Service.Services.TagService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [AllowAnonymous]
    public class TagsController : BaseController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(BaseFilterModel filterModel)
        {
            var result= await _tagService.GetPagedTags(filterModel, Route);
            return Ok(result);
        }
    }
}
