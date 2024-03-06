using Prism;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PropertyChangeCallback.ViewModels
{
    //使用IActiveAware接口方式，可以被替代
    public abstract class ViewModelBase : BindableBase, IActiveAware
    {
        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, () => {
                if (value)
                    OnIsActive();
                else
                    OnIsNotActive();
            });
        }

        public event EventHandler IsActiveChanged;

        protected virtual void OnIsActive() { Debug.WriteLine("111"); }
        protected virtual void OnIsNotActive() { Debug.WriteLine("222"); }
    }
}
