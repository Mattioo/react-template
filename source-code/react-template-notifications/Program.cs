using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MimeKit.Text;
using NETCore.Encrypt;
using react_template_notifications.IoC;
using react_template_notifications.IoC.Email;
using react_template_notifications.IoC.Sms;
using react_template_notifications.Options;
using react_template_notifications.Services;
using System;
using System.IO;

namespace react_template_notifications
{
    class Program
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly IConfiguration ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", $"appsettings.{Env}.json"), true)
            .Build();

        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "image.gif");

            #region Rejestracja konfiguracji
            var queueSection = ConfigurationBuilder.GetSection(QueueOptions.Name);

            var serviceProvider = new ServiceCollection()
                .Configure<QueueOptions>(queueSection)
                .AddSingleton<INotificationService, NotificationService>()
                .BuildServiceProvider();
            #endregion

            var ns = serviceProvider.GetService<INotificationService>();

            IEmailNotificationModel eModel =
                NotificationModelFactory.CreateNotificationModel<IEmailNotificationModel>();
            ISmsNotificationModel sModel = 
                NotificationModelFactory.CreateNotificationModel<ISmsNotificationModel>();

            var rsa = EncryptProvider.CreateRsaKey(RsaSize.R4096);

            var email = eModel
                .SetConfiguration("smtp.gmail.com", 587, "m.korolvv@gmail.com", "[PASSWORD]", SecureSocketOptions.Auto)
                .SetAuthors("Mateusz Korolow", "mattioo@windowslive.com")
                .SetRecipients("mateuszkorolow@gmail.com")
                .SetSubject("Testowa wiadomość")
                .SetBody(TextFormat.Html, $"<h1>Dzisiaj - {DateTime.UtcNow}</h1>")
                .AddAttachment("image.gif", "image", "gif", File.ReadAllBytes(path))
                .Encrypt(rsa.PublicKey)
                .Serialize();

            var sms = sModel
                .SetConfiguration("6gz7z1VyApBBzBoG8L8bJ2LyEqnuFuU8iUmY93oa")
                .SetRecipients("888258188")
                .SetMessage("Testowa wiadomosc sms")
                .SetTime(DateTime.Now.AddMinutes(5))
                .Encrypt(rsa.PublicKey)
                .Serialize();

            if (eModel.Valid)
            {
                ns.Save(email);
            }

            if (sModel.Valid)
            {
                ns.Save(sms);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
