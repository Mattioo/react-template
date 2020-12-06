using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;

namespace react_template_data.Repositories.Master
{
    public class BackgroundJobsRepository : BaseRepository<BackgroundJob>, IBackgroundJobsRepository
    {
        public BackgroundJobsRepository(MasterContext context) : base(context)
        { }
    }
}
