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
        private static readonly int[] _shopCounts = { 8, 12, 20, 32, 48, 72, 100};
        private static readonly int[] _productCounts = {25};
        private static readonly float[] _shoppingListLengthRatios = {0.5f};
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
                            Console.Write($"{m} [");
                            var benchData = DataGenerator.doGenerate(shopCount, productCount, shoppingListLength);
                            Console.Write("g");
                            shopEnumTime = BenchShopEnum(benchData);
                            Console.Write("s");
                            productEnumTime = BenchProductEnum(benchData);
                            Console.Write("p");

                            using (var streamWriter = File.AppendText(_path))
                            {
                                streamWriter.WriteLine($"{shopCount};{productCount};{shoppingListLength};{shopEnumTime};{productEnumTime}");
                            }
                        }
                        Console.Write(Environment.NewLine);
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
