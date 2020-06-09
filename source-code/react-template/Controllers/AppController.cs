using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using react_template_data.Repositories;

namespace react_template.Controllers
{
    [ApiController]
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

            return Ok(JsonConvert.SerializeObject(new
            {
                dict = found.Dict,
                file = found.File
            }));
        }
    }
}
