using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace react_template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private static readonly string[] _names = new[]
        {
            "Angular", "React", "Vue"
        };

        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await Task.FromResult<IEnumerable<string>>(_names);
        }
    }
}
