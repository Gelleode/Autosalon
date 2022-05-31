﻿using System;
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
using Autosalon.Utilities;

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
            
        }
        private void BtnGoToRegisterClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegisterPage());
        }
    }
}
