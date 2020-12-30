using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using react_template.IoC.Singletons;
using react_template_data.Data.Owner;
using react_template_data.Helpers;
using react_template_data.IoC.Owner;
using react_template_notification.Helpers;
using react_template_notifications.IoC;
using react_template_notifications.IoC.Email;
using react_template_notifications.Services;
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
        private readonly IPdfService pdfService;
        private readonly INotificationService notificationService;

        private readonly ISmtpRepository smtpConfigsRepository;

        public PdfController(IPdfService pdfService,
            INotificationService notificationService,
            ISmtpRepository smtpConfigsRepository)
        {
            this.pdfService = pdfService;
            this.notificationService = notificationService;
            this.smtpConfigsRepository = smtpConfigsRepository;
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

            if (await smtpConfigsRepository.Get(c => c.Active, cancellationToken) is Smtp config)
            {
                IEmailNotificationModel email =
                 NotificationModelFactory.CreateNotificationModel<IEmailNotificationModel>()
                    .SetConfiguration(config.Host, config.Port, config.Username, config.Password, (SecureSocketOptions)config.SecureSocketOption)
                    .SetAuthors("m.korolvv@gmail.com", "m.korolvv@gmail.com")
                    .SetRecipients("mateuszkorolow@gmail.com")
                    .SetSubject("Testowa wiadomość")
                    .SetBody(TextFormat.Html, $"<h1>Uruchomiono generator PDF - {DateTime.UtcNow}</h1>")
                    .Encrypt(Keys.RSA.PublicKey);

                notificationService.Save(email.Serialize());
            }

            var bytes = await this.pdfService.Generate(html, host, cancellationToken);

            if (bytes is null)
                return BadRequest();

            return File(bytes, "application/pdf");
        }
    }
}
