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

namespace WpfSample1.Day4
{
    /// <summary>
    /// Interaction logic for CustomControlDemo.xaml
    /// </summary>
    public partial class CustomControlDemo : Window
    {
        public CustomControlDemo()
        {
            InitializeComponent();
        }

        private void custControl_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "Bấm vào custom control!";
        }
    }
}
