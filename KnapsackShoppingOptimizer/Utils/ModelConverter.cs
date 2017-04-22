using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model;
using KnapsackOptimizer.Model.Dto;

namespace KnapsackShoppingOptimizer.Utils
{
    public static class ModelConverter
    {
        public static List<StoreDto> getStoreDtoList(List<Store> stores)
        {
            var storeDtoList = new List<StoreDto>();
            stores.ForEach(s =>
            {
                storeDtoList.Add(GetStoreDto(s));
            });

            return storeDtoList;
        }

        public static StoreDto GetStoreDto(Store store)
        {
            var storeDto = new StoreDto
            {
                ShipmentCost = store.ShipmentCost,
                Name = store.Name,
                StoreID = store.StoreID
            };
            store.Positions.ForEach(p =>
            {
                storeDto.Positions.Add(GetStorePositionDto(p));
            });
            return storeDto;
        }

        public static StorePositionDto GetStorePositionDto(StorePosition sp)
        {
            return new StorePositionDto
            {
                BaseProduct = GetProductDto(sp.BaseProduct),
                Price = sp.Price,
                Amount = sp.Amount
            };
        }

        public static ProductDto GetProductDto(Product p)
        {
            return new ProductDto
            {
                Name = p.Name,
                ProductID = p.ProductID
            };
        }

    }


}
