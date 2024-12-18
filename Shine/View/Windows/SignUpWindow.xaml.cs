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
using System.Windows.Shapes;

namespace Shine.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private static ShineDbEntities _context = App.GetContext();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignInHl_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FullnameTb.Text != string.Empty && LoginTb.Text != string.Empty && PasswordTb.Password != string.Empty)
            {
                string[] names = new string[3];
                names = FullnameTb.Text.Split(' ');
                if (names.Length != 3)
                {
                    MessageBoxHelper.Error("Введите ФИО полностью.");
                }
                else
                {
                    User newUser = new User()
                    {
                        Lastname = names[0],
                        Name = names[1],
                        Surname = names[2],
                        Login = LoginTb.Text,
                        Password = PasswordTb.Password
                    };
                    _context.User.Add(newUser);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Новый пользователь зарегистрирован.");
                    AuthorisationWindow authorisationWindow = new AuthorisationWindow();
                    authorisationWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBoxHelper.Error("Заполните все поля для ввода.");
            }
        }
    }
}
