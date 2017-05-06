using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model;
using KnapsackOptimizer;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ProductEnum.Logic;
using KnapsackOptimizer.ShopEnum.Logic;

namespace KnapsackOptimizer.Controller
{
    public static class OptimizationController
    {
        public static OptimizedShoppingList Optimize(List<StoreDto> stores, Dictionary<Guid, int> shoppingList, Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.ShopEnum:
                    return new ShopEnumAlgorithm().Run(shoppingList, stores);
                case Algorithm.ProductEnum:
                    return new ProductEnumAlgorithm().Run(shoppingList, stores);
                default:
                    return null;
            }
        }
    }
}
