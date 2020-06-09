using System.Collections.Generic;

namespace react_template_data.Data.Master
{
    public class Style
    {
        public int Id { get; set; }
        public string Dict { get; set; }
        public string File { get; set; }

        public bool Default { get; set; }
        public bool Active { get; set; }

        public List<Url> Urls { get; set; }
    }
}
