using Newtonsoft.Json;
using react_template_notifications.IoC;
using react_template_notifications.IoC.Email;
using react_template_notifications.IoC.Sms;
using react_template_notifications.Models.Email;
using react_template_notifications.Models.Sms;
using System;

namespace react_template_notifications.Services
{
    public static class NotificationModelFactory
    {
        public static T CreateNotificationModel<T>(string value = "") where T : IBaseNotificationModel
        {
            return (typeof(T)) switch
            {
                Type type when type == typeof(ISmsNotificationModel) => string.IsNullOrWhiteSpace(value) ?
                        (T)(object) new SmsNotificationModel() :
                        (T)(object) JsonConvert.DeserializeObject<SmsNotificationModel>(value),

                Type type when type == typeof(IEmailNotificationModel) => string.IsNullOrWhiteSpace(value) ?
                        (T)(object) new EmailNotificationModel() :
                        (T)(object) JsonConvert.DeserializeObject<EmailNotificationModel>(value),

                _ =>    (T)(object) null
            };
        }
    }
}
