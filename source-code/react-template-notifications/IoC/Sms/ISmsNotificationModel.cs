using react_template_notifications.Models.Sms;
using System;
using System.Collections.Generic;

namespace react_template_notifications.IoC.Sms
{
    public interface ISmsNotificationModel : IBaseNotificationModel
    {
        public SmsConfigModel Config { get; }
        public ICollection<string> PhoneNumbers { get; }

        public ISmsNotificationModel SetConfiguration(string token, int maxNumberOfCharacters = 160);
        public ISmsNotificationModel SetRecipients(string number, params string[] others);
        public ISmsNotificationModel SetMessage(string text);
        public ISmsNotificationModel SetTime(DateTime date);
        public new ISmsNotificationModel Encrypt(string publicKey);
        public new ISmsNotificationModel Decrypt(string privateKey);
    }
}
