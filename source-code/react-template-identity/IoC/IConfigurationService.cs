using IdentityServer4.Models;
using System.Collections.Generic;

namespace react_template_identity.IoC
{
    public interface IConfigurationService
    {
        public (IEnumerable<Client> clients, IEnumerable<ApiScope> scopes) GetConfiguration();
    }
}