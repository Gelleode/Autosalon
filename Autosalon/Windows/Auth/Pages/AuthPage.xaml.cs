using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autosalon.Windows.Manаger;

namespace Autosalon.Windows.Auth.Pages
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void BtnAuthClick(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
#if DEBUG
            ManagerWindow newWindow = new ManagerWindow();
            newWindow.Show();
            Utilities.Manager.MainFrame = null;
            window.Close();
#endif
        }
        private void BtnGoToRegisterClick(object sender, RoutedEventArgs e)
        {
            Utilities.Manager.MainFrame.Navigate(new RegisterPage());
        }
    }
}
