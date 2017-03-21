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
    }
}
