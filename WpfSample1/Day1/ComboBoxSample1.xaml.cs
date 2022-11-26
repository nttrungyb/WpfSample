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
    /// Interaction logic for ComboBoxSample1.xaml
    /// </summary>
    public partial class ComboBoxSample1 : Window
    {
        public ComboBoxSample1()
        {
            InitializeComponent();
        }

        private void cboSeaFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized)
                return;
            ComboBoxItem item = cboSeaFood.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                MessageBox.Show($"Item được chọn là: {item.Content}", "Thông báo");
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            ComboBoxItem item = e.OriginalSource as ComboBoxItem;

            if (item != null)
            {
                MessageBox.Show($"{item.Content} được chọn", "Thông báo");
            }    

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = cboSeaFood.SelectedItem as ComboBoxItem;    
            if (item != null)
            {
                MessageBox.Show($"Item hiện tại là: {item.Content}", "Thông báo");
            }
            else
            {
                if (!string.IsNullOrEmpty(cboSeaFood.Text))
                {
                    MessageBox.Show($"Text nhập là: {cboSeaFood.Text}", "Thông báo");
                }    
            }    
        }
    }
}
