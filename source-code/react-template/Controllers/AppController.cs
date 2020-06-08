using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using react_template.Properties.Options;

namespace react_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly ILogger<AppController> _logger;
        private readonly IDictionary<string, (string dict, string file)> _styles;

        public AppController(ILogger<AppController> logger, IOptions<StylesOptions> options)
        {
            _logger = logger;
            _styles = options.Value.All.ToDictionary(s => s.Url, s => (dict: s.Dict, file: s.File));
        }

        [HttpGet("styles")]
        public async Task<IActionResult> Styles(string url)
        {
            var (dict, file) = !string.IsNullOrWhiteSpace(url) && _styles.ContainsKey(url) ? _styles[url] : _styles["default"];
            return await Task.FromResult(Ok(JsonConvert.SerializeObject(new
            {
                dict,
                file
            })));
        }
    }
}
