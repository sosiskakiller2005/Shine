using Shine.AppData;
using Shine.Model;
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

namespace Shine.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        private static ShineDbEntities _context = App.GetContext();
        private static List<Product> products = _context.Product.ToList();
        public CatalogPage()
        {
            InitializeComponent();
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 1);
        }

        #region Категории товаров
        private void Category1Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 1);
        }

        private void Category2Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 2);
        }

        private void Category3Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 3);
        }

        private void Category4Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 4);
        }

        private void Category5Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 5);
        }

        private void Category6Btn_Click(object sender, RoutedEventArgs e)
        {
            ProductLb.ItemsSource = products.Where(p => p.CategoryId == 6);
        }
        #endregion

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new MenuPage());
        }
    }
}
