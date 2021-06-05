using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;

namespace PromotionEngine.Core.Test
{
    [TestClass]
    public class PromoRuleTest
    {
        [TestMethod]
        public void CartValue_ShouldBeZero()
        {
            decimal cartValue = 0;
            ShoppingCart shoppingCart = new ShoppingCart() { CartId = 1 };

            var processPromotion = new ProcessPromotion();
            shoppingCart = processPromotion.GetCartAmount(shoppingCart);

            Assert.AreEqual(cartValue, shoppingCart.Total);
        }

        [TestMethod]
        public void Cart_Should_Apply_Rule1()
        {
            decimal cartValue = 130.0m;
            ShoppingCart shoppingCart = new ShoppingCart() { CartId = 1 };
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });

            var processPromotion = new ProcessPromotion();
            shoppingCart = processPromotion.GetCartAmount(shoppingCart);

            Assert.AreEqual(cartValue, shoppingCart.Total);
        }

        [TestMethod]
        public void Cart_Should_Apply_Rule2()
        {
            decimal cartValue = 75m;
            ShoppingCart shoppingCart = new ShoppingCart() { CartId = 1 };
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });

            var processPromotion = new ProcessPromotion();
            shoppingCart = processPromotion.GetCartAmount(shoppingCart);

            Assert.AreEqual(cartValue, shoppingCart.Total);
        }

        [TestMethod]
        public void Apply_Multiple_Rule_On_Cart()
        {
            decimal cartValue = 275.0m;
            ShoppingCart shoppingCart = new ShoppingCart() { CartId = 1 };
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "C" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "C" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "D" } });

            var processPromotion = new ProcessPromotion();
            shoppingCart = processPromotion.GetCartAmount(shoppingCart);

            Assert.AreEqual(cartValue, shoppingCart.Total);
        }

        [TestMethod]
        public void NoRuleApplies_Multiple_Rule_On_Cart()
        {
            decimal cartValue = 130.0m;
            ShoppingCart shoppingCart = new ShoppingCart() { CartId = 1 };
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "A" } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { SKU = new SKU() { Name = "B" } });

            var processPromotion = new ProcessPromotion();
            shoppingCart = processPromotion.GetCartAmount(shoppingCart);

            Assert.AreEqual(cartValue, shoppingCart.Total);
        }
    }
}
