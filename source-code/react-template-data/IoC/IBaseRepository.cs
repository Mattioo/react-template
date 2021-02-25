using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.IoC
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
    }
}
