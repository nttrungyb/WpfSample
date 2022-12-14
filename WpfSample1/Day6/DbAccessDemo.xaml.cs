﻿using System;
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
            List<SeaFood> data = _service.GetSeaFoods();
            gridSeaFood.ItemsSource = data;
        }
    }
}
