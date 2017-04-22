using System;
using System.Collections.Generic;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ProductEnum.Model;

namespace KnapsackOptimizer.ProductEnum.Logic
{
    public static class ProductEnumAlgorithm
    {
        public static OptimizedShoppingList Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
         
            var productEnumProducts = new ProductEnumProducts();
            foreach (var product in shoppingList)
            {
                
            }

            return null;
        }
    }
}
