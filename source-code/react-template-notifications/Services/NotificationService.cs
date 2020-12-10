using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using react_template_notification.Helpers;
using react_template_notifications.Enums;
using react_template_notifications.IoC;
using react_template_notifications.IoC.Email;
using react_template_notifications.IoC.Sms;
using react_template_notifications.Options;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace react_template_notifications.Services
{
    public class NotificationService : INotificationService
    {
        private AsyncEventingBasicConsumer consumer;
        private IConnection connection;
        private IModel model;

        private readonly ConnectionFactory connectionFactory;
        private readonly string queue;
       
        public NotificationService(IOptions<NotificationsOptions> options)
        {
            this.queue = options.Value.Queue;
            this.connectionFactory = new ConnectionFactory
            {
                HostName = options.Value.Host,
                UserName = options.Value.User,
                Password = options.Value.Password,
                DispatchConsumersAsync = true
            };
            Scan();
        }

        public bool Save(string notification)
        {
            try
            {
                using var connection = this.connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(this.queue, true, false, false, null);

                var body = Encoding.UTF8.GetBytes(notification);
                var props = channel.CreateBasicProperties();
                    props.Persistent = true;

                channel.BasicPublish(string.Empty, this.queue, props, body);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Task Scan()
        {
            try
            {
                this.connection = this.connectionFactory.CreateConnection();
                this.model = this.connection.CreateModel();

                this.model.BasicQos(prefetchSize: 0, prefetchCount: ushort.MaxValue, global: false);

                this.consumer = new AsyncEventingBasicConsumer(this.model);
                this.consumer.Received += async (o, a) =>
                {
                    var body = a.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var type = (NotificationType) JsonConvert.DeserializeObject<JObject>(message).GetValue("notification_type").Value<long>();

                    switch (type)
                    {
                        case NotificationType.Email:
                            var email = NotificationModelFactory.CreateNotificationModel<IEmailNotificationModel>(message);
                            if (email.Encrypted)
                            {
                                email.Decrypt(Keys.RSA.PrivateKey);
                            }
                            SendEmail(email);
                        break;
                        case NotificationType.Sms:
                            var sms = NotificationModelFactory.CreateNotificationModel<ISmsNotificationModel>(message);
                            if (sms.Encrypted)
                            {
                                sms.Decrypt(Keys.RSA.PrivateKey);
                            }
                            SendSms(sms);
                        break;
                    }

                    Console.WriteLine($"Message Get: {a.DeliveryTag}");

                    this.model.BasicAck(a.DeliveryTag, false);
                    await Task.Yield();
                };

                this.model.BasicConsume(this.queue, false, this.consumer);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        private bool SendEmail(IEmailNotificationModel message)
        {
            try
            {
                if (message.Valid)
                {
                    var email = new MimeMessage
                    {
                        Subject = message.Subject
                    };

                    foreach (var from in message.From)
                        email.From.Add(MailboxAddress.Parse(from));

                    foreach (var to in message.To)
                        email.To.Add(MailboxAddress.Parse(to));

                    var multipart = new Multipart("mixed")
                    {
                        new TextPart(message.TextFormat)
                        {
                            Text = message.Text
                        }
                    };

                    foreach (var attachment in message.Attachments)
                    {
                        multipart.Add(new MimePart(attachment.MediaType, attachment.MediaSubtype)
                        {
                            Content = new MimeContent(new MemoryStream(Convert.FromBase64String(attachment.Base64))),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = attachment.Filename
                        });
                    }

                    email.Body = multipart;

                    using var smtp = new SmtpClient();
                    smtp.Connect(message.Config.Host, message.Config.Port, message.Config.SecureSocketOptions);
                    smtp.Authenticate(message.Config.Username, message.Config.Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception)
            {
                
            }

            return false;
        }

        private bool SendSms(ISmsNotificationModel message)
        {
            try
            {
                if (message.Valid)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
               
            }
            return false;
        }
    }
}
