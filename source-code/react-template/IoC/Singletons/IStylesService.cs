using react_template_data.Data.Master;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC.Singletons
{
    public interface IStylesService : ISingletonService
    {
        public Task<Style> GetDefault(CancellationToken cancellationToken);

        public Task<Style> GetByUrl(string url, CancellationToken cancellationToken);
    }
}
