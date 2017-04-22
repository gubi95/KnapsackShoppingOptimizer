using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model;
using KnapsackOptimizer;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.Controller
{
    public static class OptimizationController
    {
        public static Dictionary<Guid, Guid> Optimize(List<StoreDto> stores, Dictionary<Guid, int> shoppingList, Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.ShopEnum:
                    return null;
                    break;
                case Algorithm.ProductEnum:
                    return null;
                    break;
                default:
                    return null;
            }
        }
    }
}
