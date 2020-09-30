using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListDetail.Model
{
    public class ListManager : INotifyPropertyChanged
    {

        #region Variables

        public ObservableCollection<Info> InfoList { get; set; } = new ObservableCollection<Info>();

        private int _addedNumber;
        /// <summary>
        /// InfoをListに追加する数。
        /// </summary>
        public int AddedNumber
        {
            get => _addedNumber;
            set => SetField(ref _addedNumber, value);
        }


        public ListManager()
        {
            AddedNumber = 10;

        }

        #endregion


        public void ShowDetail(Info info)
        {
            ViewController.ShowDetailView(info);
        }

        public void Add()
        {
            for (int i = 0; i < AddedNumber; i++)
            {
                InfoList.Add(new Info() { Text1 = "Text" + i.ToString(), Number1 = i, Check1 = true });
            }

        }

        public void Remove(Info info)
        {
            InfoList.Remove(info);
        }

        public void ClearList()
        {

            //ClearとRemoveでActionが異なる。ここでは、Clearで処理している。

            //VMのObserveResetChangedが利用される。
            //VMのCollectionChangedでActionがReset
            InfoList.Clear();

            return;

            //https://stackoverflow.com/questions/5118513/removeall-for-observablecollections/5118635#5118635
            for (int i = InfoList.Count() - 1; i >= 0; i--)
            {
                //VMのObserveRemoveChangedItems
                //VMのCollectionChangedでActionがRemove
                InfoList.RemoveAt(i);
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

    }


}
