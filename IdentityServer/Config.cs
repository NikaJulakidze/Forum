using CommonModels.StaticSettings;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> { new ApiScope(StaticResources.ForumApi, "Forum") };

        public static IEnumerable<Client> Clients =>
         new List<Client>
         {

            new Client

            {
                ClientId = StaticClienIDs.ForumMvcId,

                ClientSecrets ={ new Secret(StaticCliendSecrets.ForumMvcSecret.Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44378/signin-oidc" },

                PostLogoutRedirectUris = { "https://localhost:44378/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
            }

         };

        public static IEnumerable<IdentityResource> Ids =>
               new List<IdentityResource>
               {
                 new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
               };
    }
}
