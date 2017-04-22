using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ProductEnumAlgorithm.Model;

namespace KnapsackOptimizer.ProductEnumAlgorithm.Logic
{
    static class ProductEnumAlgorithm
    {
        public static ProductEnumProducts Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
         
            var productEnumProducts = new ProductEnumProducts();
            foreach (var product in shoppingList)
            {
                
            }

            return productEnumProducts;
        }
    }
}
