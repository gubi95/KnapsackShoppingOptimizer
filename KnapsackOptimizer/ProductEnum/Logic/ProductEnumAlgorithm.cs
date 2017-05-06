using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ProductEnum.Model;

namespace KnapsackOptimizer.ProductEnum.Logic
{
    public static class ProductEnumAlgorithm
    {
        public static OptimizedShoppingList Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
            var productStorePairs = InitializeProductStoreList(shoppingList, stores);
            var bestPrice = ComputePriceSum(productStorePairs);
            var bestSet = InitializeShoppingList();
            for (var i = shoppingList.Count-1; i >= 0; i--)
            {
                for (var j = i; j < shoppingList.Count; j++)
                {
                    for (int k = 1; k < stores.Count; k++)
                    {
                        var storePosition = stores[k].findStorePositionById(productStorePairs[j].ProductId);
                        if (storePosition.Amount < productStorePairs[j].Amount)
                        {
                            continue;
                        }
                        productStorePairs[j].StorePosition = storePosition;
                        productStorePairs[j].Store = stores[k];
                    }
                }
            }

            return null;
        }

        private static object InitializeShoppingList(List<ProductStorePair> products)
        {
            List<>
            throw new NotImplementedException();
        }

        private static List<ProductStorePair> InitializeProductStoreList(Dictionary<Guid, int> shoppingList,
            IReadOnlyList<StoreDto> stores)
        {
            var list = new List<ProductStorePair>();
            foreach (var keyValuePair in shoppingList)
            {
                list.Add(
                    new ProductStorePair(
                        keyValuePair.Key,
                        keyValuePair.Value, 
                        stores[0], 
                        stores[0].findStorePositionById(keyValuePair.Key)));
            }
            return list;
        }

        private static decimal ComputePriceSum(IEnumerable<ProductStorePair> list)
        {
            decimal sum = 0;
            foreach (var productStorePair in list)
            {
                sum += productStorePair.StorePosition.Price;
            }
            return sum;
        }
    }
}
