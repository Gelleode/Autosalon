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
    /// Interaction logic for AddEditOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : Window
    {
        private Order _order = new Order();
        public AddEditOrderWindow(Order order)
        {
            if (order != null)
                _order = order;
            InitializeComponent();
            CBoxStore.ItemsSource = DB.Context.Store.ToList();
            CBoxCustomer.ItemsSource = DB.Context.Customer.ToList();
            CBoxManager.ItemsSource = DB.Context.Staff.ToList();
            CBoxStatus.ItemsSource = DB.Context.Status.ToList();
            DataContext = _order;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_order.Date.ToString()))
                errors.AppendLine("Дата не может быть пусто ");
            if (_order.Staff == null)
                errors.AppendLine("Выберите продавца");
            if (_order.Status == null)
                errors.AppendLine("Выберите статус заказа");
            if (_order.Store == null)
                errors.AppendLine("Выберите магазин");
            if (_order.Customer == null)
                errors.AppendLine("Выберите покупателя");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_order.Id == 0)
                {
                    DB.Context.Order.Add(_order);
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
