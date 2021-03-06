﻿namespace react_template_data.Data.Master
{
    public class RedirectUri
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }

        public DomainSystem DomainSystem { get; set; }

        #region Hidden
        public int DomainSystemId { get; set; }
        #endregion
    }
}
