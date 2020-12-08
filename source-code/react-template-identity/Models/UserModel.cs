using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace react_template_identity.Models
{
    public class UserModel
    {
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [JsonProperty("confirm_password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
