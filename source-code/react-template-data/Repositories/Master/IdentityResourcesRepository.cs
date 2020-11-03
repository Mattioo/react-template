using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;

namespace react_template_data.Repositories.Master
{
    public class IdentityResourcesRepository : BaseRepository<IdentityResource>, IMasterContextRepository
    {
        public IdentityResourcesRepository(MasterContext context) : base(context)
        { }
    }
}
