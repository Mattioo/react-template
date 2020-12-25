using react_template.IoC.Singletons;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;
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

        public async Task<Style> GetDefault(CancellationToken cancellationToken)
        {
            return await stylesRepository.GetDefault(cancellationToken);
        }

        public async Task<Style> GetByUrl(string url, CancellationToken cancellationToken)
        {
            return await stylesRepository.Get(u =>
                u.Active &&
                u.Path == url &&
                u.Unit.Active &&
                u.Style.Active,
                cancellationToken
            ) ??
            await stylesRepository.GetDefault(cancellationToken);
        }
    }
}
