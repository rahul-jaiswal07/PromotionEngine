using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine.Data.Rules
{
    public interface IRuleRepository
    {
        List<PromotionRule> GetPromotionRules();
    }
}
