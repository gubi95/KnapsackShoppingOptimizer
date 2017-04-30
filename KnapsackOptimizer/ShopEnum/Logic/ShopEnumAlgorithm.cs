using System;
using System.Collections.Generic;
using System.Diagnostics;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ShopEnum.Model;

namespace KnapsackOptimizer.ShopEnum.Logic
{
    class ShopEnumAlgorithm
    {
        public OptimizedShoppingList Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var bestShoppingList = new ShopEnumProducts(shoppingList);
            bestShoppingList.ComputeCost();
            var currentShoppingList = new ShopEnumProducts(shoppingList);

            var subsetMask = new int[stores.Count];
            subsetMask[0] = -1;

            while (GetNextPermutation(subsetMask) != 1)
            {
                for (var i = 0; i < stores.Count; i++)
                {
                    if (subsetMask[i] == 0) continue;
                    currentShoppingList.ShopEnumPositions.ForEach(shopEnumPosition =>
                    {
                        stores[i].Positions.ForEach(position =>
                        {
                            if (position.BaseProduct.ProductID != shopEnumPosition.ProductId) return;
                            if (position.Price >= shopEnumPosition.Price) return;
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
            return bestShoppingList.ToOptimizedShoppingList(stopwatch.Elapsed);
        }
        private static int GetNextPermutation(int[] subsetMask)
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

