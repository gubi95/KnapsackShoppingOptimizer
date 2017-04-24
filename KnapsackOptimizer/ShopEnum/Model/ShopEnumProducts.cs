using System;
using System.Collections.Generic;
using System.Linq;
using KnapsackOptimizer.Model;

namespace KnapsackOptimizer.ShopEnum.Model
{
    internal class ShopEnumProducts
    {
        public List<ShopEnumPosition> ShopEnumPositions { get; set; }
        public decimal Cost { get; set; }

        public ShopEnumProducts(Dictionary<Guid, int> shoppingList)
        {
            ShopEnumPositions = new List<ShopEnumPosition>();
            foreach (var product in shoppingList)
            {
                var shopEnumPosition = new ShopEnumPosition
                {
                    ProductId = product.Key,
                    Amount = product.Value,
                    Price = decimal.MaxValue
                };
        
                ShopEnumPositions.Add(shopEnumPosition);
            }
        }

        public bool ComputeCost()
        {
            if (ShopEnumPositions.Any(position => position.Price == decimal.MaxValue))
            {
                Cost =  decimal.MaxValue;
                return false;
            }
            var shipmentCost = ShopEnumPositions.Select(position => position.Store).Distinct().Sum(store => store.ShipmentCost);
            var productsCost = ShopEnumPositions.Select(position => position.Price).Sum();

            Cost = shipmentCost + productsCost;
            return true;
        }

        public void Clear()
        {
            ShopEnumPositions.ForEach(position => position.Price = decimal.MaxValue);
        }

        public OptimizedShoppingList ToOptimizedShoppingList(TimeSpan elapsed)
        {
            var optimizedList = new OptimizedShoppingList
            {
                TotalPrice = Cost,
                TimeElapsed = elapsed,
                ProductIdToStoreIDictionary = new Dictionary<Guid, Guid>(ShopEnumPositions.Count)
            };
            ShopEnumPositions.ForEach(position =>
            {
                optimizedList.ProductIdToStoreIDictionary.Add(position.ProductId, position.Store.StoreID);
            });

            return optimizedList;
        }
    }
}
