using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using Client = IdentityServer4.Models.Client;
using IdentityResource = IdentityServer4.Models.IdentityResource;
using Secret = IdentityServer4.Models.Secret;

namespace react_template_identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> Resources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("react-template-scope", "REACT API"),
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client> {
                new Client
                {
                    ClientId = "react-template",
                    ClientName = "Front office",
                    ClientSecrets = {
                        new Secret("P@ssw0rd".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44394/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44394/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "react-template-scope"
                    }
                }
            };
        }
    }
}
