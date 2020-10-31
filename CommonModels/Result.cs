using System.Net;

namespace CommonModels
{
    public class Result
    {
        public bool Succeeded => noSuccessMessage == null;
        public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;

        public NoSuccessMessage noSuccessMessage;

        public static Result Ok() => new Result { StatusCode = (int)HttpStatusCode.OK };
        public static Result BadRequest(NoSuccessMessage error) => new Result { noSuccessMessage = error, StatusCode = (int)HttpStatusCode.BadRequest };
        public static Result NotFound(NoSuccessMessage error) => new Result { noSuccessMessage = error, StatusCode = (int)HttpStatusCode.NotFound };

        public static Result<T> Ok<T>(T result) => new Result<T> { Data = result, StatusCode = (int)HttpStatusCode.OK };
        public static Result<T> BadRequest<T>(NoSuccessMessage error) => new Result<T> { noSuccessMessage = error, StatusCode = (int)HttpStatusCode.BadRequest };
        public static Result<T> NotFound<T>(NoSuccessMessage error) => new Result<T> { noSuccessMessage = error, StatusCode = (int)HttpStatusCode.NotFound };
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
