namespace react_template_data.Data.Owner
{
    public class Pdf
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool Default { get; set; }
        public bool Active { get; set; }     

        public string Encoding { get; set; }
        public int Orientation { get; set; }
        public int Size { get; set; }

        public bool Counter { get; set; }

        #region Margin
        public double? MarginTop { get; set; }
        public double? MarginBottom { get; set; }
        public double? MarginLeft { get; set; }
        public double? MarginRight { get; set; }
        public int MarginUnit { get; set; }
        #endregion
        #region Header
        public string HeaderFontName { get; set; }
        public short HeaderFontSize { get; set; }
        public string HeaderLeft { get; set; }
        public string HeaderRight { get; set; }
        public string HeaderCenter { get; set; }
        public string HeaderUrl { get; set; }
        public double? HeaderSpacing { get; set; }
        public bool HeaderLine { get; set; }
        #endregion
        #region Footer
        public string FooterFontName { get; set; }
        public short FooterFontSize { get; set; }
        public string FooterLeft { get; set; }
        public string FooterRight { get; set; }
        public string FooterCenter { get; set; }
        public string FooterUrl { get; set; }
        public double? FooterSpacing { get; set; }
        public bool FooterLine { get; set; }
        #endregion
    }
}
