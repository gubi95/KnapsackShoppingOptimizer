using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Store Store { get; set; }

        public string PriceFormatted
        {
            get
            {
                return this.Price.ToString("C");
            }        
        }
    }
}
