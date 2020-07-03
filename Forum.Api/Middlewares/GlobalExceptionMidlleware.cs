using Forum.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Forum.Api.Middlewares
{
    public class GlobalExceptionMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMidlleware> _logger;

        public GlobalExceptionMidlleware(RequestDelegate next, ILogger<GlobalExceptionMidlleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }
      
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(new ExceptionDetails() { Message = ex.Message, StatusCode=context.Response.StatusCode }.ToJson());
        }
    }
}
