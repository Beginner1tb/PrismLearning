using EventAggregator.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _message;
        public ObservableCollection<string> Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            Message = new ObservableCollection<string>();
            Message.Add("This is a blank message");
            eventAggregator.GetEvent<MessageSendEvent>().Subscribe(MessgeReceived,threadOption:ThreadOption.BackgroundThread);
        }

        private void MessgeReceived(string str)
        {
            Message.Add(str);
        }
    }
}
