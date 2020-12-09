using MailKit.Security;
using MimeKit.Text;
using System;

namespace react_template_notifications.IoC.Email
{
    public interface IEmailNotificationModel : IBaseNotificationModel
    {
        public IEmailNotificationModel SetConfiguration(string host, int port, string username, string password, SecureSocketOptions secureSocketOptions);
        public IEmailNotificationModel SetAuthors(string author, params string[] others);
        public IEmailNotificationModel SetRecipients(string email, params string[] others);
        public IEmailNotificationModel SetTime(DateTime date);
        public IEmailNotificationModel SetSubject(string subject);
        public IEmailNotificationModel SetBody(TextFormat textFormat, string text);
        public IEmailNotificationModel AddAttachment(string filename, string mediaType, string mediaSubtype, byte[] bytes);

        public new IEmailNotificationModel Encrypt(string publicKey);
        public new IEmailNotificationModel Decrypt(string privateKey);
    }
}
