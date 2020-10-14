using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using react_template.IoC;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IStylesService _stylesService;
        private readonly IPdfService _pdfService;

        public PdfController(IStylesService stylesService, IPdfService pdfService)
        {
            _stylesService = stylesService;
            _pdfService = pdfService;
        }

        [Authorize]
        [HttpGet("create")]
        [SwaggerResponse(400, "Problem podczas pobierania informacji o kaskadowym arkuszu styli")]
        [SwaggerResponse(200, "Wygenerowany dokument PDF", Type = typeof(FileContentResult))]
        [SwaggerOperation("Generuje dokument PDF na podstawie przasłanego kodu HTML", "Generator wykorzystuje kaskadowy arkusz styli przypisany do klienta")]
        public async Task<IActionResult> Create(string html, CancellationToken cancellationToken = default)
        {
            var host = new Uri(HttpContext.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);
            var styles = await _stylesService.GetByUrl(host, cancellationToken);

            if (styles is null)
                return BadRequest();

            var bytes = _pdfService.Generate(html, styles);
            return File(bytes, "application/pdf");
        }
    }
}
