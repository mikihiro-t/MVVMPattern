using ShowView2.Model;
using ShowView2.View;
using ShowView2.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowView2
{
    /// <summary>
    /// 全てのViewとViewModelとのバインディングを処理し、Viewを表示する。
    /// public staticにしていない。
    /// </summary>
    class ViewController
    {
        public void ShowSubView(SubManager model)
        {
            var viewModel = new SubViewModel(model);
            //ShowView2のこの例では、ここでDataContextを設定している。
            //ShowView3では、コンストラクターの引数でviewModelをviewに渡してViewのコードビハインドでDataContextを設定している。
            var view = new SubView() { DataContext = viewModel }; 
            view.Show();
        }

    }
}
