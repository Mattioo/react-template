using System.Collections.Generic;

namespace react_template.Properties.Options
{
    public class StylesOptions
    {
        public const string Name = "Styles";
        public IList<StylesOption> All { get; set; }
    }

    public class StylesOption
    {
        public string Url { get; set; }
        public string Dict { get; set; }
        public string File { get; set; }
    }
}
