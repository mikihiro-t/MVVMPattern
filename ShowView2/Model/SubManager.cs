using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShowView2
{
    class SubManager : INotifyPropertyChanged
    {

        public static int Count { get; set; }

        private string _text1;
        public string Text1
        {
            get => _text1;
            set => SetField(ref _text1, value);
        }


        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public SubManager()
        {
            Count += 1;
            Title = Count + "番目のMainView";

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
