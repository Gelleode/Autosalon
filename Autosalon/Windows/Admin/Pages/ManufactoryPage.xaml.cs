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
    /// Interaction logic for ManufactoryPage.xaml
    /// </summary>
    public partial class ManufactoryPage : Page
    {
        public ManufactoryPage()
        {
            InitializeComponent(); 
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            DGridClient.ItemsSource = DB.Context.Manufactory.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditManufactoryWindow newWindow = new AddEditManufactoryWindow(null);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditManufactoryWindow newWindow = new AddEditManufactoryWindow((Manufactory)DGridClient.SelectedItem);
            newWindow.ShowDialog();
            UpdateDataGrid();
        }
    }
}
