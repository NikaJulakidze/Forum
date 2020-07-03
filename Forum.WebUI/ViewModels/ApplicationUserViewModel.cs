using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.ViewModels
{
    public class ApplicationUserViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("usermane")]
        public string Username { get; set; }
        [JsonProperty("ratingpoints")]
        public int RatingPoints { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
