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
using WpfSample1.Component;
using WpfSample1.Day2;
using WpfSample1.Views.Layouts;
using WpfSample1.Views.Login;

namespace WpfSample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LoginPage loginPage;
        Page currentPage;

        public MainWindow()
        {
            InitializeComponent();
            //MainLayout mainLayout = new MainLayout(this);
            loginPage = new LoginPage(this);
            frmMainContent.Navigate(loginPage);
            //RegisterPage registerPage = new RegisterPage(this);
            //frmMainContent.Navigate(registerPage);
            //frmMainContent.Navigate(mainLayout);
            ApplicationContext.IsLogged = false;
            this.DataContext = this;

        }

        public bool DisplayLayout(Page layout)
        {
            frmMainContent.Navigate(layout);
            currentPage = layout;
            return true;    
        }

        public bool ShowMainLayout()
        {
            MainLayout mainLayout = new MainLayout(this);
            frmMainContent.Navigate(mainLayout);
            currentPage = mainLayout;
            return true;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationContext.IsLogged)
            {
                ApplicationContext.IsLogged = false;
                btnLogin.Content = "Login";
                DisplayLayout(loginPage);  
            }
            else
            {
                if (currentPage != loginPage)
                {
                    loginPage = new LoginPage(this);
                    currentPage = loginPage;
                    frmMainContent.Navigate(loginPage);
                }
            } 
            
            
        }

        public void DoLogin()
        {
            ApplicationContext.IsLogged = true;
            btnLogin.Content = "Logout";
           
        }
    }
}
