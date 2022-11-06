namespace VukManic.EncryptorApp.Core.Tests
{
    [TestClass]
    public class EncriptionAppTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void EncrytporAppTests_HappyPath()
        {
            // assert 
            var stringTest = "STRING_TO_BE_ENCRYPTED";
            EncriptionApp app = new EncriptionApp();

            
            // act
            var result = app.Encrypt(stringTest);

            // assert
        }
    }

    public class EncriptionApp
    {
        public object Encrypt(string stringTest)
        {
            throw new NotImplementedException();
        }
    }
}