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
using System.Windows.Shapes;

namespace WpfSample1.Day2
{
    /// <summary>
    /// Interaction logic for ValidateForm.xaml
    /// </summary>
    public partial class ValidateForm : Window
    {
        public ValidateForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmailId.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (string.IsNullOrEmpty(firstName))
            {
                errorMessage.Text = $"Bạn cần nhập first name!";
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                errorMessage.Text = $"Bạn cần nhập last name!";
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                errorMessage.Text = $"Bạn cần nhập email!";
                txtEmailId.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errorMessage.Text = $"Email chưa hợp lệ!";
                txtEmailId.Select(0, email.Length);
                return;
            }    

            if (string.IsNullOrEmpty(password))
            {
                errorMessage.Text = $"Bạn cần nhập password!";
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                errorMessage.Text = $"Bạn cần nhập confirmPassword!";
                txtConfirmPassword.Focus();
                return;
            }
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        public void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmailId.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtAddress.Text = "";
        }

    
    }
}
