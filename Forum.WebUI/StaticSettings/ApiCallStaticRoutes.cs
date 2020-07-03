namespace Forum.WebUI.StaticSettings
{
    public class ApiCallStaticRoutes
    {
        public const string BaseUrl = "https://localhost:44326/api/";

        public class Account
        {
            public const string Register = "Account/Register";
            public const string Authenticate = "Account/Authenticate";
            public const string Test = "Account/Test";
            public const string GetImage = "File/Getimage";
            public const string GetRoles = "Account/GetRoles";
        }

        public const string GetPosts = "";
        public const string CreatePost = "Post/CreatePost";
    }
}
