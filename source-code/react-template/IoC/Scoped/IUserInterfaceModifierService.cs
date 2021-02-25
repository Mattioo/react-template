using react_template_data.Data.Owner;
using System.Linq;

namespace react_template.IoC.Scoped
{
    public interface IUserInterfaceModifierService : IScopeService
    {
        public IQueryable<NavbarElement> GetNavbarElements(bool isAuthenticated);
    }
}
