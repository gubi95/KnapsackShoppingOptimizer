using System;
using System.Collections.Generic;
using System.Diagnostics;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackOptimizer.ProductEnum.Logic
{
    public class ProductEnumAlgorithm
    {
        private AlgorithmShoppingList BestSolution;
        public OptimizedShoppingList Run(Dictionary<Guid, int> shoppingList, List<StoreDto> stores)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BestSolution = new AlgorithmShoppingList(shoppingList);    
            var shopEnumProducts = new AlgorithmShoppingList(shoppingList);
            Permutate(shopEnumProducts, stores, 0);
            stopwatch.Stop();
            return BestSolution.ToOptimizedShoppingList(stopwatch.Elapsed);
        }

        private void Permutate(AlgorithmShoppingList list, List<StoreDto> stores, int itemIndex)
        {
            if (itemIndex < list.Products.Count)
            {
                foreach (var store in stores)
                {
                    var storePosition = store.findStorePositionById(list.Products[itemIndex].ProductId);
                    if (storePosition.Amount < list.Products[itemIndex].Amount) continue;
                    list.Products[itemIndex].Price = storePosition.Price;
                    list.Products[itemIndex].Store = store;

                    Permutate(list, stores, itemIndex + 1);
                }
            }
            else
            {
                list.ComputeCost();
                if (list.Cost >= BestSolution.Cost) return;
                BestSolution.Products = list.Products;
                BestSolution.Cost = list.Cost;
            }
        }
    }
}
