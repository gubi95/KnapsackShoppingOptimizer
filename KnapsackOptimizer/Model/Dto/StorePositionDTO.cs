using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackOptimizer.Model.Dto
{
    public class StorePositionDto
    {
        public ProductDto BaseProduct { get; set; }    
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public string Name
        {
            get
            {
                return BaseProduct.Name;
            }
        }


        public string PriceFormatted
        {
            get
            {
                return this.Price.ToString("C");
            }
        }
    }
}
