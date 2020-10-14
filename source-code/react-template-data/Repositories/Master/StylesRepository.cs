using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories.Master
{
    public class StylesRepository : BaseRepository<Style>, IMasterContextRepository
    {
        public StylesRepository(MasterContext context) : base(context)
        { }

        public async Task<Style> GetDefault(CancellationToken cancellationToken)
            => await Context.Set<Style>()
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Default && s.Active, cancellationToken);

        public async Task<Style> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken)
            => (
                await Context.Set<Url>()
                 .AsNoTracking()
                 .Include(u => u.Client)
                 .Include(u => u.Style)
                 .SingleOrDefaultAsync(filter, cancellationToken)
            )?.Style;
    }
}
