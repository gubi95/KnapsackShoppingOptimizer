using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.ShopEnum.Model;

namespace KnapsackOptimizer.Model
{
    public class OptimizedShoppingList
    {
        public List<ShopEnumPosition> Products { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
