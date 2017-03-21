using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class ProductsKnapsackWrapper
    {
        public decimal BestProfit { get; set; }
        public List<Product> ProductsToBuy { get; set; }
        public List<Store> ProductCategories { get; set; }        
    }
}
