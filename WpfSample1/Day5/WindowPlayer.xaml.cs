using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WpfSample1.Day5
{
    /// <summary>
    /// Interaction logic for WindowPlayer.xaml
    /// </summary>
    public partial class WindowPlayer : Window
    {

        private bool isPlaying = false;
        private bool isDragging = false;
        DispatcherTimer timer;

        public WindowPlayer()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if(mdiPlayer.Source != null && mdiPlayer.NaturalDuration.HasTimeSpan && !isDragging)
            {
                sldProgress.Minimum = 0;
                sldProgress.Maximum = mdiPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sldProgress.Value = mdiPlayer.Position.TotalSeconds;
            }    
        }

        private void sldProgress_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;  
        }

        private void sldProgress_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging=false;
            mdiPlayer.Position = TimeSpan.FromSeconds(sldProgress.Value);
        }

        private void sldProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgessStatus.Text = TimeSpan.FromSeconds(sldProgress.Value).ToString(@"hh\:mm\:ss"); 
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mdiPlayer != null && mdiPlayer.Source != null;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isPlaying;
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isPlaying;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mp4; *.mpg; *.mpeg)|*.mp3;*.mp4;*.mpg;*.mpeg|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog().Value)
            {
                string filePath = openFileDialog.FileName;
                mdiPlayer.Source = new Uri(filePath);
                lblPath.Text = System.IO.Path.GetFileName(filePath); 
                mdiPlayer.Play();
            }    
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mdiPlayer.Play();
            isPlaying = true;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mdiPlayer.Pause();
            isPlaying = false;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mdiPlayer.Stop();
            isPlaying = false;
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mdiPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }
    }
}
