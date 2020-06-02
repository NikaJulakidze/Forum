using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Forum.WebUI.Helpers
{
    public static class ApiCallHelper
    {
        public static StringContent MyStringContent(object data)
        {
            var json= JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
