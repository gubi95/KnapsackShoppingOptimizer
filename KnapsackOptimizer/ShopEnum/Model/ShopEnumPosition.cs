using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ShopEnum.Model
{
    class ShopEnumPosition
    {
        public StoreDto Store { get; set; }
        public StorePositionDto StorePosition { get; set; }
        public bool Found { get; set; }
    }
}
