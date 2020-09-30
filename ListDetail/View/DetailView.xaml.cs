using System;
using System.Windows;
using ListDetail.ViewModel;

namespace ListDetail.View
{

    public partial class DetailView : Window
    {

        DetailViewModel vm;

        public DetailView(DetailViewModel viewModel)
        {
            InitializeComponent();

            this.vm = viewModel;
            this.DataContext = vm;

            //ウインドウのALT+F4や×では呼び出されない。その場合は、Viewのコードビハインドでイベントにし、ViewModelのメソッドを呼び出す処理にした方が楽。
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }

    }
}
