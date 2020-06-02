using System.Collections.Generic;

namespace Forum.WebUI.Models
{
    public class ApiCallResult
    {
        public  bool Succeeded => ResultCode == ApiCallResultCode.Success;  
        public ApiCallResultCode ResultCode { get; set; }

        public NoSuccessResponse NoSuccessResponse;

        public static ApiCallResult Ok() => new ApiCallResult { ResultCode = ApiCallResultCode.Success };
        public static ApiCallResult BadRequest(NoSuccessResponse error) => new ApiCallResult { ResultCode = ApiCallResultCode.BadRequest,NoSuccessResponse=error};
        public static ApiCallResult InternalServerError(NoSuccessResponse error) => new ApiCallResult { ResultCode = ApiCallResultCode.ServerError,NoSuccessResponse=error };


        public static ApiCallResult<T> Ok<T>(T result) => new ApiCallResult<T> { ResultCode = ApiCallResultCode.Success, Data = result };
        public static ApiCallResult<T> BadRequest<T>(NoSuccessResponse error) => new ApiCallResult<T> { ResultCode = ApiCallResultCode.BadRequest,NoSuccessResponse=error };
        public static ApiCallResult<T> InternalServerError<T>(NoSuccessResponse error) => new ApiCallResult<T> { ResultCode = ApiCallResultCode.ServerError, NoSuccessResponse = error };
       
    }
    public class ApiCallResult<T> : ApiCallResult
    {
        public T Data { get; set; }
    }
    public enum ApiCallResultCode
    {
        Success = 1,
        NetworkError = 2,
        Deserialization = 3,
        BadRequest = 4,
        ServerError = 5
    }
}
