using MailKit.Security;
using Newtonsoft.Json;
using react_template_notifications.Helpers;
using react_template_notifications.IoC;

namespace react_template_notifications.Models.Email
{
    public class EmailConfigModel : IConfigModel
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("secure_socket_options")]
        public SecureSocketOptions SecureSocketOptions { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public void Encrypt(string publicKey)
        {
            Host = Host.Encrypt(publicKey);
            Username = Username.Encrypt(publicKey);
            Password = Password.Encrypt(publicKey);
        }

        public void Decrypt(string privateKey)
        {
            Host = Host.Decrypt(privateKey);
            Username = Username.Decrypt(privateKey);
            Password = Password.Decrypt(privateKey);
        }

        #region validation
        [JsonIgnore]
        public bool Valid => !string.IsNullOrWhiteSpace(Host) && !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        #endregion
    }
}
