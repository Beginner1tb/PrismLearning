﻿using Dialog1.ViewModels;
using Dialog1.Views;
using Prism.Ioc;
using System.Windows;

namespace Dialog1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogShow1, DialogShow1ViewModel>();
        }
    }
}
