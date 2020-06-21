using react_template_data.Data;
using react_template_data.Data.Master;

namespace react_template_data.Repositories
{
    public class BackgroundJobsRepository : BaseRepository<BackgroundJob>
    {
        public BackgroundJobsRepository(MasterContext context) : base(context)
        { }
    }
}
