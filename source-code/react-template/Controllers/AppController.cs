using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace react_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private static readonly IDictionary<string, (string dict, string file)> styles = new Dictionary<string, (string dict, string file)>
        {
            { "default", ("default", "styles.2GPJa.css") },
            { "http://localhost:9001", ("other", "styles.3Z37u.css") }
        };

        private readonly ILogger<AppController> _logger;

        public AppController(ILogger<AppController> logger)
        {
            _logger = logger;
        }

        [HttpGet("styles")]
        public async Task<IActionResult> Styles(string url)
        {
            var (dict, file) = !string.IsNullOrWhiteSpace(url) && styles.ContainsKey(url) ? styles[url] : styles["default"];
            return await Task.FromResult(Ok(JsonConvert.SerializeObject(new
            {
                dict,
                file
            })));
        }
    }
}
