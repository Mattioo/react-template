using IdentityModel;
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
        public static IEnumerable<ApiScope> Scopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("read", "read access"),
                new ApiScope("write", "write access")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "react-template",
                    ClientName = "Front office",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("P@ssw0rd".Sha256())
                    },
                    AllowedScopes = new List<string> {
                        "read"
                    }
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
                    Name = "role",
                    UserClaims = new List<string> {
                        "role"
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
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {
                        "read",
                        "write"
                    },
                    ApiSecrets = new List<Secret> {
                        new Secret("ScopeSecret".Sha256())
                    },
                    UserClaims = new List<string> {
                        "role"
                    }
                }
            };
        }

        public static List<TestUser> Users()
        {
            return new List<TestUser> {
            new TestUser {
                SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                Username = "scott",
                Password = "password",
                Claims = new List<Claim> {
                    new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                    new Claim(JwtClaimTypes.Role, "admin")
                }
            }
        };
        }
    }
}
