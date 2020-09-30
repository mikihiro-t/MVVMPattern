using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using ListDetail.Model;
using ListDetail.ViewModel;

namespace ListDetail.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Variables

        public Info Model { get; }

        public ReactiveProperty<string> Text1 { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<decimal> Number1 { get; set; } = new ReactiveProperty<decimal>();
        public ReactiveProperty<bool> Check1 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveCommand ButtonClose { get; } = new ReactiveCommand();
        public Action CloseAction { get; set; } //https://stackoverflow.com/questions/4376475/wpf-mvvm-how-to-close-a-window

        #endregion

        public DetailViewModel(Info model)
        {
            Model = model;

            this.Text1 = Model.ToReactivePropertyAsSynchronized(x => x.Text1).AddTo(Disposable);
            this.Number1 = Model.ToReactivePropertyAsSynchronized(x => x.Number1).AddTo(Disposable);
            this.Check1 = Model.ToReactivePropertyAsSynchronized(x => x.Check1).AddTo(Disposable);
            ButtonClose.Subscribe(_ => Close()).AddTo(Disposable);
        }



        /// <summary>
        /// Windowの、ALT+F4や、×では、呼び出され無い。
        /// </summary>
        private void Close()
        {
            CloseAction();
            Dispose();

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
                    Debug.WriteLine("DetailViewModel Disposed");
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
