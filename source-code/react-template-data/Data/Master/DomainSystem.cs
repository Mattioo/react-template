using System.Collections.Generic;

namespace react_template_data.Data.Master
{
    public class DomainSystem
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public bool Active { get; set; }

        public List<Scope> Scopes { get; set; }
        public List<GrantType> GrantTypes { get; set; }
        public List<RedirectUri> RedirectUris { get; set; }
        public List<IdentityResource> IdentityResources { get; set; }
    }
}
