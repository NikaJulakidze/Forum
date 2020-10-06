namespace CommonModels.StaticSettings
{
    public class StaticUrls
    {
        #if DEBUG
        public const string ApiBaseUrl = "https://localhost:44326";
        public const string IdentityServerUrl = "https://localhost:44319";
        public const string MvcForumClientUrl = "https://localhost:44378";
        public const string MvcRedirectUris = "https://localhost:44378/home/index";
        #endif
    }

    public class StaticClients
    {

    }

    public class StaticClienIDs
    {
        public const string ForumMvcId = "Forum.Mvc";
    }

    public class StaticCliendSecrets
    {
        public const string ForumMvcSecret = "secret";
    }


    public class StaticResources
    {
        public const string ForumApi = "Forum.Api";
    }

    public class StaticDisplayNames
    {
        public const string ForumApiDisplayName = "Forum";
    }

    public class StaticRoles
    {

    }
    public class StaticRoutes
    {

    }
    public class StaticPolicies
    {
        public const string ApiScope = "ApiScope";
    }
    public class StaticClaims
    {
        public const string ScopeClaim = "scope";
    }
}
