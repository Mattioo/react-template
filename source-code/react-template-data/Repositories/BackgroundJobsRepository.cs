using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;

namespace react_template_data.Repositories
{
    public class BackgroundJobsRepository : BaseRepository<BackgroundJob>, IMasterContextRepository
    {
        public BackgroundJobsRepository(MasterContext context) : base(context)
        { }
    }
}
