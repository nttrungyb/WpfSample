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
using WpfSample1.Models;
using WpfSample1.Services.Interfaces;

namespace WpfSample1.Day6
{
    /// <summary>
    /// Interaction logic for DbAccessDemo.xaml
    /// </summary>
    public partial class DbAccessDemo : Window
    {
        private readonly ISampleService _service;

        List<SeaFoodWithCheckBox> gridData;

        public DbAccessDemo(ISampleService service)
        {
            InitializeComponent();
            _service = service;
            SetGridData();
        }

        void SetGridData()
        {
            gridData = _service.GetSeaFoods();
            gridSeaFood.ItemsSource = gridData;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (gridSeaFood.SelectedItem != null)
            {
                SeaFoodWithCheckBox seaFood = (SeaFoodWithCheckBox)gridSeaFood.SelectedItem;
                //MessageBox.Show($"{seaFood.Ma} - {seaFood.Ten} -  {seaFood.Gia} - {seaFood.XuatXu}");
                var _result = _service.UpdateSeaFood(seaFood);
                if (_result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo");
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            gridData.Add(new SeaFoodWithCheckBox() { Ma = 0, Ten = "", Gia = 1000, XuatXu = "", Chon = false });
            gridSeaFood.Items.Refresh();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            SeaFoodWithCheckBox seaFood = (SeaFoodWithCheckBox)gridSeaFood.SelectedItem;
            if (seaFood.Ma == 0)
            {
                gridData.Remove(seaFood);
                gridSeaFood.Items.Refresh();
            }
            else
            {
                var _result = _service.RemoveSeaFood(seaFood.Ma);
                if (_result > 0)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                    SetGridData();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo");
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
