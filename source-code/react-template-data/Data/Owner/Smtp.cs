namespace react_template_data.Data.Owner
{
    public class Smtp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SecureSocketOption { get; set; }
    }
}
