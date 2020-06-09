using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Data.Master;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories
{
    public class StylesRepository : BaseRepository<Style>
    {
        public StylesRepository(MasterContext context) : base(context)
        { }

        public virtual Task<Style> GetDefault(CancellationToken cancellationToken)
            => Context.Set<Style>()
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Default && s.Active, cancellationToken);

        public async Task<Style> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken)
        {
            var found = await Context.Set<Url>()
                .AsNoTracking()
                .Include(u => u.Client)
                .Include(u => u.Style)
                .SingleOrDefaultAsync(filter, cancellationToken);

            return found?.Style;
        }
    }
}
