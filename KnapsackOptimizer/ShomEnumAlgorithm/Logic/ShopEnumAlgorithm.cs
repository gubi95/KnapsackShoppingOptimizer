using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.ShopEnumAlgorithm.Model;
using KnapsackShoppingOptimizer;

namespace KnapsackOptimizer.ShomEnumAlgorithm.Logic
{
    class ShopEnumAlgorithm
    {
        public static ShopEnumProducts Run(List<Product> shoppingList)
        {
            var bestShoppingList = new ShopEnumProducts(shoppingList);
            var currentShoppingList = new ShopEnumProducts(shoppingList);
            var stores = HelperMethods.DataManager.GetAllStores();
            var subsetMask = new int[stores.Count];
            subsetMask[0] = -1;

            while (GetNextPermutation(subsetMask) != 1)
            {
                for (var i = 0; i < stores.Count; i++)
                {
                    if (subsetMask[i] == 0) continue;
                    foreach (var shopEnumPosition in currentShoppingList.ShopEnumPositions)
                    {
                        stores[i].Positions.ForEach(position =>
                        {
                            if (position.BaseProduct != shopEnumPosition.StorePosition.BaseProduct) return;
                            if (position.Price >= shopEnumPosition.StorePosition.Price) return;
                            shopEnumPosition.Store = stores[i];
                            shopEnumPosition.StorePosition = position;
                        });
                    }
                }
                if (currentShoppingList.GetShoppingListValue() < bestShoppingList.GetShoppingListValue())
                {
                    var temp = currentShoppingList;
                    currentShoppingList = bestShoppingList;
                    bestShoppingList = temp;
                }
                currentShoppingList.Clear();
            }
            return bestShoppingList;
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

