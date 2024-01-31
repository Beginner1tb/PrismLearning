using System;
using System.Collections.Generic;
using System.Text;
using Prism.Regions;

namespace RegionNavigator1.ViewModels
{
    public class ViewModelRegionBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {

        protected IRegionManager RegionManager { get; private set; }
        public ViewModelRegionBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
