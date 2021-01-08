using react_template.IoC.Scoped;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Services
{
    public class StylesService : IStylesService
    {
        private readonly IStylesRepository stylesRepository;

        public StylesService(IStylesRepository stylesRepository)
        {
            this.stylesRepository = stylesRepository;
        }

        public async Task<Style> GetByUrl(string url, CancellationToken cancellationToken)
        {
            return await stylesRepository.Get(s => s.Active && s.Urls.Any(u => u.Path == url), cancellationToken);
        }
    }
}
