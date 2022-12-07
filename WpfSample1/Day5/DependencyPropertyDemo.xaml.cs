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

namespace WpfSample1.Day5
{
    /// <summary>
    /// Interaction logic for DependencyPropertyDemo.xaml
    /// </summary>
    public partial class DependencyPropertyDemo : Window
    {
        public DependencyPropertyDemo()
        {
            InitializeComponent();
        }

        private void RestoreDefaultProperties(object sender, RoutedEventArgs e)
        {
            UIElementCollection uIElementCollection = myDockPanel.Children;
            foreach (UIElement element in uIElementCollection)
            {
                LocalValueEnumerator locallySetProperties = element.GetLocalValueEnumerator();
                while (locallySetProperties.MoveNext())
                {
                    DependencyProperty propertyToClear = (DependencyProperty)locallySetProperties.Current.Property;
                    if (!propertyToClear.ReadOnly)
                    {
                        element.ClearValue(propertyToClear);
                    }    
                }  
                    
            }  
                
        }

        private void DrawColor(object sender, RoutedEventArgs e)
        {
            UIElementCollection uIElementCollection = myDockPanel.Children;
            foreach (Shape element in uIElementCollection)
            {
                Color color;
                if (sender == btnOrange)
                {
                    color = Colors.Orange;
                }
                if (sender == btnViolet)
                {
                    color = Colors.Violet;
                }
                if (sender == btnLimeGreen)
                {
                    color = Colors.LimeGreen;
                } 

                element.Fill = new SolidColorBrush(color);

            }
             
        }
    }
}
