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
using Autosalon.Windows.Admin.Windows;

namespace Autosalon.Windows.Admin.Pages
{
    /// <summary>
    /// Interaction logic for CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DGridCars.ItemsSource = DB.Context.Car.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCarWindow newWindow = new AddEditCarWindow(null);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditCarWindow newWindow = new AddEditCarWindow((Car)DGridCars.SelectedItem);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridCars.SelectedItems.Cast<Car>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    DB.Context.Car.RemoveRange(productForRemoving);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    UpdateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
