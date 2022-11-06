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
    }
}