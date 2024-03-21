using EventAggregator.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        IEventAggregator _ea;
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public DelegateCommand SendCommand { get; private set; }

        //数组中的某个元素绑定
        private string[] _array = new string[10];
        
        public string[] Array
        {
            get { return _array; }
            set { SetProperty(ref _array, value); }
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSendEvent>().Publish(Message);
        }

        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            Message = "View A from your Prism Module";
            Array[0] = "Array Binding 0";
            Array[1] = "Array Binding 1";
            _ea = eventAggregator;
            SendCommand = new DelegateCommand(SendMessage);
        }
    }
}
