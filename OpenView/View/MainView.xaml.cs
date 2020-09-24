using System.Windows;

namespace ShowView1
{

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
