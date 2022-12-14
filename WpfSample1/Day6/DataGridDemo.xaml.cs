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
using WpfSample1.Models;

namespace WpfSample1.Day6
{
    /// <summary>
    /// Interaction logic for DataGridDemo.xaml
    /// </summary>
    public partial class DataGridDemo : Window
    {
        public DataGridDemo()
        {
            InitializeComponent();
            gridPerson.ItemsSource = Employee1.GetEmployees();
        }
    }
}
