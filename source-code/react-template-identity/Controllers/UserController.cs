using Microsoft.AspNetCore.Mvc;
using react_template_identity.Controllers.Base;
using react_template_identity.IoC.Scoped;
using react_template_identity.Models;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_identity.Controllers
{
    [Route("api/users")]
    [Produces("application/json")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel model, CancellationToken cancellationToken)
            => await Create(_userService.Create(model, cancellationToken));

        [HttpHead("{username}")]
        public async Task<IActionResult> Exists([FromRoute] string username, CancellationToken cancellationToken)
            => await Exists(_userService.Exists(username, cancellationToken));

        [HttpGet("{username}")]
        public async Task<IActionResult> Get([FromRoute] string username, CancellationToken cancellationToken)
            => await Get(_userService.Get(username, cancellationToken));

        [HttpPut("{username}/email/confirm")]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string username, CancellationToken cancellationToken)
            => await ConfirmEmail(_userService.ConfirmEmail(username, cancellationToken));

        [HttpPut("{username}/password/change")]
        public async Task<IActionResult> ChangePassword([FromRoute] string username, [FromBody] UserPasswordModel model, CancellationToken cancellationToken)
            => await ChangePassword(_userService.ChangePassword(username, model, cancellationToken));

        [HttpPut("{username}/password/reset")]
        public async Task<IActionResult> ResetPassword([FromRoute] string username, [FromBody] UserPasswordModel model, CancellationToken cancellationToken)
            => await ChangePassword(_userService.ResetPassword(username, model, cancellationToken));

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete([FromRoute] string username, CancellationToken cancellationToken)
            => await Delete(_userService.Delete(username, cancellationToken));
    }
}
