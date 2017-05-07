using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackOptimizer.Model
{
    internal class AlgorithmShoppingList
    {
        public List<ShoppingListPosition> Products { get; set; }
        public decimal Cost { get; set; }

        public AlgorithmShoppingList(Dictionary<Guid, int> shoppingList)
        {
            Cost = Decimal.MaxValue;
            Products = new List<ShoppingListPosition>();
            foreach (var product in shoppingList)
            {
                var shoppingListPosition = new ShoppingListPosition()
                {
                    ProductId = product.Key,
                    Amount = product.Value,
                    Price = decimal.MaxValue
                };
        
                Products.Add(shoppingListPosition);
            }
        }

        public bool ComputeCost()
        {
            if (Products.Any(position => position.Price == decimal.MaxValue))
            {
                Cost =  decimal.MaxValue;
                return false;
            }
            var shipmentCost = Products.Select(position => position.Store).Distinct().Sum(store => store.ShipmentCost);
            var productsCost = Products.Select(position => position.Price).Sum();

            Cost = shipmentCost + productsCost;
            return true;
        }

        public void Clear()
        {
            Products.ForEach(position => position.Price = decimal.MaxValue);
        }

        public OptimizedShoppingList ToOptimizedShoppingList(TimeSpan elapsed)
        {
            return new OptimizedShoppingList
            {
                TotalPrice = Cost,
                TimeElapsed = elapsed,
                Products = Products
            };
        }
    }
}
