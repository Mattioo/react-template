using MailKit.Security;
using MimeKit.Text;
using Newtonsoft.Json;
using react_template_notifications.Helpers;
using react_template_notifications.IoC.Email;
using System;
using System.Collections.Generic;
using System.Linq;

namespace react_template_notifications.Models.Email
{
    public sealed class EmailNotificationModel : BaseNotificationModel<EmailConfigModel>, IEmailNotificationModel
    {
        public EmailNotificationModel()
        {
            NotificationType = Enums.NotificationType.Email;
            Config = new EmailConfigModel();
            Attachments = new List<AttachmentModel>();
            From = new List<string>();
            To = new List<string>();
        }

        [JsonProperty("config")]
        public override EmailConfigModel Config { get; protected set; }
       
        [JsonProperty("subject")]
        public string Subject { get; private set; }

        [JsonProperty("text_format")]
        public TextFormat TextFormat { get; private set; }

        [JsonProperty("from")]
        public ICollection<string> From { get; private set; }

        [JsonProperty("to")]
        public ICollection<string> To { get; private set; }

        [JsonProperty("attachments")]
        public ICollection<AttachmentModel> Attachments { get; private set; }

        public IEmailNotificationModel SetConfiguration(string host, int port, string username, string password, SecureSocketOptions secureSocketOptions)
        {       
            Config.Host = host;        
            Config.Port = port;
            Config.Username = username;
            Config.Password = password;
            Config.SecureSocketOptions = secureSocketOptions;
            return this;
        }

        public IEmailNotificationModel SetAuthors(string author, params string[] others)
        {
            From.Add(author);

            foreach (var from in others)
                From.Add(from);

            return this;
        }

        public IEmailNotificationModel SetRecipients(string email, params string[] others)
        {
            To.Add(email);

            foreach (var to in others)
                From.Add(to);

            return this;
        }

        public IEmailNotificationModel SetTime(DateTime date)
        {
            Date = date;
            return this;
        }

        public IEmailNotificationModel SetSubject(string subject)
        {
            Subject = subject;
            return this;
        }

        public IEmailNotificationModel SetBody(TextFormat textFormat, string text)
        {
            TextFormat = textFormat;
            Text = text;

            return this;
        }

        public IEmailNotificationModel AddAttachment(string filename, string mediaType, string mediaSubtype, byte[] bytes)
        {
            var attachment = new AttachmentModel
            {
                Filename = filename,
                MediaType = mediaType,
                MediaSubtype = mediaSubtype,
                Base64 = Convert.ToBase64String(bytes)
            };

            Attachments.Add(attachment);
            return this;
        }

        public new IEmailNotificationModel Encrypt(string publicKey)
        {
            if (!Encrypted)
            {
                base.Encrypt(publicKey);

                Subject = Subject.Encrypt(publicKey);
                From = From.Select(from => from.Encrypt(publicKey)).ToList();
                To = To.Select(to => to.Encrypt(publicKey)).ToList();
                Attachments = Attachments.Select(attachment =>
                {
                    attachment.Filename = attachment.Filename.Encrypt(publicKey);
                    attachment.MediaType = attachment.MediaType.Encrypt(publicKey);
                    attachment.MediaSubtype = attachment.MediaSubtype.Encrypt(publicKey);

                    return attachment;
                })
                .ToList();

                Encrypted = true;
            }
 
            return this;
        }

        public new IEmailNotificationModel Decrypt(string privateKey)
        {
            if (Encrypted)
            {
                base.Decrypt(privateKey);

                Subject = Subject.Decrypt(privateKey);
                From = From.Select(from => from.Decrypt(privateKey)).ToList();
                To = To.Select(to => to.Decrypt(privateKey)).ToList();
                Attachments = Attachments.Select(attachment =>
                {
                    attachment.Filename = attachment.Filename.Decrypt(privateKey);
                    attachment.MediaType = attachment.MediaType.Decrypt(privateKey);
                    attachment.MediaSubtype = attachment.MediaSubtype.Decrypt(privateKey);

                    return attachment;
                })
                .ToList();

                Encrypted = false;
            }

            return this;
        }

        #region validation
        public override bool Valid => base.Valid && From.Count > 0 && To.Count > 0;
        #endregion
    }
}
