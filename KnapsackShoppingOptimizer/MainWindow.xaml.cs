using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KnapsackShoppingOptimizer.Models;
using KnapsackShoppingOptimizer.View;

namespace KnapsackShoppingOptimizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ShoppingListItem> _shoppingList = new List<ShoppingListItem>();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += FormLoad;
        }

        private void FormLoad(object sender, RoutedEventArgs e)
        {
            // this should be called only here and only once
            HelperMethods.DataManager.ReadFromFile();
            BindCbProducts();
            BindDDLShops();
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
                ddlShops.Items.Add(new KeyValuePair<string, string>(objStore.StoreID.ToString() , objStore.Name)); 
            }
        }

        public void BindCbProducts()
        {
            cbProducts.Items.Clear();
            List<Product> products = HelperMethods.DataManager.GetAllProducts();
            products.ForEach(
                product =>
                    cbProducts.Items.Add(new KeyValuePair<Guid, string>(product.ProductID, product.Name)));

        }

        private void BtnOpimizeShoppingList_OnClick(object sender, RoutedEventArgs e)
        {
            new ModalOptimizedShoppingList().ShowDialog(this);
        }

        private void BtnAddToShoppingList_OnClick(object sender, RoutedEventArgs e)
        {
            Product product = HelperMethods.DataManager.GetProductByID(((KeyValuePair<Guid, string>) cbProducts.SelectedItem).Key);
        }
    }
}
