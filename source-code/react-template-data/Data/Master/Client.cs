using System;
using System.Collections.Generic;

namespace react_template_data.Data.Master
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Database { get; set; }

        public string LicenceNo { get; set; }
        public DateTime LicenceSince { get; set; }
        public DateTime? LicenceTo { get; set; }
        public bool Active { get; set; }

        public List<Url> Urls { get; set; }
        public List<BackgroundJob> BackgroundJobs { get; set; }
    }
}
