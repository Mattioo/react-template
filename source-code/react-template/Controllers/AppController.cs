using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using react_template.Helpers.Filters;
using react_template.Models.Results;
using react_template_data.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace react_template.Controllers
{
    [ApiController]
    [AppActionFilter]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly ILogger<AppController> _logger;
        private readonly StylesRepository _stylesRepository;

        public AppController(ILogger<AppController> logger,
            StylesRepository stylesRepository)
        {
            _logger = logger;
            _stylesRepository = stylesRepository;
        }

        [HttpGet("styles")]
        [SwaggerResponse(404, "Brak informacji o kaskadowym arkuszu styli")]
        [SwaggerResponse(200, "Informacje o kaskadowym arkuszu styli", Type = typeof(StyleResult))]
        [SwaggerOperation("Pobiera informacje o kaskadowym arkuszu styli", "Informacje opisują katalog i plik przypisany do konkretnego adresu URL")]
        public async Task<IActionResult> Styles(string url, CancellationToken cancellationToken = default)
        {
            var found = await _stylesRepository.Get(u =>
                u.Active &&
                u.Path == url &&
                u.Client.Active &&
                u.Style.Active,
                cancellationToken
            ) ??
            await _stylesRepository.GetDefault(cancellationToken);

            if (found is null)
                return NotFound();

            return Ok(JsonConvert.SerializeObject(new StyleResult
            {
                Dict = found.Dict,
                File = found.File
            }));
        }
    }
}
