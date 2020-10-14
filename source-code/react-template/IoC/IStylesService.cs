using react_template_data.Data.Master;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC
{
    public interface IStylesService
    {
        public Task<Style> GetDefault(CancellationToken cancellationToken);

        public Task<Style> GetByUrl(string url, CancellationToken cancellationToken);
    }
}
