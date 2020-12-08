using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace react_template_identity.Controllers.Base
{
    public class BaseController : Controller
    {
        protected async Task<IActionResult> Get<T>(Task<T> model)
        {
            var result = await model;

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected async Task<IActionResult> Exists(Task<bool> action)
        {
            var result = await action;

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        protected async Task<IActionResult> Create<T>(Task<T> model)
        {
            var result = await model;

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        protected async Task<IActionResult> ChangePassword(Task action)
        {
            await action;

            if (action.IsCompletedSuccessfully)
            {
                return Ok();
            }

            return BadRequest();
        }

        protected async Task<IActionResult> ConfirmEmail(Task action)
        {
            await action;

            if (action.IsCompletedSuccessfully)
            {
                return Ok();
            }

            return BadRequest();
        }

        protected async Task<IActionResult> Delete(Task<bool> action)
        {
            var result = await action;

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
