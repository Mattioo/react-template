using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using react_template.Models.Results;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly AppController _app;
        private readonly IConverter _converter;

        public PdfController(AppController app, IConverter converter)
        {
            _app = app;
            _converter = converter;
        }

        [Authorize]
        [HttpGet("create")]
        [SwaggerResponse(400, "Problem podczas pobierania informacji o kaskadowym arkuszu styli")]
        [SwaggerResponse(200, "Wygenerowany dokument PDF", Type = typeof(FileContentResult))]
        [SwaggerOperation("Generuje dokument PDF na podstawie przasłanego kodu HTML", "Generator wykorzystuje kaskadowy arkusz styli przypisany do klienta")]
        public async Task<IActionResult> Create( string html, CancellationToken cancellationToken = default)
        {
            var host = new Uri(HttpContext.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);
            var response = await _app.Styles(host, cancellationToken);

            if (response is OkObjectResult ok && ok.Value is string info)
            {
                var styleInfo = JsonConvert.DeserializeObject<StyleResult>(info);
                var pathToStyle = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "dist", "styles", styleInfo.Dict, styleInfo.File);

                var globalSettings = new GlobalSettings
                {
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF File"
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = pathToStyle },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "PDF Footer" }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                var file = _converter.Convert(pdf);
                return File(file, "application/pdf");
            }

            return BadRequest();
        }
    }
}
