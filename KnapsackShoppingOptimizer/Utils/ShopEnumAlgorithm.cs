using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using KnapsackShoppingOptimizer.Models.AlgorithmModels;

namespace KnapsackShoppingOptimizer.Utils
{
    class ShopEnumAlgorithm
    {

        
        

        public static List<ShopEnumResult> Run(List<Product> shoppingList)
        {
            var optimizedShoppingList = InitializeShoppingList(shoppingList);
            var stores = HelperMethods.DataManager.GetAllStores();
            var subsetMask = new int[stores.Count];
            subsetMask[0] = -1;

            while (GetNextPermutation(subsetMask) != 1)
            {
                for (var i = 0; i < stores.Count; i++)
                {
                    if(subsetMask[i] == 0) continue;
                    foreach (var shopEnumResult in optimizedShoppingList)
                    {
                        stores[i].Positions.ForEach(position =>
                        {
                            if (position.BaseProduct != shopEnumResult.StorePosition.BaseProduct) return;
                            if (position.Price >= shopEnumResult.StorePosition.Price) return;
                            shopEnumResult.Store = stores[i];
                            shopEnumResult.StorePosition = position;
                        });
                    }
                }
            }
            return optimizedShoppingList;
        }

        private static List<ShopEnumResult> InitializeShoppingList(List<Product> shoppingList)
        {
            var newShoppingList = new List<ShopEnumResult>();
            foreach (var product in shoppingList)
            {
                var newShopEnumResult = new ShopEnumResult();
                newShopEnumResult.StorePosition.BaseProduct = product;
                newShopEnumResult.StorePosition.Price = decimal.MaxValue;
                newShoppingList.Add(newShopEnumResult);
            }
            return newShoppingList;
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
