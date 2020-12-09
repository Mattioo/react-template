namespace react_template_notifications.IoC
{
    public interface IConfigModel
    {
        public bool Valid { get; }

        public void Encrypt(string publicKey);
        public void Decrypt(string privateKey);
    }
}
