using react_template_notifications.Enums;

namespace react_template_notifications.IoC
{
    public interface IBaseNotificationModel
    {
        public NotificationType NotificationType { get; }

        public bool Valid { get; }

        public string Serialize();

        public void Encrypt(string publicKey);

        public void Decrypt(string privateKey);
    }
}
