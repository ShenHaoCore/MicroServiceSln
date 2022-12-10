using IdentityServer4.Models;
using IdentityServer4;

namespace Micro.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> { new IdentityResources.OpenId(), new IdentityResources.Profile(), };

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> { new ApiScope("api1", "My API") };

        /// <summary>
        /// 客户端
        /// </summary>
        /// 机器对机器客户端
        /// AllowedScopes（客户端可以访问的作用域）
        /// RedirectUris（登录后重定向到哪里）
        /// PostLogoutRedirectUris（注销后重定向到的位置）
        public static IEnumerable<Client> Clients => new List<Client> {
            new Client { ClientId = "client", ClientSecrets = { new Secret("secret".Sha256()) }, AllowedGrantTypes = GrantTypes.ClientCredentials, AllowedScopes = { "api1" } }, // 交互式ASP.NET Core MVC客户端
            new Client { ClientId = "mvc", ClientSecrets = { new Secret("secret".Sha256()) }, AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = new List<string> { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
            }
        };
    }
}