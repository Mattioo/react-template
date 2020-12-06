using react_template_data.Data.Master;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.IoC.Master
{
    public interface IStylesRepository : IMasterRepository<Style>
    {
        public Task<Style> GetDefault(CancellationToken cancellationToken);
        public Task<Style> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken);
    }
}
