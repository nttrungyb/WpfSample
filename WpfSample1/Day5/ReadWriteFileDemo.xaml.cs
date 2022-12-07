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
using System.IO;

namespace WpfSample1.Day5
{
    /// <summary>
    /// Interaction logic for ReadWriteFileDemo.xaml
    /// </summary>
    public partial class ReadWriteFileDemo : Window
    {
        public ReadWriteFileDemo()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = @$"{System.AppDomain.CurrentDomain.BaseDirectory}Data/Files/demo.txt";
            
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName);   
                txtName.Text = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                MessageBox.Show("File not exists!");
            }
        }

        private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @$"{System.AppDomain.CurrentDomain.BaseDirectory}Data/Files/demo.txt";

            try
            {
                FileStream fs;
                if (File.Exists(filePath))
                {
                    fs = File.Create(filePath);
                }
                else
                {
                    fs = File.OpenWrite(filePath);
                }

                StreamWriter objWrite = new StreamWriter(fs);
                objWrite.WriteLine(txtName.Text);
                objWrite.Write(txtAddress.Text);
                objWrite.Close();
                
                txtName.Clear();
                txtAddress.Clear();

                MessageBox.Show($"Ghi file {filePath} thanh cong!");
            }
            catch(IOException ex)
            {
                MessageBox.Show($"Ghi file loi: {ex.Message}");
            }
            
        }
    }
}
