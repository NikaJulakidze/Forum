using System.Collections.Generic;
using System.Net;

namespace Forum.Service.Models
{
    public class Result
    {
        public bool Succeeded => noSuccessMessage == null;
        public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;

        public NoSuccessMessage noSuccessMessage;

        public static Result<T> Ok<T>(T result) => new Result<T> { Data = result };
        public static Result<T> BadRequest<T>(NoSuccessMessage error) => new Result<T>{noSuccessMessage=error};
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
