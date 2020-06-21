using System;

namespace react_template_data.Data.Master
{
    public class BackgroundJob
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? LastRun { get; set; }
        public bool Active { get; set; }

        public Client Client { get; set; }

        #region Hidden
        public int ClientId { get; set; }
        #endregion
    }
}
