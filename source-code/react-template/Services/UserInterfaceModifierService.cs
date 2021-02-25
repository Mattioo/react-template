using react_template.IoC.Scoped;
using react_template_data.Data.Owner;
using react_template_data.IoC.Owner;
using System.Linq;

namespace react_template.Services
{
    public class UserInterfaceModifierService : IUserInterfaceModifierService
    {
        private readonly INavbarElementRepository navbarElementRepository;

        public UserInterfaceModifierService(INavbarElementRepository navbarElementRepository)
        {
            this.navbarElementRepository = navbarElementRepository;
        }

        public IQueryable<NavbarElement> GetNavbarElements(bool isAuthenticated)
        {
            return navbarElementRepository.GetAll(ne => ne.Visible).Where(ne => ne.Anonymous || isAuthenticated).OrderBy(ne => ne.Order);
        }
    }
}
