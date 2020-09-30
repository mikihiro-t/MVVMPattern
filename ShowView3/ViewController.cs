using System;
using System.Collections.Generic;
using System.Text;
using ShowView3.Model;
using ShowView3.View;
using ShowView3.ViewModel;

namespace ShowView3
{
    /// <summary>
    /// 全てのViewとViewModelとのバインディングを処理し、Viewを表示する。
    /// ShowView2と異なり、staticで処理。
    /// </summary>
    public static class ViewController
    {
        public static void ShowSubView(SubManager model)
        {
            var viewModel = new SubViewModel(model);
            var view = new SubView(viewModel);
            view.Show();
        }

    }
}
