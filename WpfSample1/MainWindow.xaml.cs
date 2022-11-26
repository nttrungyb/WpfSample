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

namespace WpfSample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chkVertial_Checked(object sender, RoutedEventArgs e)
        {
            stackPanel1.Orientation = Orientation.Vertical;
        }

        private void chkVertial_Unchecked(object sender, RoutedEventArgs e)
        {
            stackPanel1.Orientation = Orientation.Horizontal;
        }

        private void ClickMe(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; 
            string str = $"{button.Content} button is clicked"; 
            MessageBox.Show(str);
        }

        private void ShowPanel1(object sender, RoutedEventArgs e)
        {
            StackPanel1 stackPanel1 = new StackPanel1();
            stackPanel1.Owner = this;   
            stackPanel1.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            StackPanel2 stackPanel2 = new StackPanel2();
            stackPanel2.Owner = this;
            stackPanel2.ShowDialog();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            DockPanel1 dockPanel = new DockPanel1();
            dockPanel.Owner = this;
            dockPanel.ShowDialog();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            DockPanel2 dockPanel = new DockPanel2();
            dockPanel.Owner = this;
            dockPanel.ShowDialog();
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            TabularGrid tabular = new TabularGrid();
            tabular.Owner = this;
            tabular.ShowDialog();
        }
        
        private void button11_Click(object sender, RoutedEventArgs e)
        {
            GridLayout2 gridLayout2 = new GridLayout2();
            gridLayout2.Owner = this;
            gridLayout2.ShowDialog();
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoForm personInfoForm = new PersonInfoForm();
            personInfoForm.Owner = this;
            personInfoForm.ShowDialog();
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxSample1 cboForm = new ComboBoxSample1();
            cboForm.Owner = this;
            cboForm.ShowDialog();
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            ControlDemo controlDemo = new ControlDemo();    
            controlDemo.Owner = this;   
            controlDemo.ShowDialog();   
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            ValidateForm validateForm = new ValidateForm();
            validateForm.Owner = this;
            validateForm.ShowDialog();
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            ResourceDemo resourceForm = new ResourceDemo();
            resourceForm.Owner = this;
            resourceForm.ShowDialog();
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            DynamicResourceDemo resourceForm = new DynamicResourceDemo();
            resourceForm.Owner = this;
            resourceForm.ShowDialog();
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            DynamicResource2Sample resourceForm = new DynamicResource2Sample();
            resourceForm.Owner = this;
            resourceForm.ShowDialog();
        }


    }
}
