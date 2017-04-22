using KnapsackShoppingOptimizer;

namespace KnapsackOptimizer.ShomEnumAlgorithm.Model
{
    class ShopEnumPosition
    {
        public Store Store { get; set; }
        public StorePosition StorePosition { get; set; }
        public bool Found { get; set; }
    }
}
