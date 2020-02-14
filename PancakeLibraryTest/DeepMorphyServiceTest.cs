using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pancake.Services;

namespace PancakeLibraryTest
{
    [TestClass]
    public class DeepMorphyServiceTest
    {
        [TestMethod]
        public void TestInitialization()
        {
            var deepMorphyService = InitializeService();
            Assert.IsTrue(deepMorphyService.IsInitialized);
        }

        [TestMethod]
        public void TestGramKey()
        {
            var deepMorphyService = InitializeService();
            var results = deepMorphyService.GetMorphInfoOfWord("красивый"); 
            Assert.AreEqual("прил", results.BestTag["чр"]);
        }

        private DeepMorphyService InitializeService()
        {
            var deepMorphyService = new DeepMorphyService();
            deepMorphyService.Init();
            return deepMorphyService;
        }
    }
}