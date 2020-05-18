using Forum.WebUI.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Extensions
{
    public static class ApiCallResponseExtension
    {
        public static async Task<object> PostResponseAsync<TResponse>(this HttpResponseMessage message)
        {
            string result = await message.Content.ReadAsStringAsync();
            if (message.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(result);
            return JsonConvert.DeserializeObject<ErrorViewModel>(result);
        }

        public static bool PostResponceAsync(this HttpResponseMessage message)
        {
            return  message.IsSuccessStatusCode;
        }
    }
}
