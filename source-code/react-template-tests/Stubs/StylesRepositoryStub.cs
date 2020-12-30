using react_template_data.Data.Master;
using react_template_data.IoC.Master;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_tests.Stubs
{
    public class StylesRepositoryStub : IStylesRepository
    {
        public async Task<Style> GetDefault(CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                new Style
                {
                    Id = 1,
                    Dict = "default",
                    File = "bundle.css",
                    Default = true,
                    Active = true
                });
        }

        public async Task<Style> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken)
        {
            return await GetDefault(cancellationToken);
        }

        public async Task<Style> Get(Expression<Func<Style, bool>> filter, CancellationToken cancellationToken)
        {
            return await GetDefault(cancellationToken);
        }
    }
}
