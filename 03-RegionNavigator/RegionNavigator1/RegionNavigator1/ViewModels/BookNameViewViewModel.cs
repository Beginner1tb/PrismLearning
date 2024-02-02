using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RegionNavigator1.Services;

namespace RegionNavigator1.ViewModels
{

    [Obsolete("此界面错误的绑定到了MainWindowViewModel,不再使用")]
    public class BookNameViewViewModel : ViewModelRegionBase
    {
        public BookNameViewViewModel(IRegionManager regionManager)
: base(regionManager)
        {
           // _book = book;
            //BookName bookName = new BookName();
            //NewsFeed.Clear();

            //Names.Clear();

            //foreach (var item in bookName.listNames)
            //{
            //    NewsFeed.Add(item);
            //    Names.Add(item);
            //}
        }
        private readonly IBook _book;

        private List<string> _names;
        public List<string> Names
        {
            get => _names;
            set => SetProperty(ref _names, value);
        }



        public ObservableCollection<string> NewsFeed { get; private set; } = new ObservableCollection<string>();



        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //BookName bookName = new BookName();
            //NewsFeed.Clear();



            //foreach (var item in _book.GetBookNames())
            //    NewsFeed.Add(item);
        }
    }

    //public class BookName
    //{
    //    public List<string> listNames;
    //    public BookName()
    //    {
    //        listNames = new List<string>
    //        {
    //            "aisda",
    //            "sads",
    //            "qweqwe",
    //        };
    //    }
    //}




}
