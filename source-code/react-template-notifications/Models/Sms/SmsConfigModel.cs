using Newtonsoft.Json;
using react_template_notifications.Helpers;
using react_template_notifications.IoC;

namespace react_template_notifications.Models.Sms
{
    public class SmsConfigModel : IConfigModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("max_number_of_characters")]
        public int MaxNumberOfCharacters { get; set; }

        public void Encrypt(string publicKey)
        {
            Token = Token.Encrypt(publicKey);
        }

        public void Decrypt(string privateKey)
        {
            Token = Token.Decrypt(privateKey);
        }

        #region validation
        [JsonIgnore]
        public bool Valid => !string.IsNullOrWhiteSpace(Token);
        #endregion
    }
}
