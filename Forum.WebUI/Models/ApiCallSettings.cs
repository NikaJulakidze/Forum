using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Models
{
    public static class ApiCallSettings
    {
#if DEBUG
        public const string BaseUrl = "https://localhost:44326/api";
#else
#endif
        public const string GetPosts="";
        public const string CreatePost = "/Post/CreatePost";

    }
}
