using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using ApiResource = IdentityServer4.Models.ApiResource;
using Client = IdentityServer4.Models.Client;
using IdentityResource = IdentityServer4.Models.IdentityResource;
using Secret = IdentityServer4.Models.Secret;

namespace react_template_identity
{
    public class Config
    {
        public static ApiScope IdentityScope { get; } = new ApiScope("identity-scope", "identity access");
        public static string Role { get; } = "role";

        public static IEnumerable<ApiScope> Scopes()
        {
            return new List<ApiScope>
            {
                IdentityScope
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client> {
                new Client
                {
                    ClientId = "react-template",
                    ClientName = "Front office",
                    ClientSecrets = new List<Secret> {new Secret("P@ssw0rd".Sha256())},
    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:44394/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityScope.Name
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }

        public static IEnumerable<IdentityResource> Resources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = Role,
                    UserClaims = new List<string> {
                        Role
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1",
                    Scopes = new List<string> {
                        IdentityScope.Name
                    },
                    ApiSecrets = new List<Secret> {
                        new Secret("ScopeSecret".Sha256())
                    },
                    UserClaims = new List<string> {
                        Role
                    }
                }
            };
        }

        public static List<TestUser> Users()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "mattioo",
                    Password = "P@ssw0rd",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "mattioo@mailinator.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
