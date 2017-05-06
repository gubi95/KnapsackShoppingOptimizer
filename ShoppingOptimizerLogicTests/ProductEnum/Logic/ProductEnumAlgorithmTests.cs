using System;
using System.Collections.Generic;
using KnapsackOptimizer.Model.Dto;
using KnapsackOptimizer.ProductEnum.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingOptimizerLogicTests.ProductEnum.Logic
{
    [TestClass]
    public class ProductEnumAlgorithmTests
    {
        [TestMethod]
        public void Run_WithValidData_ValidOutput()
        {
            //given
            var product1Id = Guid.NewGuid();
            var product1Amount = 5;
            var product1Name = "Product1Name";

            var product2Id = Guid.NewGuid();
            var product2Amount = 5;
            var product2Name = "Product1Name";

            var shop1Id = Guid.NewGuid();
            var shop1ShipmentCost = new decimal(10);

            var shop2Id = Guid.NewGuid();
            var shop2ShipmentCost = new decimal(20);

            var store1Dto = new StoreDto
            {
                ShipmentCost = shop1ShipmentCost,
                StoreID = shop1Id,
                Name = "Store1",
                Positions = new List<StorePositionDto>
                {
                    new StorePositionDto
                    {
                        Amount = 10,
                        Price = new decimal(25),
                        BaseProduct = new ProductDto
                        {
                            Name = product1Name,
                            ProductID = product1Id
                        }
                    },
                    new StorePositionDto
                    {
                        Amount = 10,
                        Price = new decimal(35),
                        BaseProduct = new ProductDto
                        {
                            Name = product2Name,
                            ProductID = product2Id
                        }
                    }
                }
            };

            var store2Dto = new StoreDto
            {
                ShipmentCost = shop2ShipmentCost,
                StoreID = shop2Id,
                Name = "Store2",
                Positions = new List<StorePositionDto>
                {
                    new StorePositionDto
                    {
                        Amount = 10,
                        Price = new decimal(5),
                        BaseProduct = new ProductDto
                        {
                            Name = product1Name,
                            ProductID = product1Id
                        }
                    },
                    new StorePositionDto
                    {
                        Amount = 10,
                        Price = new decimal(60),
                        BaseProduct = new ProductDto
                        {
                            Name = product2Name,
                            ProductID = product2Id
                        }
                    }
                }
            };


            var dictionary = new Dictionary<Guid, int>();
            dictionary.Add(product1Id, product1Amount);
            dictionary.Add(product2Id, product2Amount);

            var stores = new List<StoreDto> {store1Dto, store2Dto};

            //when
            var result = new ProductEnumAlgorithm().Run(dictionary, stores);

            //then
            Assert.AreEqual(result.TotalPrice, new decimal(70));
            Assert.AreEqual(result.Products.Count, 2);
            Assert.IsNotNull(result.Products[1].Store);
            Assert.AreNotEqual(result.Products[0].Price, Decimal.MaxValue);
        }
    }
}