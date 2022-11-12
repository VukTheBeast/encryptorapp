namespace VukManic.EncryptorApp.Core;

public interface IEncryptionApp
{
    string Encrypt(string stringToEncrypt, string keyString);
    string Decrypt(string cipherText, string keyString);
}