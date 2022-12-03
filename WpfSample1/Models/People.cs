using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample1.Models
{
    public class People: ObservableCollection<Employee>
    {
        public People(): base()
        {
            Add(new Employee(2000,"Đặng Ngọc Hân", "Đà Nẵng"));
            Add(new Employee(5000,"Mai Ngọc", "Settel"));
            Add(new Employee(10000,"Tiểu Vy", "Paris"));
            Add(new Employee(1500,"Hồng Nhung", "Vũng Tàu"));
            Add(new Employee(2500,"Đặng Thu Thảo", "Chicago"));
        }
    }
}
