using Microsoft.AspNetCore.Identity;
using react_template_data.Data.IS;
using react_template_identity.IoC.Scoped;
using react_template_identity.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Get(string id, CancellationToken cancellationToken)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> Exists(string id, CancellationToken cancellationToken)
        {
            return await Get(id, cancellationToken) != null;
        }

        public async Task<User> Create(UserModel model, CancellationToken cancellationToken)
        {
            if (await Exists(model.Id, cancellationToken))
            {
                await Task.FromException(new ArgumentException($"Problem podczas tworzenia konta " +
                   $"użytkownika. Szczegóły: Zajęty identyfikator - {model.Id}"));

                return null;
            }

            var user = new User
            {
                Id = model.Id,
                UserName = model.Username,
                NormalizedUserName = model.Username.ToUpper(),
                Email = model.Username,
                NormalizedEmail = model.Username.ToUpper()
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(o => o.Description);

                await Task.FromException(new ArgumentException($"Problem podczas tworzenia konta " +
                   $"użytkownika. Szczegóły: {string.Join(", ", errors)}"));

                return null;
            }

            return user;
        }

        public async Task ConfirmEmail(string id, CancellationToken cancellationToken)
        {
            var user = await Get(id, cancellationToken);

            if (user is null)
            {
                await Task.FromException(new ArgumentException($"Użytkownik nie istnieje. Szczegóły: {id}"));
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var identityResult = await _userManager.ConfirmEmailAsync(user, token);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(o => o.Description);

                await Task.FromException(new ArgumentException($"Problem podczas zmiany hasła u " +
                    $"użytkownika: {user.UserName}. Szczegóły: {string.Join(", ", errors)}"));
            }
        }

        public async Task ChangePassword(string id, UserPasswordModel model, CancellationToken cancellationToken)
        {
            var user = await Get(id, cancellationToken);

            if (user is null)
            {
                await Task.FromException(new ArgumentException($"Użytkownik nie istnieje. Szczegóły: {id}"));
            }

            var identityResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(o => o.Description);

                await Task.FromException(new ArgumentException($"Wystąpił problem podczas zmiany hasła u " +
                    $"użytkownika: {user.UserName}. Szczegóły: {string.Join(", ", errors)}"));
            }
        }

        public async Task ResetPassword(string id, UserPasswordModel model, CancellationToken cancellationToken)
        {
            var user = await Get(id, cancellationToken);

            if (user is null)
            {
                await Task.FromException(new ArgumentException($"Użytkownik nie istnieje. Szczegóły: {id}"));
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var identityResult = await _userManager.ResetPasswordAsync(user, token, model.Password);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(o => o.Description);

                await Task.FromException(new ArgumentException($"Problem podczas zmiany hasła u " +
                    $"użytkownika: {user.UserName}. Szczegóły: {string.Join(", ", errors)}"));
            }
        }

        public async Task<bool> Delete(string id, UserPasswordModel model, CancellationToken cancellationToken)
        {
            var user = await Get(id, cancellationToken);

            if (user is null)
            {
                await Task.FromException(new ArgumentException($"Użytkownik nie istnieje. Szczegóły: {id}"));
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                await Task.FromException(new ArgumentException($"Podano błędne hasło. Szczegóły: {user.UserName}"));
            }

            var identityResult = await _userManager.DeleteAsync(user);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(o => o.Description);

                await Task.FromException(new ArgumentException($"Wystąpił problem podczas usuwania użytkownika " +
                    $"użytkownika: {user.UserName}. Szczegóły: {string.Join(", ", errors)}"));
            }

            return true;
        }
    }
}
