using react_template_data.Data;
using react_template_data.Data.Owner;
using react_template_data.IoC;

namespace react_template_data.Repositories
{
    public class PropertiesRepository : BaseRepository<Property>, IOwnerContextRepository
    {
        public PropertiesRepository(OwnerContext context) : base(context)
        { }
    }
}
