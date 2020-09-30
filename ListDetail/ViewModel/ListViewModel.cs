using ListDetail.Model;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Reactive;

namespace ListDetail.ViewModel
{
    public class ListViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Variables

        private ListManager Model { get; }
        public ReadOnlyReactiveCollection<DetailViewModel> InfoList { get; }

        public ReactiveProperty<int> AddedNumber { get; set; } = new ReactiveProperty<int>();

        public ReactiveCommand ButtonAdd { get; } = new ReactiveCommand();

        public ReactiveCommand ButtonClearList { get; } = new ReactiveCommand();


        /// <summary>
        /// DataGridの行のShowボタン
        /// パラメータとして、DetailViewModelを受け取る。
        /// </summary>
        public ReactiveCommand<DetailViewModel> ButtonShow { get; } = new ReactiveCommand<DetailViewModel>();

        public ReactiveCommand<DetailViewModel> ButtonRemove { get; } = new ReactiveCommand<DetailViewModel>();


        #endregion

        public ListViewModel(ListManager model)
        {
            Model = model;

            //DetailViewModelはここでnewしている。
            this.InfoList = this.Model.InfoList.ToReadOnlyReactiveCollection(x => new DetailViewModel(x)).AddTo(Disposable);

            //下記は、参考まで。
            InfoList.ObserveResetChanged().Subscribe(x => Reset(x)).AddTo(Disposable);
            InfoList.ObserveRemoveChangedItems().Subscribe(x => ItemsRemoved(x)).AddTo(Disposable);
            //上記の、ObserveRemoveChangedItems　は、下記の行に置き換えられるはず。
            //InfoList.CollectionChangedAsObservable().Subscribe(x => CollectionChanged(x)).AddTo(Disposable);


            this.AddedNumber = Model.ToReactivePropertyAsSynchronized(x => x.AddedNumber).AddTo(Disposable);
            ButtonAdd.Subscribe(_ => Add()).AddTo(Disposable);
            ButtonClearList.Subscribe(_ => ClearList()).AddTo(Disposable);

            ButtonShow.Subscribe(x => ShowDetail(x)).AddTo(Disposable);
            ButtonRemove.Subscribe(x => Remove(x)).AddTo(Disposable);

        }

        private void ShowDetail(DetailViewModel infoVM)
        {
            //XAML で、CommandParameter = "{Binding}"　としているので、DetailViewModelがパラメータとして渡されてくる。
            Model.ShowDetail(infoVM.Model);
        }


        private void Remove(DetailViewModel infoVM)
        {
            Model.Remove(infoVM.Model);
        }

        private void Add()
        {
            Model.Add();
        }
        private void ClearList()
        {
            Model.ClearList();
        }

        private void Reset(Unit x)
        {
            //DetailVeiwModel Disposed は実行されている。

            //ListManagerで、InfoList.Clear();をした時に、呼び出されている。
        }


        private void ItemsRemoved(DetailViewModel[] x)
        {
            //DetailViewModel Disposed は実行されている。

            //ListManagerで、InfoList.Remove, InfoList.RemoveAt をした時に、呼び出されている。
            return;

            //明示的にDetailViewModelをDisposeしたい場合。
            foreach (var item in x)
            {
                item.Dispose();
            }
        }


        /// <summary>
        /// 参考
        /// </summary>
        /// <param name="e"></param>
        private void CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {

            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //InfoList変更時で、Removeの時に、DetailViewModelを明示的にDisposeしたい場合。
                var cnt = e.OldItems.Count;
                for (int i = 0; i < cnt; i++)
                {
                    ((DetailViewModel)e.OldItems[i]).Dispose();
                }

            }

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region Dispose
        private bool disposedValue;
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Debug.WriteLine("ListViewModel Disposed");
                    this.Disposable.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
