using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PrismCommandLearning.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        //注意里的BindableBase派生出的属性方法与propfull自动生成的不同
        private string _currentTime;

        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private bool _canDisplay;

        public bool CanDisplay
        {
            get { return _canDisplay; }
            set
            {
                SetProperty(ref _canDisplay, value);
                ConditionCommand.RaiseCanExecuteChanged();
            }
        }
        //不带条件
        public DelegateCommand BeginTimeTick { get; private set; }

       public DelegateCommand LambdaCommand => new DelegateCommand(() => { ShowTime(); });

        //带条件的
        public DelegateCommand ConditionCommand { get; set; }
        public DelegateCommand DelegateCommandObservesProperty { get; private set; }
        public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }
        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }

        
        public MainWindowViewModel()
        {
            //CurrentTime = DateTime.Now.ToString();

            //不带条件
            //1.普通方法
            //BeginTimeTick = new DelegateCommand(ShowTime);

            //2.Task
            BeginTimeTick = new DelegateCommand(async () => await TimeTickTask());

            //3.Await
            //BeginTimeTick = new DelegateCommand(awaitMethod);

            

            //带条件
            //1.原始方式
            ConditionCommand = new DelegateCommand(Execute, CanExecute);

            //2.ObservesProperty方式
            DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => CanDisplay);

            //3.ObservesCanExecute，注意只能观察一个属性
            DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => CanDisplay);

            //4.带参数输入的通用方式
            ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => CanDisplay);

            

        }

        private void ExecuteGeneric(string parameter)
        {
            MessageBox.Show(parameter);
        }

        private bool CanExecute()
        {
            return CanDisplay;
        }

        private void Execute()
        {
            MessageBox.Show("yes");
        }


        private void ShowTime()
        {
            CurrentTime = DateTime.Now.ToString();
        }

        private Task TimeTickTask()
        {
            return TaskMethod();
        }

        private async Task TaskMethod()
        {
            while (true)
            {
                CurrentTime = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        private async void awaitMethod()
        {
            while (true)
            {
                CurrentTime = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

    }
}
