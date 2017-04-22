using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackShoppingOptimizer;

namespace KnapsackOptimizer.ProductEnumAlgorithm.Model
{
    class ProductEnumProducts
    {
        public Dictionary<StorePosition, Store> PositionDictionary { get; set; }

        public decimal GetCost()
        {
            return GetProductsPrice() + GetShippingCost();
        }

        public void initialize(List<Store> stores, List<StorePosition> positions)
        {
            //TODO
            PositionDictionary.Clear();
            foreach (var product in StorePo)
            {
                PositionDictionary.Add(product, stores[0]);
            }
        }

        private decimal GetProductsPrice()
        {
            return PositionDictionary.Keys.Sum(position => position.Price);
        }

        private decimal GetShippingCost()
        {
            return PositionDictionary.Values.Distinct().Sum(store => store.ShipmentCost);
        }
    }
}
