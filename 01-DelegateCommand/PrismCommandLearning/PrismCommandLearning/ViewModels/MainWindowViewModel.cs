using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;

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

        public DelegateCommand BeginTimeTick { get; private set; }


        public MainWindowViewModel()
        {
            CurrentTime = DateTime.Now.ToString();


            //1.普通方法
            //BeginTimeTick = new DelegateCommand(ShowTime);

            //2.Task
            BeginTimeTick = new DelegateCommand(async () => await TimeTickTask());

            //3.Await
            //BeginTimeTick = new DelegateCommand(awaitMethod);
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
