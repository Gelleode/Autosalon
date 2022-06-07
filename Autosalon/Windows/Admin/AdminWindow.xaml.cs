using System;
using System.Windows;
using Autosalon.Utilities;
using Autosalon.Windows.Admin.Pages;

namespace Autosalon.Windows.Admin
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StockPage());
            Manager.MainFrame = MainFrame;
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StorePage());
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StockPage());
        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CarPage());
        }
        private void Manufactory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufactoryPage());
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientPage());
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagersPage());
        }

        private void Sells_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SalePage());
        }

        private void MainFrame_OnContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
    }
}