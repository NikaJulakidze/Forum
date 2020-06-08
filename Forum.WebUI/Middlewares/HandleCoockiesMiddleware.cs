using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Middlewares
{
    public class HandleCoockiesMiddleware
    {
        private readonly RequestDelegate _next;
        public HandleCoockiesMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    }
}
