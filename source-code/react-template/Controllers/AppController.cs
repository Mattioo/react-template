using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using react_template.Helpers.Filters;
using react_template.IoC.Scoped;
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

        public AppController(ILogger<AppController> logger)      
        {
            _logger = logger;
        }
    }
}
