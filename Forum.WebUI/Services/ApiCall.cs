using Forum.Service.Dto;
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
        private HttpClient HttpClient { get; }

        public ApiCall(HttpClient httpClient)
        {
            HttpClient= httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }
        
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var result = await HttpClient.GetAsync(url);
            return result;
        }

        public async Task<HttpResponseMessage> PostAsync<TData>(string url,TData data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await HttpClient.PostAsync(url, content);
        }

        public async Task<string> GetAsStringAsync(string url)
        {
            return await HttpClient.GetStringAsync(url);
        }
    }
}
