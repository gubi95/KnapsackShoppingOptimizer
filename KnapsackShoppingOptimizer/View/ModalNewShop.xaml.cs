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

        private void TextBoxShopName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxShopName.Text.Trim() == Properties.Resources.ModalNewShopTextBoxName)
            {
                TextBoxShopName.Text = string.Empty;
                TextBoxShopName.Foreground = Brushes.Black;
            }
        }

        private void TextBoxShopName_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxShopName.Text))
            {
                TextBoxShopName.Foreground = Brushes.Gray;
                TextBoxShopName.Text = Properties.Resources.ModalNewShopTextBoxName;
            }
        }

        private void btnSaveNewProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var confirmationResult = MessageBox.Show(this, 
                Properties.Resources.ModalNewShopTextBoxName,
                Properties.Resources.MessageBoxConfirmationHeader, 
                MessageBoxButton.YesNo);
            if(confirmationResult == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
