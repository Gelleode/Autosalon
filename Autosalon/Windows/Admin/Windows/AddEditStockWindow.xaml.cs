using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddEditStockWindow.xaml
    /// </summary>
    public partial class AddEditStockWindow : Window
    {
        private Stock _stock = new Stock();
        public AddEditStockWindow(Stock stock)
        {
            if (stock != null)
                _stock = stock;
            else
                _stock.Car = DB.Context.Car.First();
            InitializeComponent();
            CBoxCar.ItemsSource = DB.Context.Car.ToList();
            CBoxCategory.ItemsSource = DB.Context.Category.ToList();
            DataContext = _stock;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int quantity;

            var stock = DB.Context.Stock.ToList();

            var check = from stock1 in stock
                            where stock1.StoreId == Manager.Store.Id && stock1.CarId == _stock.Car.Id && stock1.Id != _stock.Id
                            select stock1;
            if(check.Any())
            {
                MessageBox.Show("Такая машина уже занесена в реестр магазина", "Ошибка");
                return;
            }

            try
            {
                quantity = Convert.ToInt32(TBoxQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Количество должно быть числом!", "Ошибка");
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным!", "Ошибка");
                return;
            }

            try
            {
                if (_stock.Id == 0)
                {
                    _stock.StoreId = Manager.Store.Id;
                    DB.Context.Stock.Add(_stock);
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
