using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegionNavigator1.ViewModels
{
   public abstract  class ViewModelBase:BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {
            
        }
    }
}
