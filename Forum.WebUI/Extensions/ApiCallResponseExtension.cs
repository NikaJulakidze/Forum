using Forum.WebUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Extensions
{
    public static class ApiCallResponseExtension
    {
        public static async Task<TResponse> PostResponseAsync<TResponse>(this HttpResponseMessage message, ApiCall httpClient, string url)
        {
            var stringResult = await httpClient.GetAsStringAsync(url);
            if (message.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(stringResult);
            }
            return JsonConvert.DeserializeObject<TResponse>(stringResult);
        }
    }
}
