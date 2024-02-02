using Prism.Mvvm;
using Prism.Regions;
using RegionNavigator1.Views;

namespace RegionNavigator1.ViewModels
{
    public class MainWindowViewModel : ViewModelRegionBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //private string _testText = "Prism Application";
        //public string TestText
        //{
        //    get { return _testText; }
        //    set { SetProperty(ref _testText, value); }
        //}

        public MainWindowViewModel(IRegionManager regionManager)
            : base(regionManager)
        {
            RegionManager.RegisterViewWithRegion("ContentRegion", typeof(NavigatorButton));
            //RegionManager.RegisterViewWithRegion("DisplayRegion", typeof(BookNameView));

        }
    }
}
