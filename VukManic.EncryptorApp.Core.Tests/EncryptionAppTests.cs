using Shouldly;

namespace VukManic.EncryptorApp.Core.Tests
{
    [TestClass]
    public class EncryptionAppTests
    {
        private EncryptionApp _app;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new EncryptionApp();
        }

        [TestMethod]
        public void EncryptionAppTests_HappyPath()
        {
            // assert 
            var stringTest = "STRING_TO_BE_ENCRYPTED";
            
            // act
            var result = _app.Encrypt(stringTest);

            // assert
            result.ShouldNotBeNull();
            result.ShouldNotBe(string.Empty);
            result.ShouldNotBe(stringTest);
            result.ShouldBeOfType<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Encrypt_NullString()
        {
            // act
            _app.Encrypt(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "String to encrypt should not be empty or null")]
        public void EncryptionAppTests_Encrypt_EmptyString()
        {
            // assert 
            var stringTest = string.Empty;

            // act
            _app.Encrypt(stringTest);
        }
    }
}