using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackOptimizer.Model
{
    public class OptimizedShoppingList
    {
        public Dictionary<Guid, Guid> ProductIdToStoreIDictionary { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
