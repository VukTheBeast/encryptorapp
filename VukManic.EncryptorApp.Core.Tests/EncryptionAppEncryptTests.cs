using VukManic.EncryptorApp.Core.AES;

namespace VukManic.EncryptorApp.Core.Tests
{
    [TestClass]
    public class EncryptionAppEncryptTests
    {
        private EncryptionApp _app;
        private readonly string _keyString = "E546C8DF278CD5931069B522E695D4F2";
        private readonly string _stringToEncypt = "STRING_TO_BE_ENCRYPTED";

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new EncryptionApp(new AesEncryptionStrategy());
        }

        [TestMethod]
        public void EncryptionAppTests_HappyPath()
        {
            // act
            var result = _app.Encrypt(_stringToEncypt, _keyString);

            // assert
            result.ShouldNotBeNull();
            result.ShouldNotBe(string.Empty);
            result.ShouldNotBe(_stringToEncypt);
            result.ShouldBeOfType<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Encrypt_NullString()
        {
            // act
            _app.Encrypt(null, _keyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Encrypt_EmptyString()
        {
            // assert 
            var stringTest = string.Empty;

            // act
            _app.Encrypt(stringTest, _keyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key for encryption should not be empty or null")]
        public void EncryptionAppTests_Encrypt_KeyStringNull()
        {
            // act
            _app.Encrypt(_stringToEncypt, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key for encryption should not be empty or null")]
        public void EncryptionAppTests_Encrypt_KeyStringEmpty()
        {
            // act
            _app.Encrypt(_stringToEncypt, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key is not valid. Length is not sufficient")]
        public void EncryptionAppTests_Encrypt_KeyStringInvalid()
        {
            // act
            _app.Encrypt(_stringToEncypt, "INVALID_KEY");
        }
    }
}