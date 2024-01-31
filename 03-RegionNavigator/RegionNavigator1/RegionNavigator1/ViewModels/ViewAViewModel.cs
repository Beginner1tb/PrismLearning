using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegionNavigator1.ViewModels
{
    public class ViewAViewModel : ViewModelRegionBase
    {
        public ViewAViewModel(IRegionManager regionManager)
      : base(regionManager)
        {
        }
    }
}
