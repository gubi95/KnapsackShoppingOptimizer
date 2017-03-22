using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer
{
    public class Store
    {           
        public Guid StoreID { get; set; }
        public string Name { get; set; }
        public List<StorePosition> Positions { get; set; }
        public decimal ShipmentCost { get; set; }

        public string ShipmentCostFormatted
        {
            get
            {
                return this.ShipmentCost.ToString("C");
            }
        }
    }
}
