using DinkToPdf;
using DinkToPdf.Contracts;
using react_template.IoC.Singletons;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter converter;
        private readonly IStylesService stylesService;

        public PdfService(IConverter converter, IStylesService stylesService)
        {
            this.converter = converter;
            this.stylesService = stylesService;
        }

        public async Task<byte[]> Generate(string html, string host, CancellationToken cancellationToken)
        {
            var styles = await stylesService.GetByUrl(host, cancellationToken);
            var pathToStyle = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "dist", "styles", styles.Dict, styles.File);

            var globalSettings = new GlobalSettings
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Dokument"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = pathToStyle },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Strona [page] z [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Mateusz Korolow 2020 ®" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return converter.Convert(pdf);
        }
    }
}
