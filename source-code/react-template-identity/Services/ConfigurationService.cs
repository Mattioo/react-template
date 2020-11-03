using IdentityServer4.Models;
using react_template_data.Repositories.Master;
using react_template_identity.IoC;
using System.Collections.Generic;
using System.Linq;

namespace react_template_identity.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly DomainSystemsRepository _domainSystemsRepository;

        public ConfigurationService(DomainSystemsRepository domainSystemsRepository)
        {
            _domainSystemsRepository = domainSystemsRepository;
        }

        public (IEnumerable<Client> clients, IEnumerable<IdentityResource> resources, IEnumerable<ApiScope> scopes) GetConfiguration()
        {
            var clients = _domainSystemsRepository.GetAll(c => c.Active).ToList();

            return (
                clients.Select(c => new Client { 
                    ClientId = c.Identifier,
                    ClientName = c.Name,
                    ClientSecrets = {
                        new Secret(c.Secret, null)
                    },
                    AllowedGrantTypes = c.GrantTypes.Where(grantType => grantType.Active)
                    .Select(grantType => grantType.Name)
                    .ToList(),
                    AllowedScopes = c.Scopes.Where(scope => scope.Active && !scope.ApiScope)
                    .Select(scope => scope.Name)
                    .ToList(),
                    RedirectUris = c.RedirectUris.Where(redirectUri => redirectUri.Active)
                    .Select(redirectUri => $"{redirectUri.Uri}/signin-oidc")
                    .ToList(),
                    PostLogoutRedirectUris = c.RedirectUris.Where(redirectUri => redirectUri.Active)
                    .Select(redirectUri => $"{redirectUri.Uri}/signout-callback-oidc")
                    .ToList()
                }),
                clients.SelectMany(c => c.IdentityResources.Where(resource => resource.Active))
                    .GroupBy(resource => resource.Name)
                    .Select(resource => new IdentityResource { 
                        Name = resource.Key,
                        UserClaims = resource.Select(r => r.Claim).ToList()
                    }),
                clients.SelectMany(c => c.Scopes
                    .Where(scope => scope.Active && scope.ApiScope))
                    .Select(scope => new ApiScope(scope.Name))
            );
        }
    }
}
