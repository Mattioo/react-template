using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;

namespace react_template_data.Repositories
{
    public class UrlsRepository : BaseRepository<Url>, IMasterContextRepository
    {
        public UrlsRepository(MasterContext context) : base(context)
        { }
    }
}
