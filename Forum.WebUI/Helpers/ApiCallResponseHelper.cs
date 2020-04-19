using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Helpers
{
    public class ApiCallResponseHelper<TResponse> where TResponse:class
    {
        public async Task<TResponse> GetResponseAsync(HttpResponseMessage message)
        {
            return null;
        }
        public async Task<TResponse> PostResponseAsync(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                
            }
            return null;    
        }
    }
}
