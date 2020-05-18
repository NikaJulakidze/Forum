using Forum.Service.Dto;
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
    public class ApiCall:IApiCall
    {
        public HttpClient HttpClient { get; }
        
        public ApiCall(HttpClient httpClient)
        {
            HttpClient= httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }
        
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var result = await HttpClient.GetAsync(url); 
            return result;
        }
        public async Task<HttpResponseMessage> GetAync(string url, string jwtToken)
        {
            return null;
        }

        public async Task<HttpResponseMessage> PostAsync<TData>(string url,TData data)
        {

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result= await HttpClient.PostAsync(url, content);
            return result;
        }

        public async Task<string> GetAsStringAsync(string url)
        {
            var result= await HttpClient.GetStringAsync(url);
            return result;
        }
    }
}
