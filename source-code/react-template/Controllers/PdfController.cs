using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_template.IoC.Singletons;
using react_template_data.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [Authorize]
        [HttpGet("create")]
        [SwaggerResponse(400, "Problem podczas pobierania informacji o kaskadowym arkuszu styli")]
        [SwaggerResponse(200, "Wygenerowany dokument PDF", Type = typeof(FileContentResult))]
        [SwaggerOperation("Generuje dokument PDF na podstawie przasłanego kodu HTML", "Generator wykorzystuje kaskadowy arkusz styli przypisany do klienta")]
        public async Task<IActionResult> Create(string html, CancellationToken cancellationToken = default)
        {
            var host = HttpContext.GetHost();

            if (string.IsNullOrWhiteSpace(host))
                return BadRequest();

            var bytes = await _pdfService.Generate(html, host, cancellationToken);
            return File(bytes, "application/pdf");
        }
    }
}
