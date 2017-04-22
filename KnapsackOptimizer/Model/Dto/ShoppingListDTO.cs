using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackOptimizer.Model.Dto
{
    public class ShoppingListDto
    {
        public Guid ShoppingListID { get; set; }
        public string Name { get; set; }

        public Dictionary<Guid, int> ProductIdToAmountDictionary { get; set; }
    }
}
