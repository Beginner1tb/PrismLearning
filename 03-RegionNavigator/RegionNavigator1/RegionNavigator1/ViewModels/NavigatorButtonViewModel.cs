using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RegionNavigator1.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegionNavigator1.ViewModels
{
    public class NavigatorButtonViewModel : ViewModelRegionBase
    {
        public NavigatorButtonViewModel(IRegionManager regionManager)
      : base(regionManager)
        {
        }

        public DelegateCommand ChooseACommand => new DelegateCommand(() =>
        {
            //静态命名Region
            //RegionManager.RequestNavigate(Regions.DisplayRegion, nameof(ViewA));
            RegionManager.RequestNavigate("DisplayRegion", nameof(ViewA));
        });
    }
}
