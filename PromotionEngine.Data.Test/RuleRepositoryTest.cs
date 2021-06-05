using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Common;
using PromotionEngine.Data.Rules;
using System.IO;
using System.Linq;

namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class RuleRepositoryTest
    {
        private readonly IRuleRepository ruleRepository;

        public RuleRepositoryTest()
        {
            ruleRepository = new RuleRepository();
        }

        [TestMethod]
        public void GetRules_JsonFileAvailable_ShouldReturnRules()
        {
            int expectedRules = 2;
            
            var rules = ruleRepository.GetPromotionRules();

            Assert.AreEqual(expectedRules, rules.Count);
        }


        [TestMethod]
        public void GetRule_JsonFileAvailable_VerifyRuleData()
        {
            int ruleOneConditions = 3;

            var rules = ruleRepository.GetPromotionRules();

            Assert.AreEqual(ruleOneConditions, rules.First().PromoCondition.Name.Count);
            Assert.AreEqual(1, rules.First().PromoId);
            Assert.AreEqual("Promo1", rules.First().PromoCode);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetRules_JsonFileNotAvailable_ShouldThrowException()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry,Constant.PromotionRulesFilePath);
            File.Delete(filePath);

            var rules = ruleRepository.GetPromotionRules();
        }
    }
}
