﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class StorePosition
    {
        public Product BaseProduct { get; set; }    
            
        public decimal Price { get; set; }
        public int Quantity { get; set; }

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
