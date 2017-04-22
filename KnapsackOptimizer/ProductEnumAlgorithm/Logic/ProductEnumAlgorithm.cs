using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.ProductEnumAlgorithm.Model;
using KnapsackShoppingOptimizer;

namespace KnapsackOptimizer.ProductEnumAlgorithm.Logic
{
    class ProductEnumAlgorithm
    {
        public ProductEnumProducts Run(List<Product> shoppingList)
        {
            var stores = HelperMethods.DataManager.GetAllStores();
         
            var productEnumProducts = new ProductEnumProducts();
            foreach (var product in shoppingList)
            {
                
            }

            return productEnumProducts;
        }
    }
}
