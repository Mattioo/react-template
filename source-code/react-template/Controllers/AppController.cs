using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using react_template.Helpers.Filters;
using react_template.IoC.Scoped;
using react_template_data.Data.Owner;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Controllers
{
    [ApiController]
    [AppActionFilter]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        #region Logger
        private readonly ILogger<AppController> logger;
        #endregion

        private readonly IUserInterfaceModifierService userInterfaceModifierService;

        public AppController(ILogger<AppController> logger, IUserInterfaceModifierService userInterfaceModifierService)
        {
            this.logger = logger;
            this.userInterfaceModifierService = userInterfaceModifierService;
        }

        [HttpGet("navbar")]
        [AllowAnonymous]
        [SwaggerResponse(200, "Lista elementów paska nawigacyjnego", Type = typeof(IEnumerable<NavbarElement>))]
        [SwaggerOperation("Pobiera listę dostępnych elementów paska nawigacyjnego")]
        public async Task<IEnumerable<NavbarElement>> GetNavbarElements([FromQuery] string lang, CancellationToken cancellationToken)
        {
            return await userInterfaceModifierService.GetNavbarElements(User.Identity.IsAuthenticated).ToListAsync(cancellationToken);
        }
    }
}
