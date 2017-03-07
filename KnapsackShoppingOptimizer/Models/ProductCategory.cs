using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class ProductCategory
    {
        public Guid ProductCategoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
