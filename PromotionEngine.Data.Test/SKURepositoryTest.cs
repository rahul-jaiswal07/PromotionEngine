using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Common;
using PromotionEngine.Data.SKUs;
using System.IO;
using System.Linq;

namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class SKURepositoryTest
    {
        private readonly ISKURepository sKURepository;

        public SKURepositoryTest()
        {
            sKURepository = new SKURepository();
        }

        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_ShouldReturnRules()
        {
            int expectedSKU = 4;

            var skuItem = sKURepository.GetAvailableSKU();

            Assert.AreEqual(expectedSKU, skuItem.Count);
        }


        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_VerifyRuleData()
        {
            int expectedSKU = 4;

            var skuItem = sKURepository.GetAvailableSKU();

            Assert.AreEqual(expectedSKU, skuItem.Count);
            Assert.AreEqual("A", skuItem.First().Name);
            Assert.AreEqual(50.0M, skuItem.First().Price);

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetAvailableSKU_JsonFileNotAvailable_ShouldThrowException()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.SKUFilePath);
            File.Delete(filePath);

            var rules = sKURepository.GetAvailableSKU();

        }
    }
}
