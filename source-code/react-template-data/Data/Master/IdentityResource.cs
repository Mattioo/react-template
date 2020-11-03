namespace react_template_data.Data.Master
{
    public class IdentityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Claim { get; set; }
        public bool Active { get; set; }

        public DomainSystem DomainSystem { get; set; }

        #region Hidden
        public int DomainSystemId { get; set; }
        #endregion
    }
}
