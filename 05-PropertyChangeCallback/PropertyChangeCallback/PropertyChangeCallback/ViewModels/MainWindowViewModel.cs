using Prism;
using Prism.Mvvm;
using System;
using System.Diagnostics;

namespace PropertyChangeCallback.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }




        private bool _sasd;

        public bool Sasd
        {
            get => _sasd;
            //某种方式上已经实现了委托，不在需要IActiveAware接口的事件，注意value是此时Sasd绑定的值
            set => SetProperty(ref _sasd, value, () => {
                if (value)
                    OnIsActive();
                else
                    OnIsNotActive();
            });
        }

        private void OnIsNotActive()
        {
            Debug.WriteLine("333");
        }

        private void OnIsActive()
        {
            Debug.WriteLine("444");
        }



        public MainWindowViewModel()
        {

        }
    }
}
