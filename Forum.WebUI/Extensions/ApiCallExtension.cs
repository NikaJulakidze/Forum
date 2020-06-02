using Forum.WebUI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Extensions
{
    public static class ApiCallExtension
    {
        public static async Task<ApiCallResult<TResponse>> PostResponseHandler<TResponse>(this HttpResponseMessage message)
        {
            switch (message.StatusCode)
            {
                case HttpStatusCode.OK:
                    var okMessage = await message.ReadResponseAs<TResponse>();
                    return ApiCallResult.Ok(okMessage);
                case HttpStatusCode.BadRequest:
                    var badrequestMessage = await message.ReadResponseAs<NoSuccessResponse>();
                    var result= ApiCallResult.BadRequest<TResponse>(badrequestMessage);
                    return result;
                default:
                    var UnhandledMessage = await message.ReadResponseAs<NoSuccessResponse>();
                    return  ApiCallResult.InternalServerError<TResponse>(UnhandledMessage);
            }
        }

        public static bool PostResponceAsync(this HttpResponseMessage message)
        {
            return  message.IsSuccessStatusCode;
        }

        public static async Task<ApiCallResult<TResponse>> HandleApiResponse<TResponse> (this HttpResponseMessage message)
        {
            return null;
        }

        public static async Task<TResponse> ReadResponseAs<TResponse>(this HttpResponseMessage message)
        {
            var json = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(json);
        } 
    }
}
