using Microsoft.EntityFrameworkCore;
using react_template_data.IoC;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; }

        public virtual Task<T> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
            => Context.Set<T>()
                .AsNoTracking()
                .SingleOrDefaultAsync(filter, cancellationToken);
    }
}
