using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfSample1.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        MainWindow mainWindow;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txEmailId.Text.Length == 0)
            {
                errormessage.Text = "Enter an Email";
                txEmailId.Focus();
            }

            else if (!Regex.IsMatch(txEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {

                errormessage.Text = "Enter a valid email.";
                txEmailId.Select(0, txEmailId.Text.Length);
                txEmailId.Focus();
            }

            else
            {
                string email = txEmailId.Text;
                string password = txtPassword.Password;                
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage _registerPage = new RegisterPage(mainWindow);
            mainWindow.DisplayLayout(_registerPage);
            
        }
    }
}
