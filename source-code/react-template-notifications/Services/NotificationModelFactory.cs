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
        public static T CreateNotificationModel<T>() where T : IBaseNotificationModel
        {
            return (typeof(T)) switch
            {
                Type type when type == typeof(ISmsNotificationModel) =>
                     (T)(object) new SmsNotificationModel(),

                Type type when type == typeof(IEmailNotificationModel) =>
                     (T)(object) new EmailNotificationModel(),

                _ => (T)(object) null
            };
        }
    }
}
