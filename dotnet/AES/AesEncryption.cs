using System.Security.Cryptography;

namespace AES
{
    public static class AesEncryption
    {
        public static byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;

            return aes.EncryptCbc(dataToEncrypt, iv);
        }

        public static byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;

            return aes.DecryptCbc(dataToDecrypt, iv);
        }
    }
}