using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Diagnostics;
using Dialog1.Core;


namespace Dialog1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private IDialogService _dialogService;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private string _dialogRes = "Null";
        public string DialogRes
        {
            get { return _dialogRes; }
            set { SetProperty(ref _dialogRes, value); }
        }
        private DelegateCommand _showDialogCmd;

        public DelegateCommand ShowDialogCmd => _showDialogCmd ?? (_showDialogCmd = new DelegateCommand(ShowDialog));


        private void ShowDialog()
        {
            TestClass1 testClass1 = new TestClass1();
            testClass1.name = "Test String";
            testClass1.num = 22;
            //注意，这里的DialogParameters只能用string
            _dialogService.ShowDialog("DialogShow1", new DialogParameters(string.Format(@"message1={0}", testClass1.name)), r =>
              {
                  Debug.WriteLine(r.Parameters.ToString());

                  //一般拿来判断ButtonResult
                  if (r.Result == ButtonResult.Yes)
                      DialogRes = "Result is Yes";
                  else if (r.Result == ButtonResult.No)
                      DialogRes = "Result is No";
                  else if (r.Result == ButtonResult.Cancel)
                      DialogRes = "Result is Cancel";
                  else
                      DialogRes = "I Don't know what you did!?";
              });

            //_dialogService.ShowDialog("DialogShow1");
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
