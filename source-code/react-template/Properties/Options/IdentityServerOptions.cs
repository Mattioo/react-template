namespace react_template.Properties.Options
{
    public class IdentityServerOptions
    {
        public const string Name = "IdentityServerOptions";

        public string Authority { get; set; }
        public string Client { get; set; }
        public string Secret { get; set; }
        public string Scope { get; set; }       
        public string Response { get; set; }
    }
}
