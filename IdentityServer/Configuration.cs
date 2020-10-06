using CommonModels.StaticSettings;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Configuration
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

                RedirectUris={ StaticUrls.MvcRedirectUris},
                PostLogoutRedirectUris={""},


                AllowedScopes = { StaticResources.ForumApi }}

         };
        public static IEnumerable<IdentityResource> Ids =>
               new List<IdentityResource>
               {
                 new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
               };
    }
}
