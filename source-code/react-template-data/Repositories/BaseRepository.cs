using Microsoft.EntityFrameworkCore;
using react_template_data.Data.Master;
using react_template_data.IoC;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<T> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await Context.Set<T>()
                .AsNoTracking()
                .SingleOrDefaultAsync(filter, cancellationToken);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
            => Context.Set<T>()
                .AsNoTracking()
                .Where(filter);
    }
}
