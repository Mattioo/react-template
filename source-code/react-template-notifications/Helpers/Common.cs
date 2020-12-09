using NETCore.Encrypt;
using System.Text.RegularExpressions;

namespace react_template_notifications.Helpers
{
    public static class Common
    {
        public static bool GSM(string text) => 
            new Regex("^[A-Za-z0-9 \\r\\n@£$¥èéùìòÇØøÅå\u0394_\u03A6\u0393\u039B\u03A9\u03A0\u03A8\u03A3\u0398\u039EÆæßÉ!\"#$%&'()*+,\\-./:;<=>?¡ÄÖÑÜ§¿äöñüà^{}\\\\\\[~\\]|\u20AC]*$").IsMatch(text);
    
        public static string Encrypt(this string text, string publicKey) =>
            EncryptProvider.RSAEncrypt(publicKey, text);

        public static string Decrypt(this string text, string publicKey) =>
            EncryptProvider.RSADecrypt(publicKey, text);
    }
}
