using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC.Scoped
{
    public interface IPdfService : IScopeService
    {
        public Task<byte[]> Generate(string html, string host, CancellationToken cancellationToken);
    }
}
