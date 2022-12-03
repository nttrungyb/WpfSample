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

namespace WpfSample1.Views.Menu
{
    /// <summary>
    /// Interaction logic for PgMenu.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        MainWindow mainWindow;

        public MenuPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void LoginLogout_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationContext.IsLogged)
            {
                mainWindow.DoLoginLogout();
                mainWindow.ShowLogin();
            }    
            else
            {
                mainWindow.ShowLogin();
            }    
        }

        public void UpdateStatus()
        {
            if (ApplicationContext.IsLogged)
            {
                mnLogin.Header = "Đăng xuất";
            }
            else
            {
                mnLogin.Header = "Đăng nhập";
            }
        }    
    }
}
