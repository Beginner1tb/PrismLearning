using EventAggregator1.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;


namespace EventAggregator1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        //代表初始时加载的窗口，注意必须时Window,不能使用UserControl
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
            //return Container.Resolve<PrismWindow1>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
