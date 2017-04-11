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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using KnapsackShoppingOptimizer.Managers;

namespace KnapsackShoppingOptimizer.View
{
    /// <summary>
    /// Interaction logic for ModalNewShop.xaml
    /// </summary>
    public partial class ModalNewShop : Window
    {
        public ModalNewShop()
        {
            InitializeComponent();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();

            txtShopName.Text = "";
            btnSaveNewStore.IsEnabled = false;
        }

        private void txtShopName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSaveNewStore.IsEnabled = txtShopName.Text.Trim() != "" && txtShipmentCost.Text.Trim() != "";
        }

        private void txtShipmentCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSaveNewStore.IsEnabled = txtShopName.Text.Trim() != "" && txtShipmentCost.Text.Trim() != "";
        }

        private void btnSaveNewStore_Click(object sender, RoutedEventArgs e)
        {
            bool bIsShopNameValid = ValidationManager.IsNotEmptyValueValid(txtShopName.Text);
            bool bIsShipmentCostValid = ValidationManager.IsNotEmptyValueValid(txtShipmentCost.Text) && ValidationManager.IsCashValueValid(txtShipmentCost.Text.Replace(",", "."));
            bool bIsEntireFormValid = bIsShopNameValid && bIsShipmentCostValid;

            if (!bIsShopNameValid)
            {
                MessageBox.Show("Proszę wpisać nazwę sklepu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!bIsShipmentCostValid)
            {
                MessageBox.Show("Kwota wysyłki musi być w formacie XX,XX", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            List<Store> listStore = HelperMethods.DataManager.GetAllStores();

            if (listStore.Find(x => ("" + x.Name).ToLower().Trim() == ("" + txtShopName.Text).Trim().ToLower()) != null)
            {
                MessageBox.Show("Sklep z podaną nazwą już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                bIsEntireFormValid = false;   
            }
            
            if (bIsEntireFormValid)
            {
                decimal dShipmentCost = decimal.Parse(txtShipmentCost.Text.Replace(".", ","));

                List<Product> listProduct = HelperMethods.DataManager.GetAllProducts();
                List<StorePosition> listStorePosition = new List<StorePosition>();

                foreach (Product objProduct in listProduct)
                {
                    listStorePosition.Add(new StorePosition()
                    {
                        BaseProduct = objProduct,
                        Price = 0.0M
                    });
                }

                HelperMethods.DataManager.CreateStore(new Store()
                {
                    StoreID = Guid.NewGuid(),
                    ShipmentCost = dShipmentCost,
                    Name = txtShopName.Text,
                    Positions = listStorePosition
                });

                if (this.Owner is MainWindow)
                {
                    ((MainWindow)this.Owner).BindDDLShops();
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}