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
            txtPassword.Password = "123";
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (txtEmailId.Text.Length == 0)
            {
                errorMessage.Text = "Enter an Email";
                txtEmailId.Focus();
            }

            else if (!Regex.IsMatch(txtEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {

                errorMessage.Text = "Enter a valid email.";
                txtEmailId.Select(0, txtEmailId.Text.Length);
                txtEmailId.Focus();
            }

            else
            {
                string email = txtEmailId.Text;
                string password = txtPassword.Password;

                if (email.Equals("nttrungyb@gmail.com") && password.Equals("123"))
                {
                    mainWindow.DoLoginLogout();
                    mainWindow.ShowMainLayout();
                    mainWindow.Activate();
                }    
                else
                {
                    errorMessage.Text = "Invalid username or password!";
                    txtEmailId.Focus();
                }    
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage _registerPage = new RegisterPage(mainWindow);
            mainWindow.DisplayLayout(_registerPage);

        }
    }
}
