using CustomRegionAdapt1.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace CustomRegionAdapt1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("StackRegion", typeof(ViewA));
        }
    }
}
