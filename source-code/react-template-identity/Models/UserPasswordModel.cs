using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace react_template_identity.Models
{
    public class UserPasswordModel
    {
        [JsonProperty("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [JsonProperty("new_password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}