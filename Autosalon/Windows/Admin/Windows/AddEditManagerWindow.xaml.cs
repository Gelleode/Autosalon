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
    /// Interaction logic for AddEditManagerWindow.xaml
    /// </summary>
    public partial class AddEditManagerWindow : Window
    {
        private User _manager = new User();

        public AddEditManagerWindow(User manager)
        {
            if (manager != null)
                _manager = manager;

            InitializeComponent();
            DataContext = _manager;
            CBoxStore.ItemsSource = DB.Context.Store.ToList();
            if (manager != null)
                CBoxStore.SelectedItem = _manager.Staff.First().Store;
            else
                CBoxStore.SelectedIndex = 0;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_manager.Surname))
                errors.AppendLine("Поле с фамилией не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Name))
                errors.AppendLine("Поле с именем не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Middlename))
                errors.AppendLine("Поле с отчеством не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Phone))
                errors.AppendLine("Поле с телефоном не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Email))
                errors.AppendLine("Поле с почтой не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Login))
                errors.AppendLine("Поле с логином не может быть пустым");
            if (string.IsNullOrEmpty(_manager.Password))
                errors.AppendLine("Поле с паролем не может быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_manager.Id == 0)
                {
                    _manager.RoleId = 2;
                    Staff mang = new Staff();
                    mang.User = _manager;
                    mang.StoreId = ((Store)CBoxStore.SelectedItem).Id;
                    DB.Context.Staff.Add(mang);
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
