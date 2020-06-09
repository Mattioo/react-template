using react_template_data.Data;
using react_template_data.Data.Master;

namespace react_template_data.Repositories
{
    public class UrlsRepository : BaseRepository<Url>
    {
        public UrlsRepository(MasterContext context) : base(context)
        { }
    }
}
