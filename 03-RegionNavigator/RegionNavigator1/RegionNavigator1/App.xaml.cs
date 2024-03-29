﻿using Prism.Ioc;
using RegionNavigator1.Views;
using System.Windows;

namespace RegionNavigator1
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
            //containerRegistry.Register<Services.IBook, Services.Book>();

            containerRegistry.RegisterForNavigation<ViewA>();
            //containerRegistry.RegisterForNavigation<BookNameView>();
            containerRegistry.RegisterForNavigation<ButtonTest1>();
            containerRegistry.RegisterForNavigation<BookName1>();
            //containerRegistry.RegisterForNavigation<NavigatorButton>();

            // containerRegistry.RegisterForNavigation<OptionsView>();
        }
    }
}
