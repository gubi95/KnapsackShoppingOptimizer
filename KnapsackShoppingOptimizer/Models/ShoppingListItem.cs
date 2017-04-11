using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer.Models
{
    class ShoppingListItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingListItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
