using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;

namespace OpenView2
{
    class SubViewModel : INotifyPropertyChanged, IDisposable
    {

        private SubManager Model { get; }

        public ReactiveProperty<string> Text1 { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> Title { get; set; } = new ReactiveProperty<string>();

        public SubViewModel(SubManager model)
        {
            Model = model;

            this.Text1 = Model.ToReactivePropertyAsSynchronized(x => x.Text1).AddTo(Disposable);
            this.Title = Model.ToReactivePropertyAsSynchronized(x => x.Title).AddTo(Disposable);

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
