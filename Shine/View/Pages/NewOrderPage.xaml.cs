using Shine.AppData;
using Shine.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Shine.View.Pages
{
    public partial class NewOrderPage : Page
    {
        private ShineDbEntities _context = App.GetContext();

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<ProductOrderVM> SelectedProducts { get; set; }

        public Product SelectedProduct { get; set; }
        public ProductOrderVM SelectedFromOrder { get; set; }

        public NewOrderPage()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>(_context.Product.ToList());
            SelectedProducts = new ObservableCollection<ProductOrderVM>();

            DataContext = this;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null && !SelectedProducts.Any(x => x.Product.Id == SelectedProduct.Id))
            {
                SelectedProducts.Add(new ProductOrderVM { Product = SelectedProduct, Quantity = 1 });
            }
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFromOrder != null)
                SelectedProducts.Remove(SelectedFromOrder);
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is ProductOrderVM item)
                item.Quantity++;
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is ProductOrderVM item)
            {
                item.Quantity--;
                if (item.Quantity < 1)
                    item.Quantity = 1;
            }
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProducts.Count == 0)
            {
                MessageBox.Show("Добавьте товары в заказ.");
                return;
            }

            var order = new Order
            {
                DateTime = DateTime.Now,
                StatusId = 1, // Укажите нужный статус
                UserId = 1,   // Укажите текущего пользователя
                TimeOfDelivery = DateTime.Now.AddHours(1),
                Quantity = SelectedProducts.Sum(x => x.Quantity),
                Amount = SelectedProducts.Sum(x => x.Product.Price * x.Quantity)
            };
            _context.Order.Add(order);
            _context.SaveChanges();

            foreach (var item in SelectedProducts)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    _context.ProductOrder.Add(new ProductOrder
                    {
                        OrderId = order.Id,
                        ProductId = item.Product.Id
                    });
                }
            }
            _context.SaveChanges();

            SelectedProducts.Clear();
            MessageBox.Show("Заказ успешно оформлен!");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new MenuPage());
        }
    }

    public class ProductOrderVM : System.ComponentModel.INotifyPropertyChanged
    {
        public Product Product { get; set; }
        private int _quantity = 1;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 1) value = 1;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }
}
