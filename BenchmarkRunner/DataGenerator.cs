using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using KnapsackOptimizer.Model.Dto;

namespace BenchmarkRunner
{
    class DataGenerator
    {
        private const int AMOUNT_LIMIT = 10;
        private const int PRICE_LIMIT = 100000;
        private const int SHIPMENT_COST_LIMIT = 10000;

        public static BenchData doGenerate(int shopCount, int productCount, int listLength)
        {
            var random = new Random();
            var products = new List<ProductDto>();
            var stores = new List<StoreDto>();


            for (int i = 0; i < productCount; i++)
            {
                var productId = Guid.NewGuid();
                var productName = $"Product{i}";

                products.Add(new ProductDto {Name = productName, ProductID = productId});
            }

            for (int i = 0; i < shopCount; i++)
            {
                var storeName = $"Shop {i}";
                var storeId = Guid.NewGuid();
                var shippingCost = random.Next(0, SHIPMENT_COST_LIMIT);
                var storePositions = new List<StorePositionDto>();
                products.ForEach(product => storePositions.Add(new StorePositionDto
                {
                    Amount = random.Next(1, AMOUNT_LIMIT),
                    Price = random.Next(0, PRICE_LIMIT) / 100,
                    BaseProduct = new ProductDto
                    {
                        Name = product.Name,
                        ProductID = product.ProductID
                    }
                }));
                stores.Add(new StoreDto
                {
                    Name = storeName,
                    ShipmentCost = shippingCost,
                    StoreID = storeId,
                    Positions = storePositions
                });
            }

            var shoppingList = new Dictionary<Guid, int>();
            for (int i = 0; i < listLength; i++)
            {
                shoppingList.Add(products[i].ProductID, random.Next(1, AMOUNT_LIMIT));
            }

            var benchData = new BenchData
            {
                ShoppingList = shoppingList,
                Stores = stores
            };

            return benchData;
        }
    }
}
