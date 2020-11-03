using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace react_template_identity
{
    public class Config
    {
        public static List<TestUser> Users()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "mattioo",
                    Password = "P@ssw0rd",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "mattioo@mailinator.com")
                    }
                }
            };
        }
    }
}
