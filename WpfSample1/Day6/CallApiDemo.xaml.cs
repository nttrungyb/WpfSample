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
using WpfLibrary1.Services.Models;
using WpfSample1.Services.Interfaces;

namespace WpfSample1.Day6
{
    /// <summary>
    /// Interaction logic for CallApiDemo.xaml
    /// </summary>
    public partial class CallApiDemo : Window
    {
        private readonly ISampleService _service;

        List<PosInfoViewModel> gridData;
        public CallApiDemo(ISampleService service)
        {
            InitializeComponent();
            _service = service;
            //SetGridData();
        }

        void SetGridData(string branchCode)
        {
            gridData = _service.GetPosList(branchCode);
            gridPos.ItemsSource = gridData;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var _branchCode = txtBranchCode.Text;
            if (string.IsNullOrEmpty(_branchCode) || _branchCode.Length != 2)
            {
                MessageBox.Show("Bạn chưa nhập mã chi nhánh hoặc nhập sai định dạng (2 ký tự)", "Thông báo");
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Wait;
                SetGridData(_branchCode);
                Mouse.OverrideCursor = null;
            }
        }
    }
}
