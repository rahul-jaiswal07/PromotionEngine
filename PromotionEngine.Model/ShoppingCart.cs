using System.Collections.Generic;

namespace PromotionEngine.Model
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }

        public decimal Total { get; set; }

        public int CartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
