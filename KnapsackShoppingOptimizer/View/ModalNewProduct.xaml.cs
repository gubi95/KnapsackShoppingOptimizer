using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KnapsackShoppingOptimizer.Managers;
using System.Collections;

namespace KnapsackShoppingOptimizer.View
{
    /// <summary>
    /// Interaction logic for ModalNewProduct.xaml
    /// </summary>
    public partial class ModalNewProduct : Window
    {
        private class ProductsDataGridItem
        {
            public string ShopName { get; set; }
            public string Price { get; set; }            
        }

        public ModalNewProduct()
        {
            InitializeComponent();
            BindShops();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        private void btnSaveNewProduct_Click(object sender, RoutedEventArgs e)
        {
            string strProductName = ("" + txtProductName.Text).Trim();
            if (!ValidationManager.IsNotEmptyValueValid(strProductName))
            {
                MessageBox.Show("Nazwa produktu nie może być pusta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<Product> listProduct = HelperMethods.DataManager.GetAllProducts();

            if (listProduct.Find(x => ("" + x.Name).ToLower().Trim().Equals(strProductName.ToLower())) != null)
            {
                MessageBox.Show("Produkt z podaną nazwą już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product objNewProduct = new Product() { ProductID = Guid.NewGuid(), Name = strProductName };
            HelperMethods.DataManager.CreateProduct(objNewProduct);

            List<Store> listStore = HelperMethods.DataManager.GetAllStores();

            List<DataGridRow> listDataGridRow = HelperMethods.GetDataGridRows(gridProducts).ToList();

            foreach (DataGridRow objDataGridRow in listDataGridRow)
            {
                ProductsDataGridItem objProductsDataGridItem = (ProductsDataGridItem)objDataGridRow.Item;

                Store objStoreToEdit = listStore.Find(x => x.Name == objProductsDataGridItem.ShopName);

                if (objStoreToEdit != null)
                {
                    objStoreToEdit.Positions.Add(new StorePosition()
                    {
                        BaseProduct = objNewProduct,
                        Price = decimal.Parse(objProductsDataGridItem.Price.Replace(",", "."))
                    });

                    HelperMethods.DataManager.EditStore(objStoreToEdit);
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {                
            this.Close();
        }

        private void BindShops()
        {
            List<Store> listStore = HelperMethods.DataManager.GetAllStores();
            List<ProductsDataGridItem> listProductsDataGridItem = new List<ProductsDataGridItem>();

            foreach (Store objStore in listStore)
            {
                listProductsDataGridItem.Add(new ProductsDataGridItem()
                {
                    ShopName = objStore.Name,
                    Price = "0,00",                    
                });
            }

            gridProducts.ItemsSource = listProductsDataGridItem;
        }

        private void gridProducts_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridBoundColumn objDataGridBoundColumn = e.Column as DataGridBoundColumn;
                if (objDataGridBoundColumn != null)
                {
                    string strBindingName = (objDataGridBoundColumn.Binding as Binding).Path.Path;
                    if (strBindingName == "Price")
                    {
                        int nRowIndex = e.Row.GetIndex();
                        TextBox objTextBox = e.EditingElement as TextBox;
                        string strNewPriceValue = "" + objTextBox.Text;

                        if (!Managers.ValidationManager.IsCashValueValid(("" + strNewPriceValue).Replace(",", ".")))
                        {
                            MessageBox.Show("Cena powinna być w formacie XX..XX,XX!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                            objTextBox.Text = "0,00";
                        }
                    }
                }
            }
        }
    }
}
