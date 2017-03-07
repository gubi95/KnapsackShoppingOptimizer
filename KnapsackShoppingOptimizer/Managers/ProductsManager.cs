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
    public class ProductsManager
    {
        public ProductsKnapsackWrapper ProductsKnapsackWrapper { get; set; }

        private const string mProductsFolderName = "JSON";
        private const string mProductsFilePath = mProductsFolderName + "/products.txt";

        public void ReadFromFile()
        {
            if (File.Exists(HelperMethods.MapPath(mProductsFilePath)))
            {
                string strJson = File.ReadAllText(HelperMethods.MapPath(mProductsFilePath));

                if (!string.IsNullOrEmpty(strJson))
                {
                    this.ProductsKnapsackWrapper = new ProductsKnapsackWrapper();
                }
                else
                {
                    this.ProductsKnapsackWrapper = new ProductsKnapsackWrapper();
                }
            }
            else
            {
                this.ProductsKnapsackWrapper = new ProductsKnapsackWrapper();
            }
        }

        public void WriteToFile()
        {
            if (!Directory.Exists(HelperMethods.MapPath(mProductsFolderName)))
            {
                Directory.CreateDirectory(HelperMethods.MapPath(mProductsFolderName));
            }

            File.WriteAllText(HelperMethods.MapPath(mProductsFilePath), JsonConvert.SerializeObject(this.ProductsKnapsackWrapper));
        }
    }
}
