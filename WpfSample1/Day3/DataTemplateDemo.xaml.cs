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
using WpfSample1.Models;

namespace WpfSample1.Day3
{
    /// <summary>
    /// Interaction logic for DataTemplateDemo.xaml
    /// </summary>
    public partial class DataTemplateDemo : Window
    {

        List<Person> people = new List<Person>();   

        public DataTemplateDemo()
        {
            InitializeComponent();
            
            people.Add(new Person { Name = "Mai Ngoc", Age = 31}); 
            people.Add(new Person { Name = "Tieu Vy", Age = 22}); 
            people.Add(new Person { Name = "Hong Nhung", Age = 30}); 
            people.Add(new Person { Name = "Phuong Oanh", Age = 31});

            this.DataContext = people;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            
            if (lsbPerson.SelectedItem != null)
            {
                Person selectedPerson = (Person)lsbPerson.SelectedItem;
                message = $"{selectedPerson.Name} la {selectedPerson.Age} tuoi !";
            }
                
            //MessageBox.Show(message);
            btn.Content = message;
        }
    }
}
