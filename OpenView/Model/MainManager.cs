using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenView
{
    class MainManager : INotifyPropertyChanged
    {
        public static MainManager Current { get; set; }


        public static int Count { get; set; } //こちらのstaticは、想定どおり

        private string _text1;
        public string Text1
        {
            get => _text1;
            set => SetField(ref _text1, value);
        }

        private string _Text2;
        public string Text2
        {
            get => _Text2;
            set => SetField(ref _Text2, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public MainManager()
        {
            Current = this;  //イニシャライズされるたびにCurrentは変わる。　MainManager自体はstaticで無いので複数のインスタンスがありえる。けれども、Currentは、そのうち、最新のMainMagagerになる。

            Count += 1;
            Title = Count + "番目のMainView";

        }

        public void Calculate()
        {
            Text2 = Text1 + " added";

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

    }
}
