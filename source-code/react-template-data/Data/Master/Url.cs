namespace react_template_data.Data.Master
{
    public class Url
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }

        public Unit Unit { get; set; }

        #region Hidden
        public int UnitId { get; set; }
        #endregion
    }
}
