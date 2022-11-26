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

namespace WpfSample1.Day2
{
    /// <summary>
    /// Interaction logic for DynamicResourceDemo.xaml
    /// </summary>
    public partial class DynamicResourceDemo : Window
    {
        public DynamicResourceDemo()
        {
            InitializeComponent();
            this.Resources["ButtonExitBackgroundColor"] = new SolidColorBrush(Colors.LightGray);
            this.Resources["ButtonExitBorderColor"] = new SolidColorBrush(Colors.Black);
        }

        private void btnChangeResoure2_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["ButtonExitBackgroundColor"] = new SolidColorBrush(Colors.Navy);
            this.Resources["ButtonExitBorderColor"] = new SolidColorBrush(Colors.MediumVioletRed);
            this.Resources["NgocTrinhForegroundColor"] = new SolidColorBrush(Colors.LightPink);
        }
    }
}
