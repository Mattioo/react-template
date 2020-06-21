using Newtonsoft.Json;

namespace react_template.Models.Results
{
    public class StyleResult
    {
        [JsonProperty("dict")]
        public string Dict { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
