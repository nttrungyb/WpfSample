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
    /// Interaction logic for ControlDemo.xaml
    /// </summary>
    public partial class ControlDemo : Window
    {
        public ControlDemo()
        {
            InitializeComponent();
            //imgPopup.Source = Resource.maingoc;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtTextBox.Clear();
        }
        
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            txtTextBox.SelectAll();
        }

        private void TextStyle_Click(object sender, RoutedEventArgs e)
        {
            if(sender == miNormal)
            {
                txtTextBox.FontWeight = FontWeights.Normal;
                txtTextBox.FontStyle = FontStyles.Normal;
            } else if (sender == miBold)
            {
                txtTextBox.FontWeight = FontWeights.Bold;
               // txtTextBox.FontStyle = FontStyles.Normal;
            }
            else if (sender == miItalic)
            {
                //txtTextBox.FontWeight = FontWeights.Bold;
                txtTextBox.FontStyle = FontStyles.Italic;
            }

        }

        private void MarkOne(object sender, RoutedEventArgs e)
        {
            sbBar.Items.Clear();
            Label lblLable = new Label();
            lblLable.Background = new LinearGradientBrush(Colors.DeepPink, Colors.GhostWhite, 90);
            lblLable.Content = "Indeterminate ProgressBar.";
            sbBar.Items.Add(lblLable);

            ProgressBar pgbBar = new ProgressBar();
            pgbBar.Background = Brushes.Lime;
            pgbBar.Foreground = Brushes.Orange;
            pgbBar.Width = 150;
            pgbBar.Height = 15;
            pgbBar.IsIndeterminate = true;

            sbBar.Items.Add(pgbBar);

        }

        private void GetSliderValue_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;
            string message = "Unknown slider.";
            if (button == btnGetSliderValue1)
            {
                message = $"Slider 1 value = {slider1.Value}";
            }    
            else if (button == btnGetSliderValue2)
            {
                message = $"Slider 2 value = {slider2.Value}";
            }
            MessageBox.Show(message, "Thông báo");
        }


        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = e.OriginalSource as Slider;
            if (slider != null)
            {
                txtSliderValue.Text = slider.Value.ToString();
            }    
        }

        private void btnClosePopup_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }

        private void btnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnShowPopup)
            {
                myPopup.IsOpen = true;  
            }    
        }
    }
}
