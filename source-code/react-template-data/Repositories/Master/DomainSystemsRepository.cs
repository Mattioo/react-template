using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Data.Master;
using react_template_data.IoC;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace react_template_data.Repositories.Master
{
    public class DomainSystemsRepository : BaseRepository<DomainSystem>, IMasterContextRepository
    {
        public DomainSystemsRepository(MasterContext context) : base(context)
        { }

        public override IQueryable<DomainSystem> GetAll(Expression<Func<DomainSystem, bool>> filter)
            => Context.Set<DomainSystem>()
                .AsNoTracking()
                .Include(_ => _.Scopes)
                .Include(_ => _.GrantTypes)
                .Include(_ => _.RedirectUris)
                .Where(filter);
    }
}
