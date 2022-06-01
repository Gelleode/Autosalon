using System.Windows;
using Autosalon.Utilities;
using Autosalon.Windows.Auth.Pages;

namespace Autosalon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuthFrame.Navigate(new AuthPage());
            Manager.MainFrame = AuthFrame;
        }
    }
}
