using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListDetail
{
    public class Info : INotifyPropertyChanged
    {

        private string _text1;
        public string Text1
        {
            get => _text1;
            set => SetField(ref _text1, value);
        }

        private decimal _number1;
        public decimal Number1
        {
            get => _number1;
            set => SetField(ref _number1, value);
        }


        private bool _check1;
        public bool Check1
        {
            get => _check1;
            set => SetField(ref _check1, value);
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
