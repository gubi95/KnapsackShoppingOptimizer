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
    /// Interaction logic for ModalOptimizedShoppingList.xaml
    /// </summary>
    public partial class ModalOptimizedShoppingList : Window
    {
        public ModalOptimizedShoppingList()
        {
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
