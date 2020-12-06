using react_template_data.Data;
using react_template_data.Data.Owner;
using react_template_data.IoC.Owner;

namespace react_template_data.Repositories.Owner
{
    public class PropertiesRepository : BaseRepository<Property>, IPropertiesRepository
    {
        public PropertiesRepository(OwnerContext context) : base(context)
        { }
    }
}
