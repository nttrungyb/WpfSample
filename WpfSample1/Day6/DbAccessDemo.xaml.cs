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
using WpfSample1.Data.Models;
using WpfSample1.Services.Interfaces;

namespace WpfSample1.Day6
{
    /// <summary>
    /// Interaction logic for DbAccessDemo.xaml
    /// </summary>
    public partial class DbAccessDemo : Window
    {
        private readonly ISampleService _service;

        public DbAccessDemo(ISampleService service)
        {
            InitializeComponent();
            _service = service;
            SetGridData();
        }


        void SetGridData()
        {
            List<SeaFood> data = _service.GetSeaFoods();
            gridSeaFood.ItemsSource = data;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (gridSeaFood.SelectedItem != null)
            {
                SeaFood seaFood = (SeaFood)gridSeaFood.SelectedItem;
                //MessageBox.Show($"{seaFood.Ma} - {seaFood.Ten} -  {seaFood.Gia} - {seaFood.XuatXu}");
                var _result = _service.UpdateSeaFood(seaFood);    
                if (_result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!" , "Thông báo");
                    SetGridData();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập giá trị!", "Thông báo");
            }
            
        }
    }
}
