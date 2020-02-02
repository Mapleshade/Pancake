using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pancake.Configurations;
using Pancake.Services;

namespace PancakeLibraryTest
{
    [TestClass]
    public class RandomWordsServiceUnitTest
    {
        [TestMethod]
        public void TestInitialization()
        {
            var randomWordsService = InitializeService();
            Assert.IsTrue(randomWordsService.IsInitialized);
            randomWordsService.Dispose();
        }

        [TestMethod]
        public void TestGetRandomWord()
        {
            var randomWordsService = InitializeService();
            var word = randomWordsService.GetRandomWord();
            var stringIsEmpty = string.IsNullOrEmpty(word);
            Assert.IsFalse(stringIsEmpty);
            randomWordsService.Dispose();
        }
        
        [TestMethod]
        public void TestGetRandomWordWithStartChar()
        {
            var randomWordsService = InitializeService();
            var word = randomWordsService.GetRandomWordWithStartStr("ф");
            var stringIsEmpty = string.IsNullOrEmpty(word);
            Assert.IsFalse(stringIsEmpty);
            randomWordsService.Dispose();
        }

        [TestMethod]
        public void TestDispose()
        {
            var randomWordsService = InitializeService();
            Assert.IsTrue(randomWordsService.IsInitialized);
            randomWordsService.Dispose();
            Assert.IsFalse(randomWordsService.IsInitialized);
        }

        private RandomWordsService InitializeService()
        {
            PancakeConfiguration pancakeConfiguration = new PancakeConfiguration
            {
                DBConnectionString = "Host=localhost;Database=Words;Username=postgres;Password=marshmallow"
            };
            RandomWordsService randomWordsService = new RandomWordsService();
            randomWordsService.Init(pancakeConfiguration);
            return randomWordsService;
        }
    }
}