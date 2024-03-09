using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RegionNavigator1.ViewModels
{
    public class BookName1ViewModel : ViewModelRegionBase
    {

        //1. Binding一定是属性，不能是普通字段
        //public string TextName; //{ get; private set; }
        public string TextName { get; private set; }

        //2. 使用普通的属性没有事件监听器功能，即外部事件不能改变属性值，必须使用BindableBase.SetProperty
        private List<string> _books = new List<string>
            {
                "13454",
                "5234",
                "21",
            };
        public List<string> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }

        public BookName1ViewModel(IRegionManager regionManager)
      : base(regionManager)
        {
            NewsFeed = new ObservableCollection<string>
            {
                "1",
                "3232",
                "32154",
            };

            TextName = "1312";
        }

        public DelegateCommand RefreshCommand => new DelegateCommand(OnRresh1);

        private void OnRresh1()
        {
            Books.Clear();
            Books = new List<string>()
           {
              "sadasd",
              "sadaq",
              "jhsiq"
           };
        }
        //错误写法，必须BindableBase.SetProperty
        private void OnRresh()
        {
            NewsFeed.Clear();
            NewsFeed = new ObservableCollection<string>()
           {
               "1321",
               "12312",

           };

            TextName = "112312";
        }
        //注意，相对Books来说，NewsFeed字段是错误写法，必须使用BindableBase.SetProperty
        public ObservableCollection<string> NewsFeed { get; private set; } = new ObservableCollection<string>();

        //3. 导航按钮事件重载，可以用于按钮切换开始和结束事件
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);

        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);


        }
    }
}
