using Newtonsoft.Json;
using react_template_notifications.Enums;
using react_template_notifications.Helpers;
using react_template_notifications.IoC;
using System;

namespace react_template_notifications.Models
{
    public abstract class BaseNotificationModel<T> : IBaseNotificationModel where T : IConfigModel
    {
        public BaseNotificationModel()
        {
            Id = $"{Guid.NewGuid()}";
            Status = "New";

            Created = DateTime.UtcNow;
        }

        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("config")]
        public abstract T Config { get; protected set; }

        [JsonProperty("text")]
        public string Text { get; protected set; }

        [JsonProperty("created")]
        public DateTime Created { get; protected set; }

        [JsonProperty("date")]
        public DateTime? Date { get; protected set; }

        [JsonProperty("notification_event_type")]
        public NotificationEventType NotificationEventType { get; protected set; }

        [JsonProperty("notification_type")]
        public NotificationType NotificationType { get; protected set; }

        [JsonProperty("status")]
        public string Status { get; protected set; }

        [JsonProperty("encrypted")]
        public bool Encrypted { get; protected set; }

        [JsonProperty("sent")]
        public bool Sent { get; protected set; }

        public void Encrypt(string publicKey)
        {
            Id = Id.Encrypt(publicKey);
            Text = Text.Encrypt(publicKey);
            Status = Status.Encrypt(publicKey);

            Config.Encrypt(publicKey);
        }

        public void Decrypt(string privateKey)
        {
            Id = Id.Decrypt(privateKey);
            Text = Text.Decrypt(privateKey);
            Status = Status.Decrypt(privateKey);

            Config.Decrypt(privateKey);
        }

        public string Serialize() => JsonConvert.SerializeObject(this);

        #region validation
        [JsonIgnore]
        public virtual bool Valid => !string.IsNullOrWhiteSpace(Id) && !string.IsNullOrWhiteSpace(Status) && !string.IsNullOrWhiteSpace(Text) && Config.Valid;
        #endregion
    }
}
