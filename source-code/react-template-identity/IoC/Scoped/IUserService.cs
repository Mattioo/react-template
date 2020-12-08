using react_template_data.Data.IS;
using react_template_identity.Models;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_identity.IoC.Scoped
{
    public interface IUserService : IScopeService
    {
        public Task<User> Get(string username, CancellationToken cancellationToken);
        public Task<bool> Exists(string username, CancellationToken cancellationToken);
        public Task<User> Create(UserModel model, CancellationToken cancellationToken);
        public Task ConfirmEmail(string username, CancellationToken cancellationToken);
        public Task ChangePassword(string username, UserPasswordModel model, CancellationToken cancellationToken);
        public Task ResetPassword(string username, UserPasswordModel model, CancellationToken cancellationToken);
        public Task<bool> Delete(string username, CancellationToken cancellationToken);
    }
}
