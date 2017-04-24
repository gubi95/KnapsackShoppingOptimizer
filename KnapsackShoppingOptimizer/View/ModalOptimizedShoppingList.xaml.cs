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
        private class ShoppingListDataGridItem
        {
            public string Store { get; set; }
            public string Product { get; set; }
            public string Amount { get; set; }
            public string Price { get; set; }
        }

        //private ShoppingList
        public ModalOptimizedShoppingList(Guid shoppingListId, Algorithm algorithm)
        {
            InitializeComponent();
            var shoppingList = HelperMethods.DataManager.GetShoppingListById(shoppingListId);
            var stores = ModelConverter.getStoreDtoList(HelperMethods.DataManager.GetAllStores());
            var optimizedShoppingList = OptimizationController.Optimize(stores, shoppingList.ProductIdToAmountDictionary, algorithm);
            FillForm(optimizedShoppingList, algorithm);
            
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        private void FillForm(OptimizedShoppingList optimizedShoppingList, Algorithm algorithm)
        {
            TextBlockSumPrice.Text = optimizedShoppingList.TotalPrice.ToString("C");
            TextBlockTime.Text = optimizedShoppingList.TimeElapsed.Milliseconds + "ms";
            TextBlockAlgorithm.Text = algorithm.ToString();

            var dgShoppingListItems = new List<ShoppingListDataGridItem>();
            optimizedShoppingList.Products.ForEach(product =>
            {
                dgShoppingListItems.Add(new ShoppingListDataGridItem
                {
                    Store = product.Store.Name,
                    Product = HelperMethods.DataManager.GetProductByID(product.ProductId).Name,
                    Amount = product.Amount.ToString(),
                    Price = product.Price.ToString("C")
                });
            });
            dgShoppingList.ItemsSource = dgShoppingListItems;
        }


        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
