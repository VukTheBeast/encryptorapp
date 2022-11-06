namespace VukManic.EncryptorApp.Core.Tests
{
    [TestClass]
    public class EncryptionAppTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void EncryptionAppTests_HappyPath()
        {
            // assert 
            var stringTest = "STRING_TO_BE_ENCRYPTED";
            EncryptionApp app = new EncryptionApp();

            
            // act
            var result = app.Encrypt(stringTest);

            // assert
        }
    }
}