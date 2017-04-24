using System;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ShopEnum.Model
{
    internal class ShopEnumPosition
    {
        public StoreDto Store { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
