using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC.Master;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories.Master
{
    public class UnitsRepository : BaseRepository<Unit>, IUnitsRepository
    {
        public UnitsRepository(MasterContext context) : base(context)
        { }

        public async Task<Unit> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken)
        {
            var found = await Context.Set<Url>()
                .AsNoTracking()
                .Include(u => u.Unit)
                .SingleOrDefaultAsync(filter, cancellationToken);

            return found?.Unit;
        }
    }
}
