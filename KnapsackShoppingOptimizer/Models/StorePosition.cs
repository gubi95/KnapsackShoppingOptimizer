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
