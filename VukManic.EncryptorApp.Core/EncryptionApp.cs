using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace VukManic.EncryptorApp.Core;

public class EncryptionApp
{
    public object Encrypt(string stringToEncrypt)
    {
        var keyString = "E546C8DF278CD5931069B522E695D1Rv";
        var key = Encoding.UTF8.GetBytes(keyString);

        using var aesAlg = Aes.Create();
        using var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(stringToEncrypt);
            }
        }

        var iv = aesAlg.IV;

        var decryptedContent = msEncrypt.ToArray();

        var result = new byte[iv.Length + decryptedContent.Length];

        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

        return Convert.ToBase64String(result);
    }
}