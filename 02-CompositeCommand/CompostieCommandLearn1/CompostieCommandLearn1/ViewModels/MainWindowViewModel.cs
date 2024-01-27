using Prism.Commands;
using Prism.Mvvm;
using System;

namespace CompostieCommandLearn1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _curTime;

        public string CurTime
        {
            get { return _curTime; }
            set { SetProperty(ref _curTime, value);
               // TimeCommand.RaiseCanExecuteChanged();
            }
        }

        private string _messageYes;

        public string MessageYes
        {
            get { return _messageYes; }
            set { SetProperty(ref _messageYes, value); }
        }

        private bool kkk = true;

        public CompositeCommand Btn1CompositeCommand { get; private set; }

        //public DelegateCommand TimeCommand { get;private set;}

        public MainWindowViewModel()
        {
            Btn1CompositeCommand = new CompositeCommand();
            //TimeCommand = new DelegateCommand(ExcuteTime, CanExcuteTime);
            //可以不写条件
            Btn1CompositeCommand.RegisterCommand(new DelegateCommand(ExcuteTime));
            Btn1CompositeCommand.RegisterCommand(new DelegateCommand(ExcuteMessage, CanExcuteMessage));
        }

        private bool CanExcuteMessage()
        {
            return true;
        }

        private bool CanExcuteTime()
        {
            return true;
        }

        private void ExcuteMessage()
        {
            CurTime = DateTime.Now.ToString();
        }

        private void ExcuteTime()
        {
            MessageYes = "Yes";
        }
    }
}
