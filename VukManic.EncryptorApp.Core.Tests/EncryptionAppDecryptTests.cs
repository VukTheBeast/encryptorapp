using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VukManic.EncryptorApp.Core.Tests
{
    [TestClass]
    public class EncryptionAppDecryptTests
    {
        private EncryptionApp _app;
        private readonly string _keyString = "E546C8DF278CD5931069B522E695D1Rv";
        private string _encryptedString;
        private readonly string _stringToEncypt = "STRING_TO_BE_ENCRYPTED";

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new EncryptionApp();
            _encryptedString = _app.Encrypt(_stringToEncypt, _keyString);
        }

        [TestMethod]
        public void EncryptionAppTests_Decrypt_HappyPath()
        {
            // act
            var result = _app.Decrypt(_encryptedString, _keyString);

            // assert
            result.ShouldNotBeNull();
            result.ShouldNotBe(string.Empty);
            result.ShouldBeOfType<string>();
            result.ShouldBe(_stringToEncypt);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Decrypt_NullString()
        {
            // act
            _app.Encrypt(null, _keyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Decrypt_EmptyString()
        {
            // assert 
            var stringTest = string.Empty;

            // act
            _app.Encrypt(stringTest, _keyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key for encryption should not be empty or null")]
        public void EncryptionAppTests_Decrypt_KeyStringNull()
        {
            // act
            _app.Encrypt(_stringToEncypt, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key for encryption should not be empty or null")]
        public void EncryptionAppTests_Decrypt_KeyStringEmpty()
        {
            // act
            _app.Encrypt(_stringToEncypt, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key is not valid. Length is not sufficient")]
        public void EncryptionAppTests_Decrypt_KeyStringInvalid()
        {
            // act
            _app.Encrypt(_stringToEncypt, "INVALID_KEY");
        }
    }
}
