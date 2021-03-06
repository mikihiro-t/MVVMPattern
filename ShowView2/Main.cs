﻿using ShowView2.Model;
using ShowView2.View;
using ShowView2.ViewModel;
using System;
using System.Diagnostics;

namespace ShowView2
{
    class Main
    {
        readonly ViewController viewController = new ViewController();

        public Main()
        {

            Start();
            Start2();

        }

        private void Start()
        {
            for (int i = 1; i < 3; i++)
            {
                var model = new SubManager() { Text1 = i.ToString() + "ViewController内でShow" };
                viewController.ShowSubView(model);
            }

        }

        /// <summary>
        /// Closedイベントを追加。ViewControllerを利用しない。
        /// </summary>
        private void Start2()
        {

            for (int i = 1; i < 3; i++)
            {
                var model = new SubManager() { Text1 = i.ToString() + "Model内でShow"};
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





}
