using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using react_template.Helpers.Filters;
using react_template.IoC.Singletons;
using react_template.Models.Results;
using Swashbuckle.AspNetCore.Annotations;

namespace react_template.Controllers
{
    [ApiController]
    [AppActionFilter]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        #region Logger
        private readonly ILogger<AppController> _logger;
        #endregion
        private readonly IStylesService _stylesService;

        public AppController(ILogger<AppController> logger, IStylesService stylesService)      
        {
            _logger = logger;
            _stylesService = stylesService;
        }

        [HttpGet("styles")]
        [SwaggerResponse(404, "Brak informacji o kaskadowym arkuszu styli")]
        [SwaggerResponse(200, "Informacje o kaskadowym arkuszu styli", Type = typeof(StyleResult))]
        [SwaggerOperation("Pobiera informacje o kaskadowym arkuszu styli", "Informacje opisują katalog i plik przypisany do konkretnego adresu URL")]
        public async Task<IActionResult> Styles(string url, CancellationToken cancellationToken = default)
        {
            var styles = await _stylesService.GetByUrl(url, cancellationToken);

            if (styles is null)
                return NotFound();

            return Ok(JsonConvert.SerializeObject(new StyleResult
            {
                Dict = styles.Dict,
                File = styles.File
            }));
        }
    }
}
