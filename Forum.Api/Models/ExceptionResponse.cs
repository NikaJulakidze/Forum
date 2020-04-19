using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
