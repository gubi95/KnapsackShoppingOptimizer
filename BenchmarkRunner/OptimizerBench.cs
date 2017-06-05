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
        private static readonly int[] _shopCounts = { 8, 12, 15, 20};
        private static readonly int[] _productCounts = {8, 16, 32};
        private static readonly float[] _shoppingListLengthRatios = { 0.2f, 0.5f, 0.8f};
        private const int _repetitions = 3;

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
                    foreach (var shoppingListLengthRatio in _shoppingListLengthRatios)
                    {
                        var shoppingListLength = (int) (productCount * shoppingListLengthRatio);
                        double shopEnumTime = 0;
                        double productEnumTime = 0;
                        Console.Write($"Shop count: {shopCount} | Prid count: {productCount}  | Shopping list: { shoppingListLength} |  Repetition: ");
                        for (var m = 0; m < _repetitions; m++)
                        {
                            Console.Write($"{m} ");
                            var benchData = DataGenerator.doGenerate(shopCount, productCount, shoppingListLength);
                            shopEnumTime += BenchShopEnum(benchData);
                            productEnumTime += BenchProductEnum(benchData);
                        }
                        Console.Write(Environment.NewLine);
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
