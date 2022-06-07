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
    /// Interaction logic for AddEditManufactoryWindow.xaml
    /// </summary>
    public partial class AddEditManufactoryWindow : Window
    {
        private Manufactory _manufactory = new Manufactory();
        public AddEditManufactoryWindow(Manufactory manufactory)
        {
            if (manufactory != null)
                _manufactory = manufactory;
            InitializeComponent();
            DataContext = _manufactory;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_manufactory.Title))
                errors.AppendLine("Название не может быть пусто ");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_manufactory.Id == 0)
                {
                    DB.Context.Manufactory.Add(_manufactory);
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
