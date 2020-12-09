using Newtonsoft.Json;
using react_template_notifications.Helpers;
using react_template_notifications.IoC.Sms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace react_template_notifications.Models.Sms
{
    public sealed class SmsNotificationModel : BaseNotificationModel<SmsConfigModel>, ISmsNotificationModel
    {
        public SmsNotificationModel()
        {
            NotificationType = Enums.NotificationType.Sms;
            Config = new SmsConfigModel();
            PhoneNumbers = new List<string>();
        }

        [JsonProperty("config")]
        public override SmsConfigModel Config { get; protected set; }

        [JsonProperty("phone_numbers")]
        public ICollection<string> PhoneNumbers { get; private set; }

        public ISmsNotificationModel SetConfiguration(string token, int maxNumberOfCharacters = 160)
        {
            Config.Token = token;
            Config.MaxNumberOfCharacters = maxNumberOfCharacters;
            return this;
        }

        public ISmsNotificationModel SetRecipients(string number, params string[] others)
        {
            PhoneNumbers.Add(number);

            foreach (var to in others)
                PhoneNumbers.Add(to);

            return this;
        }

        public ISmsNotificationModel SetMessage(string text)
        {
            Text = text;
            return this;
        }

        public ISmsNotificationModel SetTime(DateTime date)
        {
            Date = date;
            return this;
        }

        public new ISmsNotificationModel Encrypt(string publicKey)
        {
            if (!Encrypted)
            {
                base.Encrypt(publicKey);

                PhoneNumbers = PhoneNumbers.Select(phone => phone.Encrypt(publicKey)).ToList();
                Encrypted = true;
            }
            return this;
        }

        public new ISmsNotificationModel Decrypt(string privateKey)
        {
            if (Encrypted)
            {
                base.Decrypt(privateKey);

                PhoneNumbers = PhoneNumbers.Select(phone => phone.Decrypt(privateKey)).ToList();
                Encrypted = false;
            }
            return this;
        }

        #region validation
        public override bool Valid => base.Valid && PhoneNumbers.Count > 0 && Text.Length < Config.MaxNumberOfCharacters && Common.GSM(Text);
        #endregion
    }
}
