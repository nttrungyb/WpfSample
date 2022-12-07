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
    /// Interaction logic for DragAndDropDemo.xaml
    /// </summary>
    public partial class DragAndDropDemo : Window
    {
        public DragAndDropDemo()
        {
            InitializeComponent();
        }

        private void Target_Drop(object sender, DragEventArgs e)
        {
            SolidColorBrush scb = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            Target.Fill = scb;
        }

        private void Drag_Rectangle(object sender, MouseButtonEventArgs e)
        {
            Rectangle rc = sender as Rectangle;
            DataObject data = new DataObject(rc.Fill);
            DragDrop.DoDragDrop( rc , data, DragDropEffects.Move);
        }

    }
}
