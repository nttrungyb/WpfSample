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
using System.Windows.Shapes;
using System.Resources;
using System.Reflection;

namespace WpfSample1.Day3
{
    /// <summary>
    /// Interaction logic for I18NDemo.xaml
    /// </summary>
    public partial class I18NDemo : Window
    {
        public I18NDemo()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");   
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");   
            InitializeComponent();
        }

        private void LanguageChange_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnFrench)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
                txtNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyyy");
                ResourceManager manager = new ResourceManager("WpfSample1.Properties.Resources", Assembly.GetExecutingAssembly());
                txtName.Text = manager.GetString("Name");
                txtAddress.Text = manager.GetString("Address");
                txtSeafood.Text = manager.GetString("Seafood");
                this.Title = manager.GetString("Title");

            }

            if (sender == btnJapan)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("jp-JP");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("jp-JP");
            }

            if (sender == btnThaiLand)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("th-TH");
                txtNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyyy");
                ResourceManager manager = new ResourceManager("WpfSample1.Properties.Resources", Assembly.GetExecutingAssembly());
                txtName.Text = manager.GetString("Name");
                txtAddress.Text = manager.GetString("Address");
                txtSeafood.Text = manager.GetString("Seafood");
                this.Title = manager.GetString("Title");
            }

            
        }
    }
}
