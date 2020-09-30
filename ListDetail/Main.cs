using ListDetail.Model;
using System;
using System.Diagnostics;
using ListDetail.View;
using ListDetail.ViewModel;


namespace ListDetail
{
    class Main
    {


        public Main()
        {

            StartList();

        }

        private void StartList()
        {

            var list = new ListManager();
            ViewController.ShowListView(list);

        }
 
    }






}
