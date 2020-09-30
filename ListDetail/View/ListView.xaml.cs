using ListDetail.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListDetail.View
{

    public partial class ListView : Window
    {
        ListViewModel vm;
        public ListView(ListViewModel viewModel)
        {
            InitializeComponent();

            this.vm = viewModel;
            this.DataContext = vm;
        }
    }
}
