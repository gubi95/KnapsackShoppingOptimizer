using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ShopEnum.Logic
{
    public class ShopEnumAlgorithm
    {
        public OptimizedShoppingList Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var bestShoppingList = new AlgorithmShoppingList(shoppingList);
            bestShoppingList.ComputeCost();
            var currentShoppingList = new AlgorithmShoppingList(shoppingList);

            var subsetMask = new int[stores.Count];
            subsetMask[0] = -1;

            while (GetNextPermutation(subsetMask) != 1)
            {
                for (var i = 0; i < stores.Count; i++)
                {
                    if (subsetMask[i] == 0) continue;
                    currentShoppingList.Products.ForEach(shopEnumPosition =>
                    {
                        stores[i].Positions.ForEach(position =>
                        {
                            if (position.BaseProduct.ProductID != shopEnumPosition.ProductId) return;
                            if (position.Price >= shopEnumPosition.Price) return;
                            if (position.Amount < shopEnumPosition.Amount) return;
                            shopEnumPosition.Store = stores[i];
                            shopEnumPosition.ProductId = position.BaseProduct.ProductID;
                            shopEnumPosition.Price = position.Price;
                        });
                    });
                }
                currentShoppingList.ComputeCost();
                if (currentShoppingList.Cost < bestShoppingList.Cost)
                {
                    var temp = currentShoppingList;
                    currentShoppingList = bestShoppingList;
                    bestShoppingList = temp;
                }
                currentShoppingList.Clear();
            }
            stopwatch.Stop();
            var stopwatchElapsed = stopwatch.Elapsed;
            stopwatch = null;
            return bestShoppingList.ToOptimizedShoppingList(stopwatchElapsed);
        }
        private int GetNextPermutation(int[] subsetMask)
        {
            int carry = 1;
            int index = 0;
            while (carry == 1 && index < subsetMask.Length)
            {
                subsetMask[index] += 1;
                carry = subsetMask[index] / 2;
                subsetMask[index] %= 2;
                index++;
            }

            return carry;
        }
    }
}

