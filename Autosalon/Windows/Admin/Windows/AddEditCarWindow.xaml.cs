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
    /// Interaction logic for AddEditCarWindow.xaml
    /// </summary>
    public partial class AddEditCarWindow : Window
    {
        private Car _car = new Car();
        public AddEditCarWindow(Car car)
        {
            if (car != null)
            {
                _car = car;
            }
            else
            {
                _car.Category = DB.Context.Category.First();
                _car.Manufactory = DB.Context.Manufactory.First();
            }
            InitializeComponent();
            CBoxCar.ItemsSource = DB.Context.Manufactory.ToList();
            CBoxCategory.ItemsSource = DB.Context.Category.ToList();
            DataContext = _car;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_car.Model))
                errors.AppendLine("Поле с названием не может быть пустым");
            if (_car.Price < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_car.Year < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_car.HorsePower < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_car.Manufactory == null)
                errors.AppendLine("Выберите производители");
            if (_car.Category == null)
                errors.AppendLine("Выберите Категорию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (_car.Id == 0)
                {
                    DB.Context.Car.Add(_car);
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
