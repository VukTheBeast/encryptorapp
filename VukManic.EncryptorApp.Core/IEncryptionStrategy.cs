namespace VukManic.EncryptorApp.Core;

public interface IEncryptionStrategy
{
    string Encrypt(string stringToEncrypt, string keyString);
    string Encrypt(byte[] byteArray, string keyString);
    string Decrypt(string cipherText, string keyString);
    string Decrypt(byte[] byteArray, string keyString);
}