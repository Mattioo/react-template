using System.Threading;
using System.Threading.Tasks;

namespace react_template.IoC.Singletons
{
    public interface IPdfService : ISingletonService
    {
        public Task<byte[]> Generate(string html, string host, CancellationToken cancellationToken);
    }
}
