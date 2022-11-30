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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        MainWindow mainWindow;
        public RegisterPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;   
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            lblmessage.Content = "";

            if (txtemailid.Text.Length == 0)

            {
                lblmessage.Visibility = System.Windows.Visibility.Visible;
                lblmessage.Foreground = Brushes.Red;
                lblmessage.Content = "Enter an email.";

                txtemailid.Focus();

            }

            else if (!Regex.IsMatch(txtemailid.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                lblmessage.Visibility = System.Windows.Visibility.Visible;
                lblmessage.Foreground = Brushes.Red;
                lblmessage.Content = "Enter a valid email.";

                txtemailid.Select(0, txtemailid.Text.Length);
                txtemailid.Focus();

            }
            else
            {
                if (txtpassword.Password.Length == 0)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Enter password.";
                    txtpassword.Focus();

                }
                else if (txtcpassword.Password.Length == 0)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Enter Confirm password.";

                    txtcpassword.Focus();

                }
                else if (txtpassword.Password != txtcpassword.Password)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Confirm password must be same as password.";

                    txtcpassword.Focus();

                }
                else
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Green;
                    lblmessage.Content = "Registration Successfully ";
                }
            }
        }
        // Resert all control
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetAllClear();
        }

        private void ResetAllClear()
        {
            foreach (UIElement ui in ChildGrid.Children)
            {
                if (ui is TextBox)
                {
                    TextBox tt = (TextBox)ui;
                    tt.Text = "";
                }
                if (ui is PasswordBox)
                {
                    PasswordBox pp = (PasswordBox)ui;
                    pp.Password = "";
                }

            }
            foreach (UIElement ui in stackCheckBox.Children)
            {
                if (ui.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = (CheckBox)ui;
                    chk.IsChecked = false;
                }
            }
            cblCourse.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage(mainWindow);
            mainWindow.DisplayLayout(loginPage);
        }
    }
}
