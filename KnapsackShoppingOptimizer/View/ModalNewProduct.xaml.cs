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
    /// Interaction logic for ModalNewProduct.xaml
    /// </summary>
    public partial class ModalNewProduct : Window
    {
        public ModalNewProduct()
        {
            InitializeComponent();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        private void btnSaveNewProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
           
            var confirmationResult = MessageBoxCenter.Show(this,
                Properties.Resources.ModalNewProductCloseConfirmation,
                Properties.Resources.MessageBoxConfirmationHeader,
                MessageBoxButton.YesNo);
            if (confirmationResult == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void TextBoxProductName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxProductName.Text.Trim() == Properties.Resources.ModalNewProductTextBoxName)
            {
                TextBoxProductName.Text = string.Empty;
                TextBoxProductName.Foreground = Brushes.Black;
            }
        }

        private void TextBoxProductName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxProductName.Text))
            {
                TextBoxProductName.Foreground = Brushes.Gray;
                TextBoxProductName.Text = Properties.Resources.ModalNewProductTextBoxName;
            }
        }
    }
}
