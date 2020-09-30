using ShowView3.ViewModel;
using System.Windows;

namespace ShowView3.View
{

    public partial class SubView : Window
    {
        SubViewModel vm;
        public SubView(SubViewModel viewModel)
        {
            InitializeComponent();

            this.vm = viewModel;
            this.DataContext = vm;
        }

    }
}
