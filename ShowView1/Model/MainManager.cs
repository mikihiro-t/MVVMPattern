using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShowView1
{
    class MainManager : INotifyPropertyChanged
    {

        //■2 MainManagerが1つのみなら、Currentを利用してViewModelに、Modelをセットできる。
        //public static MainManager Current { get; set; }


        public static int Count { get; set; }

        private string _text1;
        public string Text1
        {
            get => _text1;
            set => SetField(ref _text1, value);
        }

        private string _text2;
        public string Text2
        {
            get => _text2;
            set => SetField(ref _text2, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public MainManager()
        {
            //■2
            //Current = this;  //イニシャライズされるたびにCurrentは変わる。　MainManager自体はstaticで無いので複数のインスタンスがありえる。けれども、Currentは、最後にNewされたMainMagagerになる。

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
