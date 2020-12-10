using MailKit.Security;
using MimeKit.Text;
using react_template_notifications.Models.Email;
using System;
using System.Collections.Generic;

namespace react_template_notifications.IoC.Email
{
    public interface IEmailNotificationModel : IBaseNotificationModel
    {
        public ICollection<string> From { get; }

        public ICollection<string> To { get; }

        public string Subject { get;  }

        public TextFormat TextFormat { get; }

        public ICollection<AttachmentModel> Attachments { get; }

        public EmailConfigModel Config { get; }

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
