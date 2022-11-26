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

namespace WpfSample1.Component
{
    /// <summary>
    /// Interaction logic for PersonInfoForm.xaml
    /// </summary>
    public partial class PersonInfoForm : Window
    {
        public PersonInfoForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( "Click me!", "Thông báo");
        }
    }
}
