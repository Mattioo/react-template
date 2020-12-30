using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC.Singletons
{
    public interface IPdfService : IScopeService
    {
        public Task<byte[]> Generate(string html, string host, CancellationToken cancellationToken);
    }
}
