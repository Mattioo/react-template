using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;

namespace react_template_data.Repositories.Master
{
    public class DomainSystemsRepository : BaseRepository<DomainSystem>, IMasterContextRepository
    {
        public DomainSystemsRepository(MasterContext context) : base(context)
        { }
    }
}
