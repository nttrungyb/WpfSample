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

namespace WpfSample1.Views.Controls
{
    /// <summary>
    /// Interaction logic for SeaFoodControl.xaml
    /// </summary>
    public partial class SeaFoodControl : UserControl
    {

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int MaxLength { get; set; }


        public SeaFoodControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
