using PromotionEngine.Core;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<ShoppingCart>
            {
                new ShoppingCart {
                    CartId = 1,
                    ShoppingCartItem = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                    }
                },
                new ShoppingCart {
                    CartId = 2,
                    ShoppingCartItem = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                    }
                },
                new ShoppingCart {
                    CartId = 3,
                    ShoppingCartItem = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "B" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "D" } },
                    }
                },
                new ShoppingCart {
                    CartId = 4,
                    ShoppingCartItem = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "C" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "D" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "D" } },
                        new ShoppingCartItem { SKU = new SKU { Name = "A" } },
                    }
                }
            };

            var processPromotion = new ProcessPromotion();

            foreach (var order in orders)
            {
                var cart = processPromotion.GetCartAmount(order);

                Console.WriteLine($"OrderID: {cart.CartId} => Total Cart Amount To be Paid:: {cart.Total.ToString("0.00")}");
            }
        }
    }
}
