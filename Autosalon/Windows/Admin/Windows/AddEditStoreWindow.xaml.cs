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
    /// Interaction logic for AddEditStoreWindow.xaml
    /// </summary>
    public partial class AddEditStoreWindow : Window
    {
        private Store _store = new Store();
        public AddEditStoreWindow(Store store)
        {
            if (store != null)
                _store = store;
            InitializeComponent();
            DataContext = _store;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_store.City))
                errors.AppendLine("Поле с городом не может быть пустым");
            if (string.IsNullOrEmpty(_store.Street))
                errors.AppendLine("Поле с улицей не может быть пустым");
            if (string.IsNullOrEmpty(_store.Phone))
                errors.AppendLine("Поле с номером не может быть пустым");
            if (string.IsNullOrEmpty(_store.Email))
                errors.AppendLine("Поле с почтой не может быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (_store.Id == 0)
                {
                    DB.Context.Store.Add(_store);
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
