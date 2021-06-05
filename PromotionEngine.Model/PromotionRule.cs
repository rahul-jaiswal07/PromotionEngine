namespace PromotionEngine.Model
{
    public class PromotionRule
    {
        public int PromoId { get; set; }

        public string PromoCode { get; set; }

        public string Description { get; set; }

        public PromoCondition PromoCondition { get; set; }

        public decimal FinalDiscount { get; set; }
    }
}
