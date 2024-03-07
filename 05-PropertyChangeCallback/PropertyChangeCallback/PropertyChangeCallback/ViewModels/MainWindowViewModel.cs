using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Diagnostics;

namespace PropertyChangeCallback.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //private string _title = "Prism Application";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        #region 配合DelegateCommand实现两个控件的联动
        private int _randomInt;

        public int RandomInt
        {
            get { return _randomInt; }
            set { SetProperty(ref _randomInt, value, () =>
            {
                if (value > 10)
                    MoreThan10();
                else
                    LessThan10();
            }); }
        }

        private void LessThan10()
        {
            Debug.WriteLine("Current Integer is " + RandomInt + " It's Less Than 10");
        }

        private void MoreThan10()
        {
            Debug.WriteLine("Current Integer is " + RandomInt + " It's More Than 10");
        }
        public DelegateCommand RandomIntCmd => new DelegateCommand(() =>
        {
            Random random = new Random();
            RandomInt = random.Next(0, 20);

        });
        #endregion

        #region 单checkbox的bool属性
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

        #endregion

        public MainWindowViewModel()
        {

        }
    }
}
