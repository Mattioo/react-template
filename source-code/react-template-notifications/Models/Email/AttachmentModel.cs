using Newtonsoft.Json;

namespace react_template_notifications.Models.Email
{
    public class AttachmentModel
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("media_subtype")]
        public string MediaSubtype { get; set; }

        [JsonProperty("base64")]
        public string Base64 { get; set; }
    }
}
