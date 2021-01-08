using react_template_data.Data.Master;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC.Scoped
{
    public interface IStylesService : IScopeService
    {
        public Task<Style> GetByUrl(string url, CancellationToken cancellationToken);
    }
}
