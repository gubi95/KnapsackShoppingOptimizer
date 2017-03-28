using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer.Models.AlgorithmModels
{
    class ShopEnumPosition
    {
        public Store Store { get; set; }
        public StorePosition StorePosition { get; set; }
        public bool Found { get; set; }
        
    }
}
