using InitialModule1.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Security.Principal;
using System.Windows;

namespace InitialModule1
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

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //Prism中，告诉Prism去加载app.config文件中的模块                                                                                                                                                                                                                                                                              
            return new ConfigurationModuleCatalog();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            var identity = WindowsIdentity.GetCurrent();

            bool isAdmin = new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);

        }
    }
}
