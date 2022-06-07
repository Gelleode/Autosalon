using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autosalon.DBModel;
using Autosalon.Utilities;
using Autosalon.Windows.Admin.Windows;

namespace Autosalon.Windows.Admin.Pages
{
    /// <summary>
    /// Interaction logic for StockPage.xaml
    /// </summary>
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
            CBoxStore.ItemsSource = DB.Context.Store.ToList();
            CBoxStore.SelectedIndex = 0;
            Manager.Store = (Store)CBoxStore.SelectedItem;
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            var selected = (Store)CBoxStore.SelectedItem;
            var cars = DB.Context.Stock.Where(x => x.StoreId.Equals(selected.Id)).ToList();
            DGridCars.ItemsSource = cars;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditStockWindow newWindow = new AddEditStockWindow((Stock)DGridCars.SelectedItem);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditStockWindow newWindow = new AddEditStockWindow(null);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }

        private void CBoxStore_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.Store = (Store)CBoxStore.SelectedItem;
            UpdateDataGrid();
        }
    }
}
