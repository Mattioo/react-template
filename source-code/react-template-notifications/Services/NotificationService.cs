using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using react_template_notifications.IoC;
using react_template_notifications.Options;
using System;
using System.Text;

namespace react_template_notifications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _queue;

        public NotificationService(IOptions<QueueOptions> options)
        {
            _queue = options.Value.Queue;
            _connectionFactory = new ConnectionFactory
            {
                HostName = options.Value.Host,
                UserName = options.Value.User,
                Password = options.Value.Password
            };
        }

        public bool Save(string notification)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                var body = Encoding.UTF8.GetBytes(notification);

                channel.QueueDeclare(queue: _queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicPublish(exchange: "", routingKey: _queue, basicProperties: null, body: body);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
    }
}
