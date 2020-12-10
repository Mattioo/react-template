using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using react_template_notifications.IoC;
using react_template_notifications.Options;
using react_template_notifications.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace react_template_notifications
{
    class Program
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly IConfiguration ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", $"appsettings.{Env}.json"), true)
            .Build();

        static async Task Main(string[] args)
        {
            #region Rejestracja DI
            var queueSection = ConfigurationBuilder.GetSection(NotificationsOptions.Name);

            var serviceProvider = new ServiceCollection()
                .Configure<NotificationsOptions>(queueSection)
                .AddSingleton<INotificationService, NotificationService>()
                .BuildServiceProvider();
            #endregion

            Console.WriteLine("Wciśnięcie przycisku spowoduje zamknięcie serwisu");
            Console.ReadKey();

            await Task.CompletedTask;
        }
    }
}
