using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.IoC
{
    public interface IRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    }
}
