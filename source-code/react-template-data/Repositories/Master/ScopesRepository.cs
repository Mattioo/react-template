using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;

namespace react_template_data.Repositories.Master
{
    public class ScopesRepository : BaseRepository<Scope>, IMasterContextRepository
    {
        public ScopesRepository(MasterContext context) : base(context)
        { }
    }
}
