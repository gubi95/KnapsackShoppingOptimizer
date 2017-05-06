using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ProductEnum.Model
{
    internal class ProductStorePair
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public StoreDto Store { get; set; }

        public StorePositionDto StorePosition { get; set; }
        public ProductStorePair()
        {
        }

        public ProductStorePair(Guid productId, int amount, StoreDto store, StorePositionDto storePosition)
        {
            ProductId = productId;
            Amount = amount;
            Store = store;
            StorePosition = storePosition;
        }
    }
}
