using System;
using System.Diagnostics;

namespace OpenView2
{
    class Main
    {
        readonly ViewManager viewManager = new ViewManager();

        public Main()
        {

            Start();

        }

        /// <summary>
        /// ViewManagerで、Viewの処理を集約
        /// </summary>
        private void Start()
        {
            for (int i = 1; i < 3; i++)
            {
                var model = new SubManager() { Text1 = i.ToString() };
                viewManager.ShowSubView(model);
            }

        }

        /// <summary>
        /// Closedイベントを追加して表示
        /// </summary>
        private void Start2()
        {

            for (int i = 1; i < 3; i++)
            {
                var model = new SubManager() { Text1 = i.ToString() };
                var viewModel = new SubViewModel(model);
                var view = new SubView() { DataContext = viewModel };
                view.Closed += new EventHandler(SubView_Closed);
                view.Show();

            }

        }


        private void SubView_Closed(object sender, EventArgs e)
        {
            Debug.WriteLine(sender.ToString() + "Closed");

        }
    }


    class ViewManager
    {
        public void ShowSubView(SubManager model)
        {
            var viewModel = new SubViewModel(model);
            var view = new SubView() { DataContext = viewModel };
            view.Show();
        }

    }


}
