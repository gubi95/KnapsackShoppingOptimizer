using System.Collections.Generic;
using System.Linq;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ProductEnum.Model
{
    class ProductEnumProducts
    {
        public Dictionary<StorePositionDto, StoreDto> PositionDictionary { get; set; }

        public decimal GetCost()
        {
            return GetProductsPrice() + GetShippingCost();
        }

        public void initialize(List<StoreDto> stores, List<StorePositionDto> positions)
        {
            //TODO
            PositionDictionary.Clear();
          //  foreach (var product in StorePosition)
            {
              //  PositionDictionary.Add(product, stores[0]);
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
