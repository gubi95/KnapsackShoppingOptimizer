using System;
using System.Collections.Generic;

namespace KnapsackOptimizer.Model.Dto
{
    public class StoreDto
    {
        
        public Guid StoreID { get; set; }
        public string Name { get; set; }
        public List<StorePositionDto> Positions { get; set; }
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
