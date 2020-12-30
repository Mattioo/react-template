using DinkToPdf;
using DinkToPdf.Contracts;
using react_template.IoC.Singletons;
using react_template_data.Data.Owner;
using react_template_data.IoC.Owner;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace react_template.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter converter;       
        private readonly IStylesService stylesService;
        private readonly IPdfRepository pdfRepository;

        public PdfService(IConverter converter, IStylesService stylesService, IPdfRepository pdfRepository)
        {
            this.converter = converter;
            this.stylesService = stylesService;
            this.pdfRepository = pdfRepository;
        }

        public async Task<byte[]> Generate(string html, string host, CancellationToken cancellationToken)
        {
            if (await pdfRepository.Get(pdf => pdf.Active && pdf.Default, cancellationToken) is Pdf config)
            {
                var styles = await stylesService.GetByUrl(host, cancellationToken);
                var pathToStyle = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "dist", "styles", styles.Dict, styles.File);

                var globalSettings = new GlobalSettings
                {
                    Orientation = (Orientation) config.Orientation,
                    PaperSize = (PaperKind) config.Size,
                    Margins = new MarginSettings
                    { 
                        Top = config.MarginTop,
                        Bottom = config.MarginBottom,
                        Left = config.MarginLeft,
                        Right = config.MarginRight,
                        Unit = (Unit) config.MarginUnit
                    },
                    DocumentTitle = config.Title
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = config.Counter,
                    HtmlContent = html,
                    WebSettings =
                    {
                        DefaultEncoding = config.Encoding,
                        UserStyleSheet = pathToStyle
                    },
                    HeaderSettings = 
                    {
                        FontName = config.HeaderFontName,
                        FontSize = config.HeaderFontSize,
                        Left = config.HeaderLeft,
                        Right = config.HeaderRight, 
                        Center = config.HeaderCenter,
                        HtmUrl = config.HeaderUrl,
                        Spacing = config.HeaderSpacing,
                        Line = config.HeaderLine
                    },
                    FooterSettings = 
                    {
                        FontName = config.FooterFontName,
                        FontSize = config.FooterFontSize,
                        Left = config.FooterLeft,
                        Right = config.FooterRight,
                        Center = config.FooterCenter,
                        HtmUrl = config.FooterUrl,
                        Spacing = config.FooterSpacing,
                        Line = config.FooterLine
                    }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                return converter.Convert(pdf);
            }

            return null;
        }
    }
}
