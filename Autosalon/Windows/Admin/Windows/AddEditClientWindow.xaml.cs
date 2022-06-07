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
using Autosalon.DBModel;
using Autosalon.Utilities;

namespace Autosalon.Windows.Admin.Windows
{
    /// <summary>
    /// Interaction logic for AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        private User _client = new User();

        public AddEditClientWindow(User client)
        {
            if (client != null)
                _client = client;
            InitializeComponent();
            DataContext = _client;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_client.Surname))
                errors.AppendLine("Поле с фамилией не может быть пустым");
            if (string.IsNullOrEmpty(_client.Name))
                errors.AppendLine("Поле с именем не может быть пустым");
            if (string.IsNullOrEmpty(_client.Middlename))
                errors.AppendLine("Поле с отчеством не может быть пустым");
            if (string.IsNullOrEmpty(_client.Phone))
                errors.AppendLine("Поле с телефоном не может быть пустым");
            if (string.IsNullOrEmpty(_client.Email))
                errors.AppendLine("Поле с почтой не может быть пустым");
            if (string.IsNullOrEmpty(_client.Login))
                errors.AppendLine("Поле с логином не может быть пустым");
            if (string.IsNullOrEmpty(_client.Password))
                errors.AppendLine("Поле с паролем не может быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_client.Id == 0)
                {
                    _client.RoleId = 1;
                    Customer cust = new Customer();
                    cust.User = _client;
                    DB.Context.Customer.Add(cust);
                }

                DB.Context.SaveChanges();
                MessageBox.Show("Успешно сохранено");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
