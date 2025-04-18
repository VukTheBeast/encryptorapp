﻿using System.Security.Cryptography;
using System.Text;

namespace VukManic.EncryptorApp.Core.AES
{
    public class AesEncryptionStrategy : IEncryptionStrategy
    {
        public string Encrypt(string stringToEncrypt, string keyString)
        {
            if (string.IsNullOrWhiteSpace(stringToEncrypt))
            {
                throw new ArgumentException("String to encrypt should not be empty or null", nameof(stringToEncrypt));
            }

            if (string.IsNullOrWhiteSpace(keyString))
            {
                throw new ArgumentException("Key for encryption should not be empty or null", nameof(keyString));
            }

            var key = Encoding.UTF8.GetBytes(keyString);

            using var aesAlg = Aes.Create();

            using var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using var swEncrypt = new StreamWriter(csEncrypt);
                swEncrypt.Write(stringToEncrypt);
            }

            var iv = aesAlg.IV;

            var decryptedContent = msEncrypt.ToArray();

            var result = new byte[iv.Length + decryptedContent.Length];

            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

            return Convert.ToBase64String(result);
        }

        public string Encrypt(byte[] byteArray, string keyString)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string keyString)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                throw new ArgumentException("String to encrypt should not be empty or null", nameof(cipherText));
            }

            if (string.IsNullOrWhiteSpace(keyString))
            {
                throw new ArgumentException("Key for encryption should not be empty or null", nameof(keyString));
            }

            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public string Decrypt(byte[] byteArray, string keyString)
        {
            throw new NotImplementedException();
        }
    }
}
