using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KnapsackShoppingOptimizer.View;
using KnapsackOptimizer.Model;

namespace KnapsackShoppingOptimizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShoppingList _shoppingList;

        private class ProductsDataGridItem
        {
            public string ProductName { get; set; }
            public string Price { get; set; }
        }

        private class ShoppingListDataGridItem
        {
            public string ProductName { get; set; }
            public string Amount { get; set; }
        }

        public MainWindow()
        {
            var culture = new CultureInfo("pl-PL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            _shoppingList = new ShoppingList();
            InitializeComponent();
            this.Loaded += FormLoad;
        }

        private void FormLoad(object sender, RoutedEventArgs e)
        {
            // this should be called only here and only once
            HelperMethods.DataManager.ReadFromFile();
            BindDDLShops();
            BindDDLShoppingLists();
            dgShoppingList.DataContext = this;
        }  

        private void btnCreateStore_Click(object sender, RoutedEventArgs e)
        {
            new ModalNewShop().ShowDialog(this);
        }

        private void btnCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            new ModalNewProduct().ShowDialog(this);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var confirmationResult = MessageBoxCenter.Show(this,
               Properties.Resources.MainWindowCloseConfirmation,
               Properties.Resources.MessageBoxConfirmationHeader,
               MessageBoxButton.YesNo);
            if (confirmationResult == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void menuItemAddToShoppingList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemDeleteShoppingProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        public void BindDDLShops()
        {
            ddlShops.Items.Clear();
            List<Store> listStore = HelperMethods.DataManager.GetAllStores();
            foreach (Store objStore in listStore)
            {
                ddlShops.Items.Add(new KeyValuePair<Guid, string>(objStore.StoreID, objStore.Name)); 
            }
        }

        public void BindDDLShoppingLists()
        {
            ddlShoppingLists.Items.Clear();
            List<ShoppingList> listShoppingList = HelperMethods.DataManager.GetAllShoppingLists();
            foreach (ShoppingList objShoppingList in listShoppingList)
            {
                ddlShoppingLists.Items.Add(new KeyValuePair<Guid, string>(objShoppingList.ShoppingListID, objShoppingList.Name));
            }
        }

        private void BtnOpimizeShoppingList_OnClick(object sender, RoutedEventArgs e)
        {
            Algorithm algorithm = (rbShopEnum.IsChecked ?? false) ? Algorithm.ShopEnum : Algorithm.ProductEnum; 

            if (ddlShoppingLists.SelectedIndex == -1)
            {
                return;
            }
            var objKeyValuePair = (KeyValuePair<Guid, string>) ddlShoppingLists.SelectedItem;
            
            new ModalOptimizedShoppingList(objKeyValuePair.Key, algorithm).ShowDialog(this);
        }  
        

        private void gridProducts_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void ddlShops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KeyValuePair<Guid, string> objKeyValuePair = (KeyValuePair<Guid, string>) ddlShops.SelectedItem;

            Store objStore = HelperMethods.DataManager.GetStoreByStoreID(objKeyValuePair.Key);

            if (objStore != null)
            {
                TextBlockShippingCost.Text = objStore.ShipmentCostFormatted;

                List<ProductsDataGridItem> listProductsDataGridItem = new List<ProductsDataGridItem>();

                foreach (StorePosition objStorePosition in objStore.Positions)
                {
                    listProductsDataGridItem.Add(new ProductsDataGridItem()
                    {
                        ProductName = objStorePosition.Name,
                        Price = objStorePosition.Price.ToString("F").Replace(".", ","),
                    });
                }

                gridProducts.ItemsSource = listProductsDataGridItem;
            }
        }

        private void btnCreateShoppingList_Click(object sender, RoutedEventArgs e)
        {
            new ModalNewShoppingList().ShowDialog(this);
        }

        private void ddlShoppingLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var objKeyValuePair = (KeyValuePair<Guid, string>)ddlShoppingLists.SelectedItem;
            var shoppingList = HelperMethods.DataManager.GetShoppingListById(objKeyValuePair.Key);

            if (shoppingList == null) return;
            var shoppingListDataGridItems = new List<ShoppingListDataGridItem>();

            foreach (KeyValuePair<Guid, int> shoppingListPosition in shoppingList.ProductIdToAmountDictionary)
            {
                shoppingListDataGridItems.Add(new ShoppingListDataGridItem
                {
                    ProductName = HelperMethods.DataManager.GetProductByID(shoppingListPosition.Key).Name,
                    Amount = shoppingListPosition.Value.ToString()
                });
            }

            dgShoppingList.ItemsSource = shoppingListDataGridItems;
        }
    }
}
