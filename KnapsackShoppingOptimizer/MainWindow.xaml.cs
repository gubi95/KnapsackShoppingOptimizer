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
using KnapsackShoppingOptimizer.View;

namespace KnapsackShoppingOptimizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += FormLoad;
        }

        private void FormLoad(object sender, RoutedEventArgs e)
        {
            
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

        private void menuItemEditShoppingProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
