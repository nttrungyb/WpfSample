using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample1.Models
{
    public class Employee1
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int Salary { get; set;}   

        public static ObservableCollection<Employee1> GetEmployees()
        {
            var employees = new ObservableCollection<Employee1>();  
            employees.Add(new Employee1() { Name="Tieu Vy", Title="Marketing Director", Address="Settle", Salary =5000}); 
            employees.Add(new Employee1() { Name="Mai Ngoc", Title="Human Resources Director", Address="NewYork", Salary =4000}); 
            employees.Add(new Employee1() { Name="Kim Thoa", Title="Admin Vice Director", Address="Nha Trang", Salary =2000}); 
            employees.Add(new Employee1() { Name="Mai Bela", Title="Vice Director", Address="Zurich", Salary =2500}); 
            employees.Add(new Employee1() { Name="Phuong Oanh", Title="Product Director", Address="Phu Quoc", Salary =3000}); 
            employees.Add(new Employee1() { Name="Mai Thu Huyen", Title="Business Director", Address="Paris", Salary =4000}); 

            return employees;
        }
    }
}
