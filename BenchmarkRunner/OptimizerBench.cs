using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.ProductEnum.Logic;

namespace BenchmarkRunner
{
    class OptimizerBench
    {
        private static readonly string _path = "output.csv";
        private static readonly int[] _shopCounts = {10, 100, 300, 500, 700};
        private static readonly int[] _productCounts = {50, 200};
        private static readonly int[] _shoppingListLengths = {10, 50};
        private const int _repetitions = 20;

        static void Main(string[] args)
        {

            using (var streamWriter = File.CreateText(_path))
            {
                streamWriter.WriteLine("shopCount;productCount;listLength;shopEnum;productEnum");
            } 

            foreach (var shopCount in _shopCounts)
            {
                foreach (var productCount in _productCounts)
                {
                    foreach (var shoppingListLength in _shoppingListLengths)
                    {
                        double shopEnumTime = 0;
                        double productEnumTime = 0;
                        for (var m = 0; m < _repetitions; m++)
                        {
                            var benchData = DataGenerator.doGenerate(shopCount, productCount, shoppingListLength);
                            //shopEnumTime += BenchShopEnum(benchData);
                            //productEnumTime += BenchProductEnum(benchData);
                        }
                        using (var streamWriter = File.AppendText(_path))
                        {
                            streamWriter.WriteLine($"{shopCount};{productCount};{shoppingListLength};{shopEnumTime / _repetitions};{productEnumTime / _repetitions}");
                        }
                    }
                }
            }
        }


        private static double BenchShopEnum(BenchData benchData)
        {
            var result = new ProductEnumAlgorithm().Run(benchData.ShoppingList, benchData.Stores);
            return result.TimeElapsed.TotalMilliseconds;
        }

        private static double BenchProductEnum(BenchData benchData)
        {
            var result = new ProductEnumAlgorithm().Run(benchData.ShoppingList, benchData.Stores);   
            return result.TimeElapsed.TotalMilliseconds;
        }
    }
}
