using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dialog1.ViewModels
{
    public class DialogShow1ViewModel : BindableBase,IDialogAware
    {

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }



        private string _title = "This is a Test Dialog";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private void CloseDialog(string param)
        {
            ButtonResult result = ButtonResult.None;

            if (param?.ToLower() == "yes")
                result = ButtonResult.Yes;
            else if (param?.ToLower() == "no")
                result = ButtonResult.No;
            else if (param?.ToLower() == "cancel")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
           //RaiseRequestClose("22132");
        }

        private void RaiseRequestClose(DialogResult dialogResult)
        {
            RequestClose.Invoke(dialogResult);
            
        }

        //private void RaiseRequestClose(string str)
        //{

        //    //RequestClose.Invoke(new DialogParameters("21231"));
        //}

        //关闭dialog事件，默认的只能返回IDialogParameters和ButtonResult
        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message1");
            
        }

        public DialogShow1ViewModel()
        {
           
        }
    }
}
