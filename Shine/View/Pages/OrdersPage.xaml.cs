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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private static ShineDbEntities _context = App.GetContext();
        Style PressedStyle;
        Style UnpressedStyle;
        List<Order> orders = _context.Order.ToList();
        public OrdersPage()
        {
            InitializeComponent();
            PressedStyle = (Style)FindResource("PressedBtn");
            UnpressedStyle = (Style)FindResource("UnpressedBtn");
            NewOrdersBtn.Style = PressedStyle;
            WIPBtn.Style = UnpressedStyle;
            FinishedBtn.Style = UnpressedStyle;
            OrdersLb.ItemsSource = orders.Where(o => o.StatusId == 1);
        }

        private void NewOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrdersBtn.Style = PressedStyle;
            WIPBtn.Style = UnpressedStyle;
            FinishedBtn.Style = UnpressedStyle;
            OrdersLb.ItemsSource = orders.Where(o => o.StatusId == 1);
        }

        private void WIPBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrdersBtn.Style = UnpressedStyle;
            WIPBtn.Style = PressedStyle;
            FinishedBtn.Style = UnpressedStyle;
            OrdersLb.ItemsSource = orders.Where(o => o.StatusId == 2);
        }

        private void FinishedBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrdersBtn.Style = UnpressedStyle;
            WIPBtn.Style = UnpressedStyle;
            FinishedBtn.Style = PressedStyle;
            OrdersLb.ItemsSource = orders.Where(o => o.StatusId == 3);
        }
    }
}
