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
using Autosalon.DBModel;
using Autosalon.Utilities;

namespace Autosalon.Windows.Auth.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void BtnAuthClick(object sender, RoutedEventArgs e)
        {
            Utilities.Manager.MainFrame.Navigate(new AuthPage());
        }
        private void BtnRegisterClick(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = PassBox.Password.Trim();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Упс!Введите больше 5 символов";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                PassBox.ToolTip = "Упс!Пароль должен содержать больше 5 символов";
                PassBox.Background = Brushes.Red;
            }
            else if (password != PassBox2.Password.Trim())
            {
                PassBox2.ToolTip = "Пароли не совпадают!";
                PassBox2.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
            }

            //try
            //{
            //    User user = new User
            //    {
                    
            //    };
            //}
        }
    }
}
