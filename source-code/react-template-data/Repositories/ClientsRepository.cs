using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories
{
    public class ClientsRepository : BaseRepository<Client>, IMasterContextRepository
    {
        public ClientsRepository(MasterContext context) : base(context)
        { }

        public async Task<Client> Get(Expression<Func<Url, bool>> filter, CancellationToken cancellationToken)
        {
            var found = await Context.Set<Url>()
                .AsNoTracking()
                .Include(u => u.Client)
                .SingleOrDefaultAsync(filter, cancellationToken);

            return found?.Client;
        }
    }
}
