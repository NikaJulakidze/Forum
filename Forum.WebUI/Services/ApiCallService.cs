using Forum.WebUI.Extensions;
using Forum.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forum.WebUI.Services
{
    public class ApiCallService:IApiCallService
    {
        public HttpClient HttpClient { get; }
        
        public ApiCallService(HttpClient httpClient)
        {
            HttpClient= httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }
        
        public async Task<ApiCallResult<TResponse>> GetAsync<TResponse>(string url)
        {
            var response = await HttpClient.GetAsync(url);
            return await response.ApiResponseHandler<TResponse>();
        }
        
        public async Task<ApiCallResult<TResponse>> PostAsync<TResponse>(string url,object data)
        {
            var response= await HttpClient.PostAsync(url, ObjectToJson(data));
            return await response.ApiResponseHandler<TResponse>();
        }

        public async Task<ApiCallResult<TResponse>> PutAsync<TResponse>(string url, object data)
        {
            var response = await HttpClient.PutAsync(url, ObjectToJson(data));
            return await response.ApiResponseHandler<TResponse>();
        }

        public async Task<ApiCallResult<TResponse>> DeleteAsync<TResponse>(string url)
        {
            var response = await HttpClient.DeleteAsync(url);
            return await response.ApiResponseHandler<TResponse>();
        }

 

        public StringContent ObjectToJson(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

    }
}
