using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;

namespace react_template_data.Repositories.Master
{
    public class StylesRepository : BaseRepository<Style>, IStylesRepository
    {
        public StylesRepository(MasterContext context) : base(context)
        { }
    }
}
