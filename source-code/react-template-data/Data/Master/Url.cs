namespace react_template_data.Data.Master
{
    public class Url
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }

        public Client Client { get; set; }       
        public Style Style { get; set; }

        #region Hidden
        public int ClientId { get; set; }
        public int StyleId { get; set; }
        #endregion
    }
}
