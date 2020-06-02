using Forum.Service.Dto;
using Forum.WebUI.Extensions;
using Forum.WebUI.Helpers;
using Forum.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var result = await HttpClient.GetAsync(url); 
            return result;
        }
        public async Task<HttpResponseMessage> GetAync(string url, string jwtToken = null)
        {
            return await HttpClient.GetAsync(url);
        }

        public async Task<ApiCallResult<TResponse>> PostAsync<TResponse>(string url,object data)
        {
            var response= await HttpClient.PostAsync(url, ObjectToJson(data));
            return await response.PostResponseHandler<TResponse>();
        }

        public async Task<ApiCallResult<TResponse>> PostResponseHandler<TResponse>()
        {
            return null;
        }

        public async Task<string> GetAsStringAsync(string url)
        {
            var result= await HttpClient.GetStringAsync(url);
            return result;
        }

        public StringContent ObjectToJson(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }
    }
}
