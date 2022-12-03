using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample1.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public int Price { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Employee() { }


        public Employee(int price, string fullName, string address) 
        {
            this.Price = price;
            this.FullName = fullName;
            this.Address = address;
        }


        public override string ToString()
        {
            return FullName.ToString();
        }

        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;  
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));  
            }    
        }



    }
}
