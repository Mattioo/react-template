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

        [HttpHead("{id}")]
        public async Task<IActionResult> Exists([FromRoute] string id, CancellationToken cancellationToken)
            => await Exists(_userService.Exists(id, cancellationToken));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
            => await Get(_userService.Get(id, cancellationToken));

        [HttpPut("{id}/email/confirm")]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string id, CancellationToken cancellationToken)
            => await ConfirmEmail(_userService.ConfirmEmail(id, cancellationToken));

        [HttpPut("{id}/password/change")]
        public async Task<IActionResult> ChangePassword([FromRoute] string id, [FromBody] UserPasswordModel model, CancellationToken cancellationToken)
            => await ChangePassword(_userService.ChangePassword(id, model, cancellationToken));

        [HttpPut("{id}/password/reset")]
        public async Task<IActionResult> ResetPassword([FromRoute] string id, [FromBody] UserPasswordModel model, CancellationToken cancellationToken)
            => await ChangePassword(_userService.ResetPassword(id, model, cancellationToken));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id, [FromBody] UserPasswordModel model, CancellationToken cancellationToken)
            => await Delete(_userService.Delete(id, model, cancellationToken));
    }
}
