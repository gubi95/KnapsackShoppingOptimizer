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
using MessageBox = System.Windows.MessageBox;

namespace KnapsackShoppingOptimizer.View
{
    public partial class ModalNewShoppingList : Window
    {
        private class ProductDataGridItem
        {
            public bool Selected { get; set; }
            public string ProductName { get; set; }
            public string Quantity { get; set; }            
        }

        public ModalNewShoppingList()
        {
            InitializeComponent();
            BindDataGrid();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        private void btnSaveNeShoppingList_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShoppingListName.Text))
            {
                MessageBox.Show("Nieprawidłowa nazwa listy zakupowej!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<DataGridRow> listDataGridRow = HelperMethods.GetDataGridRows(gridSelectedProducts).ToList();
            List<ProductDataGridItem> listProductDataGridItemSelected = new List<ProductDataGridItem>();

            foreach (DataGridRow objDataGridRow in listDataGridRow)
            {
                ProductDataGridItem objProductsDataGridItem = (ProductDataGridItem)objDataGridRow.Item;
                if (objProductsDataGridItem.Selected)
                {
                    listProductDataGridItemSelected.Add(objProductsDataGridItem);
                }
            }

            if (listProductDataGridItemSelected.Count == 0)
            {
                MessageBox.Show("Lista zakupowa musi się składać z przynajmniej jednego produktu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Dictionary<Guid, int> productIdToAmountDictionary = new Dictionary<Guid, int>();
            List<Product> listProduct = HelperMethods.DataManager.GetAllProducts();


            foreach (ProductDataGridItem objProductDataGridItem in listProductDataGridItemSelected)
            {
                Product objProduct = listProduct.Find(x => x.Name.Equals(objProductDataGridItem.ProductName));
                int nAmount = -1;
                bool amountParsingOk = int.TryParse(objProductDataGridItem.Quantity, out nAmount);

                if (objProduct != null && amountParsingOk && nAmount > 0)
                {
                    productIdToAmountDictionary.Add(objProduct.ProductID, nAmount);                    
                }
            }

            ShoppingList objShoppingList = new ShoppingList()
            {
                ShoppingListID = Guid.NewGuid(),
                Name = ("" + txtShoppingListName.Text).Trim(),
                ProductIdToAmountDictionary = productIdToAmountDictionary
            };

            HelperMethods.DataManager.CreateShoppingList(objShoppingList);

            if (this.Owner is MainWindow)
            {
                ((MainWindow)this.Owner).BindDDLShoppingLists();
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {                
            this.Close();
        }

        public void BindDataGrid()
        {
            List<Product> listProduct = HelperMethods.DataManager.GetAllProducts();
            List<ProductDataGridItem> listProductDataGridItem = new List<ProductDataGridItem>();

            foreach (Product objProduct in listProduct)
            {
                listProductDataGridItem.Add(new ProductDataGridItem()
                {
                    ProductName = objProduct.Name,
                    Quantity = "1",
                    Selected = false
                });
            }

            gridSelectedProducts.ItemsSource = listProductDataGridItem;
        }

        private void gridSelectedProducts_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridBoundColumn objDataGridBoundColumn = e.Column as DataGridBoundColumn;
                if (objDataGridBoundColumn != null)
                {
                    string strBindingName = (objDataGridBoundColumn.Binding as Binding).Path.Path;
                    if (strBindingName == "Quantity")
                    {
                        int nRowIndex = e.Row.GetIndex();
                        TextBox objTextBox = e.EditingElement as TextBox;
                        string strNewQuantity = "" + objTextBox.Text;

                        int nNewQuantity = -1;
                        if (!int.TryParse(strNewQuantity, out nNewQuantity) || nNewQuantity <= 0)
                        {
                            MessageBox.Show("Nieprawidłowa ilość!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                            objTextBox.Text = "1";
                        }
                    }
                }
            }
        }
    }
}