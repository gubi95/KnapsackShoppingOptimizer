using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackOptimizer.ShomEnumAlgorithm.Model
{
    class ShopEnumProducts
    {
        public List<ShopEnumPosition> ShopEnumPositions { get; set; }

        public ShopEnumProducts(Dictionary<Guid, int> shoppingList)
        {
            this.ShopEnumPositions = new List<ShopEnumPosition>();
            foreach (var product in shoppingList)
            {
                var shopEnumPosition = new ShopEnumPosition();
               // shopEnumPosition.StorePosition.BaseProduct = product;
                shopEnumPosition.StorePosition.Price = decimal.MaxValue;
                shopEnumPosition.Found = false;
                ShopEnumPositions.Add(shopEnumPosition);
            }
        }

        public decimal GetShoppingListValue()
        {
            if (ShopEnumPositions.Any(position => !position.Found)) return decimal.MaxValue;
            var shipmentCost = ShopEnumPositions.Select(position => position.Store).Distinct().Sum(store => store.ShipmentCost);
            var productsCost = ShopEnumPositions.Select(position => position.StorePosition.Price).Sum();

            return shipmentCost + productsCost;
        }

        public void Clear()
        {
            ShopEnumPositions.ForEach(position => position.Found = false);
        }
    }
}
