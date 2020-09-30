using System;
using System.Collections.Generic;
using System.Text;
using ListDetail.View;
using ListDetail.ViewModel;
using ListDetail.Model;



namespace ListDetail
{
    /// <summary>
    /// ViewとViewModelとのバインディングを処理し、Viewを表示する。
    /// Viewへの参照は、ViewControllerが持つはず。
    /// </summary>

    public static class ViewController
    {
        public static void ShowDetailView(Info model)
        {
            var viewModel = new DetailViewModel(model);
            var view = new DetailView(viewModel);
            view.Show();
        }

        public static void ShowListView(ListManager model)
        {
            var viewModel = new ListViewModel(model);
            var view = new ListView(viewModel);
            view.Show();

        }
    }
}
