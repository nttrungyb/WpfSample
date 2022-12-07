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
    /// Interaction logic for MutilMediaDemo.xaml
    /// </summary>
    public partial class MultiMediaDemo : Window
    {
        public MultiMediaDemo()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            myMedia.Play();
        }

        private void MediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();
        }

        private void MediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();
        }

        private void MediaMute(Object sender, EventArgs e)
        {
            if (myMedia.Volume == 100)
            {
                myMedia.Volume = 0;
                btnMute.Content = "Listen";
            }
            else
            {
                myMedia.Volume = 100;
                btnMute.Content = "Mute";
            }
        }
    }
}
