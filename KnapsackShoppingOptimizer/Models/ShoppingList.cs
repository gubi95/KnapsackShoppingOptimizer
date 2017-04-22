using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class ShoppingList
    {
        public Guid ShoppingListID { get; set; }
        public string Name { get; set; }

        public Dictionary<Guid, int> ProductIdToAmountDictionary { get; set; }
    }
}
