using AES;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

TestAesCBC();
TestAesGcm();

Console.ReadLine();

static void TestAesCBC()
{
    const string original = "Text to encrypt";

    var key = RandomNumberGenerator.GetBytes(32);
    var iv = RandomNumberGenerator.GetBytes(16);

    var encrypted = AesEncryption.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
    var decrypted = AesEncryption.Decrypt(encrypted, key, iv);

    var decryptedMessage = Encoding.UTF8.GetString(decrypted);

    Console.WriteLine("AES Encryption demonstration");
    Console.WriteLine("----------------------------");
    Console.WriteLine();
    Console.WriteLine("Original text = " + original);
    Console.WriteLine("Encrypted text = " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted text = " + decryptedMessage);
}

static void TestAesGcm()
{
    const string original = "Text to encrypt with Gcm";

    var gcmKey = RandomNumberGenerator.GetBytes(32);
    var nonce = RandomNumberGenerator.GetBytes(12);

    try
    {
        (byte[] cipherText, byte[] tag) result = AesGcmEncryption.Encrypt(Encoding.UTF8.GetBytes(original), gcmKey, nonce, Encoding.UTF8.GetBytes("some metadata"));

        byte[] decryptedText = AesGcmEncryption.Decrypt(result.cipherText, gcmKey, nonce, result.tag, Encoding.UTF8.GetBytes("some metadata"));

        Console.WriteLine("AES GCM Encryption demonstration");
        Console.WriteLine("----------------------------");
        Console.WriteLine();
        Console.WriteLine("Original text = " + original);
        Console.WriteLine("Encrypted text = " + Convert.ToBase64String(result.cipherText));
        Console.WriteLine("Decrypted text = " + Encoding.UTF8.GetString(decryptedText));
    }
    catch (CryptographicException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}