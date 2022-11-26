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
    /// Interaction logic for DynamicResource2Sample.xaml
    /// </summary>
    public partial class DynamicResource2Sample : Window
    {
        public DynamicResource2Sample()
        {
            InitializeComponent();
            Image grayImage = new Image();
            grayImage.Width = 200;
            grayImage.Margin = new Thickness(5);

            FormatConvertedBitmap fcb = new FormatConvertedBitmap((BitmapImage)this.Resources["maingoc"], PixelFormats.Gray4, null, 0);
            grayImage.Source = fcb;

            Grid.SetColumn(grayImage, 2);
            Grid.SetRow(grayImage, 1);

            convertedGrid.Children.Add(grayImage);
        }
    }
}
