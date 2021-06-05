using PromotionEngine.Data.Rules;
using PromotionEngine.Data.SKUs;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Core
{
    public class ProcessPromotion
    {
        private readonly List<PromotionRule> promotionRules;
        private readonly List<SKU> availableSKUs;

        public ProcessPromotion()
        {
            promotionRules = new RuleRepository().GetPromotionRules();
            availableSKUs = new SKURepository().GetAvailableSKU();
        }

        public ShoppingCart GetCartAmount(ShoppingCart order)
        {
            if (order.ShoppingCartItem.Count == 0)
            {
                order.Total = 0;
                return order;
            }

            var promoprices = promotionRules.Select(promo => GetTotalPrice(order, promo))
                    .ToList();

            order.Total = promoprices.Sum();

            return order;
        }

        private decimal GetOriginalPrice(string skuName)
        {
            var skuItem = availableSKUs.Find(sku =>
                    sku.Name.Equals(skuName, System.StringComparison.OrdinalIgnoreCase));
            return skuItem.Price;
        }

        private int GetOfferQuantity(PromotionRule prom, string sku)
        {
            try
            {
                var offeredQualtity = prom.PromoCondition.Name.Count(pi => pi == sku);
                if (offeredQualtity == 0)
                    return 1;

                return offeredQualtity;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private decimal GetTotalPrice(ShoppingCart ord, PromotionRule prom)
        {
            decimal d = 0M;

            var promotedProductList = ord.ShoppingCartItem.GroupBy(
                x => x.SKU.Name,
                x => GetOriginalPrice(x.SKU.Name),
                (sku, product) => new
                {
                    SKU= sku,
                    ProductOrdered = product.Count(),
                    ProductPrice = product.Min(),
                    Pair = product.Count() / GetOfferQuantity(prom, sku)
                })
                .Where(grp => prom.PromoCondition.Name.Any(sku => grp.SKU == sku)).ToList();

            if (promotedProductList.Count == 0)
                return d;

            if (promotedProductList.Count == 1)
            {
                var copp = promotedProductList[0];
                var count = copp.ProductOrdered;

                int ppc = prom.PromoCondition.Name.Count;

                while (count >= ppc)
                {
                    if(prom.PromoCondition.PromotionType.Equals(PromotionType.FixedRateDiscount))
                        d += prom.PromoCondition.Discount;
                    else
                        d += (ppc * copp.ProductPrice * prom.PromoCondition.Discount)/100;

                    count -= ppc;
                }

                if (count > 0)
                    d += count * copp.ProductPrice;

                return d;
            }

            var maxPair = promotedProductList.Min(x => x.Pair);
            bool isPromoPriceAdded = false;

            foreach (var product in promotedProductList)
            {
                // var promoQuantity = prom.PromoCondition.Name.FindAll(pi => pi == product.SKU).Count;
                var promoQuantity = prom.PromoCondition.Name.Count(pi => pi == product.SKU);
                if (!isPromoPriceAdded)
                {
                    if (prom.PromoCondition.PromotionType.Equals(PromotionType.FixedRateDiscount))
                        d += (maxPair * prom.PromoCondition.Discount);
                    else
                        d += (maxPair * promoQuantity * product.ProductPrice * prom.PromoCondition.Discount) / 100;
                    isPromoPriceAdded = true;
                }

                d += ((product.ProductOrdered - (maxPair * promoQuantity)) * product.ProductPrice);
            }

            return d;
        }
    }
}
