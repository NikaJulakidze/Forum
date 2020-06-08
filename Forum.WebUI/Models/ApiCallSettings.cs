using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Models
{
    public static class ApiCallSettings
    {
        public const string BaseUrl = "https://localhost:44326/api/";

        public const string GetPosts="";
        public const string CreatePost = "Post/CreatePost";
        public const string Register = "Account/Register";
        public const string Authenticate = "Account/Authenticate";
        public const string Test = "Account/Test";

    }
}
