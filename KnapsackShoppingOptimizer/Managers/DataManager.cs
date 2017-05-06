using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace KnapsackShoppingOptimizer
{
    public class DataManager
    {
        private List<Product> BaseProducts { get; set; }
        private List<Store> Stores { get; set; }
        private List<ShoppingList> ShoppingLists { get; set; }

        private class ModelsWrapper
        {
            public List<Product> BaseProducts { get; set; }
            public List<Store> Stores { get; set; }
            public List<ShoppingList> ShoppingLists { get; set; }
        }

        private void RepairModelsIfNulls()
        {
            if (this.BaseProducts == null)
            {
                this.BaseProducts = new List<Product>();
            }

            if (this.Stores == null)
            {
                this.Stores = new List<Store>();
            }
            else
            {
                for (int i = 0; i < this.Stores.Count; i++)
                {
                    if (this.Stores[i].Positions == null)
                    {
                        this.Stores[i].Positions = new List<StorePosition>();
                    }
                }
            }

            if (this.ShoppingLists == null)
            {
                this.ShoppingLists = new List<ShoppingList>();
            }
        }

        /* OBJECTS MANAGEMENT */
        #region --store management--

        public Store GetStoreByStoreID(Guid objStoreID)
        {
            this.RepairModelsIfNulls();
            return this.Stores.Find(x => x.StoreID == objStoreID);
        }

        public List<Store> GetAllStores()
        {
            this.RepairModelsIfNulls();
            return this.Stores;
        }

        public void CreateStore(Store objStore)
        {
            this.RepairModelsIfNulls();
            this.Stores.Add(objStore);
            this.WriteToFile();                      
        }

        public void EditStore(Store objStore)
        {
            this.RepairModelsIfNulls();
            int nStoreToEditIndex = this.Stores.FindIndex(x => x.StoreID == objStore.StoreID);

            if (nStoreToEditIndex != -1)
            {
                this.Stores[nStoreToEditIndex] = objStore;
            }
            this.WriteToFile();
        }

        private void DeleteStoreAtIndex(int nIndex)
        {
            this.RepairModelsIfNulls();    
            if (nIndex >= 0 && nIndex < this.Stores.Count)
            {
                this.Stores.RemoveAt(nIndex);
            }
            this.WriteToFile();
        }

        public void DeleteStore(Guid objStoreID)
        {
            this.DeleteStoreAtIndex(this.Stores.FindIndex(x => x.StoreID == objStoreID));
        }

        public void DeleteStore(Store objStore)
        {
            this.DeleteStoreAtIndex(this.Stores.FindIndex(x => x.StoreID == objStore.StoreID));
        }

        #endregion

        #region --product management--

        public Product GetProductByID(Guid objProductID)
        {
            this.RepairModelsIfNulls();
            return this.BaseProducts.Find(x => x.ProductID == objProductID);
        }

        public List<Product> GetAllProducts()
        {
            this.RepairModelsIfNulls();
            return this.BaseProducts;
        }

        public void CreateProduct(Product objProduct)
        {
            this.RepairModelsIfNulls();
            this.BaseProducts.Add(objProduct);
            this.WriteToFile();
        }

        public void EditProduct(Product objProduct)
        {
            this.RepairModelsIfNulls();
            int nProductIndexToEdit = this.BaseProducts.FindIndex(x => x.ProductID == objProduct.ProductID);

            if (nProductIndexToEdit != -1)
            {
                this.BaseProducts[nProductIndexToEdit] = objProduct;
            }
            this.WriteToFile();
        }

        public void DeleteProduct(Product objProduct)
        {
            this.RepairModelsIfNulls();
            int nProductIndexToDelete = this.BaseProducts.FindIndex(x => x.ProductID == objProduct.ProductID);

            if (nProductIndexToDelete != -1)
            {
                this.BaseProducts.RemoveAt(nProductIndexToDelete);
            }
            this.WriteToFile();
        }

        #endregion

        #region --positions managament--

        public void AddPositionToStore(Store objStore, StorePosition objStorePosition)
        {
            this.RepairModelsIfNulls();
            int nStoreIndex = this.Stores.FindIndex(x => x.StoreID == objStore.StoreID);

            if (nStoreIndex != -1 && this.Stores[nStoreIndex].Positions.Find(x => x.BaseProduct.ProductID == objStorePosition.BaseProduct.ProductID) == null)
            {
                this.Stores[nStoreIndex].Positions.Add(objStorePosition);
            }
            this.WriteToFile();
        }

        public void DeletePositionFromStore(Store objStore, StorePosition objStorePosition)
        {
            this.RepairModelsIfNulls();
            int nStoreIndexToEdit = this.Stores.FindIndex(x => x.StoreID == objStore.StoreID);

            if (nStoreIndexToEdit != -1)
            {
                int nPositionIndexToDelete = this.Stores[nStoreIndexToEdit].Positions.FindIndex(x => x.BaseProduct.ProductID == objStorePosition.BaseProduct.ProductID);
                if (nPositionIndexToDelete != -1)
                {
                    this.Stores[nStoreIndexToEdit].Positions.RemoveAt(nPositionIndexToDelete);
                }
            }
            this.WriteToFile();
        }

        #endregion

        #region --shopping lists managament--

        public ShoppingList GetShoppingListById(Guid id)
        {
            return ShoppingLists.Find(s => s.ShoppingListID.Equals(id));
        }

        public List<ShoppingList> GetAllShoppingLists()
        {
            this.RepairModelsIfNulls();
            return this.ShoppingLists;            
        }

        public void CreateShoppingList(ShoppingList objShoppingList)
        {
            this.RepairModelsIfNulls();
            this.ShoppingLists.Add(objShoppingList);
            this.WriteToFile();
        }

        public void EditShoppingList(ShoppingList objShoppingList)
        {
            this.RepairModelsIfNulls();
            int nShoppingListIndex = this.ShoppingLists.FindIndex(x => x.ShoppingListID == objShoppingList.ShoppingListID);
            if (nShoppingListIndex != -1)
            {
                this.ShoppingLists[nShoppingListIndex] = objShoppingList;
            }                                                                                                              
            this.WriteToFile();
        }

        private void DeleteShoppingListAtIndex(int nIndex)
        {
            this.RepairModelsIfNulls();
            if (nIndex >= 0 && nIndex < this.ShoppingLists.Count)
            {
                this.ShoppingLists.RemoveAt(nIndex);
                this.WriteToFile();
            }
        }

        public void DeleteShoppingList(Guid objShoppingListID)
        {                           
            this.DeleteShoppingListAtIndex(this.ShoppingLists.FindIndex(x => x.ShoppingListID == objShoppingListID));
        }

        public void DeleteShoppingList(ShoppingList objShoppingList)
        {               
            this.DeleteShoppingListAtIndex(this.ShoppingLists.FindIndex(x => x.ShoppingListID == objShoppingList.ShoppingListID));
        }

        #endregion

        /* FILE OPERATIONS */
        private ModelsWrapper ModWrapper { get; set; }

        private const string mProductsFolderName = "JSON";
        private const string mProductsFilePath = mProductsFolderName + "/products.txt";

        private void PrepareModWrapper()
        {
            this.RepairModelsIfNulls();
            this.ModWrapper = new ModelsWrapper()
            {
                BaseProducts = this.BaseProducts,
                Stores = this.Stores,
                ShoppingLists = this.ShoppingLists
            };
        }

        public void ReadFromFile()
        {
            if (File.Exists(HelperMethods.MapPath(mProductsFilePath)))
            {
                string strJson = File.ReadAllText(HelperMethods.MapPath(mProductsFilePath));

                if (!string.IsNullOrEmpty(strJson))
                {
                    this.ModWrapper = JsonConvert.DeserializeObject<ModelsWrapper>(strJson);
                }
                else
                {
                    this.ModWrapper = new ModelsWrapper();
                }
            }
            else
            {
                this.ModWrapper = new ModelsWrapper();
            }

            this.Stores = this.ModWrapper.Stores;
            this.BaseProducts = this.ModWrapper.BaseProducts;
            this.ShoppingLists = this.ModWrapper.ShoppingLists;

            this.RepairModelsIfNulls();
        }

        public void WriteToFile()
        {
            this.PrepareModWrapper();
            if (!Directory.Exists(HelperMethods.MapPath(mProductsFolderName)))
            {
                Directory.CreateDirectory(HelperMethods.MapPath(mProductsFolderName));
            }

            File.WriteAllText(HelperMethods.MapPath(mProductsFilePath), JsonConvert.SerializeObject(this.ModWrapper));
        }
    }
}
