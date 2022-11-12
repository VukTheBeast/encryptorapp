using System.Security.Cryptography;
using System.Text;

namespace VukManic.EncryptorApp.Core;

public class EncryptionApp : IEncryptionApp
{
    private IEncryptionStrategy _encryptionStrategy;

    public EncryptionApp(IEncryptionStrategy encryptionStrategy)
    {
        _encryptionStrategy = encryptionStrategy;
    }

    public string Encrypt(string stringToEncrypt, string keyString) => _encryptionStrategy.Encrypt(stringToEncrypt, keyString);

    public string Encrypt(byte[] byteArray, string keyString) => _encryptionStrategy.Encrypt(byteArray, keyString);

    public string Decrypt(string cipherText, string keyString) => _encryptionStrategy.Decrypt(cipherText, keyString);

    public string Decrypt(byte[] byteArray, string keyString) => _encryptionStrategy.Decrypt(byteArray, keyString);
}