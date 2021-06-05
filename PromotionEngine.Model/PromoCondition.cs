using System.Collections.Generic;

namespace PromotionEngine.Model
{
    public class PromoCondition
    {
        public List<string> Name { get; set; }

        public PromotionType PromotionType { get; set; }

        public decimal Discount { get; set; }
    }
}
