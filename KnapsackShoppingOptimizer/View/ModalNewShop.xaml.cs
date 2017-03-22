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
            btnSaveNewProduct.IsEnabled = false;
        }

        private void txtShopName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSaveNewProduct.IsEnabled = txtShopName.Text.Trim() != "" && txtShipmentCost.Text.Trim() != "";
        }

        private void txtShipmentCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSaveNewProduct.IsEnabled = txtShopName.Text.Trim() != "" && txtShipmentCost.Text.Trim() != "";
        }

        private void btnSaveNewProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }            
    }
}
