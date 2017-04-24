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
using KnapsackOptimizer.Controller;
using KnapsackOptimizer.Model;
using KnapsackShoppingOptimizer.Utils;

namespace KnapsackShoppingOptimizer.View
{
    /// <summary>
    /// Interaction logic for ModalOptimizedShoppingList.xaml
    /// </summary>
    public partial class ModalOptimizedShoppingList : Window
    {

        //private ShoppingList
        public ModalOptimizedShoppingList(Guid shoppingListId, Algorithm algorithm)
        {
            var shoppingList = HelperMethods.DataManager.GetShoppingListById(shoppingListId);
            var stores = ModelConverter.getStoreDtoList(HelperMethods.DataManager.GetAllStores());
            var productIdToStoreIdDictionary = OptimizationController.Optimize(stores, shoppingList.ProductIdToAmountDictionary, algorithm);
            InitializeComponent();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
