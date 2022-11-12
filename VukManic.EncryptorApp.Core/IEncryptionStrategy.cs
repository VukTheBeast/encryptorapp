namespace VukManic.EncryptorApp.Core;

public interface IEncryptionStrategy
{
    string Encrypt(string stringToEncrypt, string keyString);

    string Decrypt(string cipherText, string keyString);
}