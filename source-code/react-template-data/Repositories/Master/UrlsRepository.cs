using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;

namespace react_template_data.Repositories.Master
{
    public class UrlsRepository : BaseRepository<Url>, IUrlsRepository
    {
        public UrlsRepository(MasterContext context) : base(context)
        { }
    }
}
