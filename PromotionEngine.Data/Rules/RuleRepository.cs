using Newtonsoft.Json;
using PromotionEngine.Common;
using PromotionEngine.Model;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace PromotionEngine.Data.Rules
{
    public class RuleRepository : IRuleRepository
    {
        public List<PromotionRule> GetPromotionRules()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.PromotionRulesFilePath);
            return JsonConvert.DeserializeObject<List<PromotionRule>>(File.ReadAllText(filePath));
        }
    }
}
