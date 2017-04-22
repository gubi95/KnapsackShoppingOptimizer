using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ShomEnumAlgorithm.Model
{
    class ShopEnumPosition
    {
        public StoreDto Store { get; set; }
        public StorePositionDto StorePosition { get; set; }
        public bool Found { get; set; }
    }
}
