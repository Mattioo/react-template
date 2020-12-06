using react_template_data.Data.Master;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.IoC.Master
{
    public interface IUnitsRepository : IMasterRepository<Unit>
    {
        public Task<Unit> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken);
    }
}
