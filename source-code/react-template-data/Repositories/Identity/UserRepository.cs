using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using react_template_data.Data;
using react_template_data.Data.IS;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data.Repositories.Identity
{
    public class UserRepository : UserManager<User>
    {
        private readonly IdentityContext context;

        public UserRepository(IdentityContext context, IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher,
                userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.context = context;
        }

        public Task<bool> IsExistsAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken)
        {
            return context.Set<User>()
                .AsNoTracking()
                .AnyAsync(filter, cancellationToken);
        }

        public Task<User> GetUserAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken)
        {
            return context.Set<User>()
                .SingleOrDefaultAsync(filter, cancellationToken);
        }
    }
}
