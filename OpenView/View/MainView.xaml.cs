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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        MainViewModel vm = new MainViewModel();
        public MainView()
        {
            InitializeComponent();

            this.DataContext = vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cls = new MainView();
            cls.Show();

        }
    }
}
