using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model.Dto;

namespace BenchmarkRunner
{
    internal class BenchData
    {
        public Dictionary<Guid, int> ShoppingList { get; set; }
        public List<StoreDto> Stores { get; set; }
    }
}
