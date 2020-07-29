﻿using Forum.Models;
using Forum.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult CustomGenericResult<T>(Result<T> result)
        {
            return result.StatusCode switch
            {
                (int)HttpStatusCode.OK => Ok(result.Data),
                (int)HttpStatusCode.BadRequest => BadRequest(result.noSuccessMessage),
                (int)HttpStatusCode.NotFound => NotFound(),
                _ => StatusCode((int)HttpStatusCode.InternalServerError),
            };
        }

        protected IActionResult CustomResult(Result result)
        {
            return result.StatusCode switch
            {
                (int)HttpStatusCode.OK => Ok(),
                (int)HttpStatusCode.BadRequest => BadRequest(result.noSuccessMessage),
                (int)HttpStatusCode.NotFound => NotFound(),
                _ => StatusCode((int)HttpStatusCode.InternalServerError),
            };
        }

        protected string Email => User.FindFirstValue(ClaimTypes.Email);
        protected string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        protected string Route => Request.Path.Value;
    }
}
