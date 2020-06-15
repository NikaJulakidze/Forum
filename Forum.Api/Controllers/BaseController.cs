using Forum.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult CustomGenericResult<T>(Result<T> result)
        {
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.noSuccessMessage);
        }

        protected IActionResult CustomResult(Result result)
        {
            if(result.Succeeded)
                return Ok();
            return BadRequest(result.noSuccessMessage);
        }
    }
}
