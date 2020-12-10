using NETCore.Encrypt;
using NETCore.Encrypt.Internal;

namespace react_template_notification.Helpers
{
    public static class Keys
    {
        public static RSAKey RSA = EncryptProvider.CreateRsaKey(RsaSize.R4096);
    }
}
