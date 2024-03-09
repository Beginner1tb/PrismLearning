using Prism.Ioc;
using System.Diagnostics;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace InitialModule1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 直接通过MainWindow注入，改变了MainWindow的结构，不推荐
        //private readonly IContainerProvider _containerProvider;
        //public MainWindow(IContainerProvider containerProvider)
        //{
        //    InitializeComponent();
        //    _containerProvider = containerProvider;
        //    var TestContainer = _containerProvider.Resolve<DITest1>();
        //    Debug.WriteLine(TestContainer.Print());

        //}
        #endregion

        #region 通过一个类来完成中转，再调用这个类，当然，这个可以适应于一般的依赖注入
        private readonly IContainerProvider _containerProvider;
        public MainWindow()
        {
            InitializeComponent();
            //类中转实现依赖注入方法
            //方法1：
            //注意，这里需要知道明确使用的对象类，因为类可以初始化，接口不可以
            //实际上还是调用的具体类
            DITest1 cDITest1 = new DITest1();
            TransitDI transitDI = new TransitDI(cDITest1);
            Debug.WriteLine(transitDI.PubString());

            //方法2：
            //Extension.DependecyInjection里的依赖注入方法，直接引用接口和方法

            ServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddScoped<IDITest1, DITest2>();
            serviceDescriptors.AddScoped<IDITest1, DITest1>();
            using (ServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider())
            {
                IDITest1 test1 = serviceProvider.GetService<IDITest1>();
                //此时有个问题，我并不知道你到底用的是哪个方法，以最新方法为主
                Debug.WriteLine("The result of original DI is " + test1.Print());
                IEnumerable<IDITest1> services = serviceProvider.GetServices<IDITest1>();
                foreach (var item in services)
                {
                    Debug.WriteLine("IDITest1 method is " + item.GetType());
                }
            }

            //方法3：
            //新增一个服务类IDITest1Service,再使用依赖注入获取实例
            ServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1.AddScoped<IDITest1, DITest1>();
            serviceDescriptors1.AddScoped<IDITest1Service>();
            using (ServiceProvider serviceProvider1 = serviceDescriptors1.BuildServiceProvider())
            {
                //如果不加serviceDescriptors1.AddScoped<IDITest1Service>()就会报错对象为空
                IDITest1Service iDITest1Service = serviceProvider1.GetService<IDITest1Service>();
                Debug.WriteLine("The result of dependency class DI is " + iDITest1Service.WriteDownStr());

                //与方法4类似,不需要注入IDITest1Service类，直接调用
                {
                    var iDITest1 = serviceProvider1.GetRequiredService<IDITest1>();
                    var iDITest1Service1 = new IDITest1Service(iDITest1);
                    Debug.WriteLine("The result of dependency another class DI is " + iDITest1Service1.WriteDownStr());
                }
            }

            //方法4：
            //另外一种使用服务类IDITest1Service,再使用依赖注入获取实例的方法
            ServiceProvider serviceProvider2 = new ServiceCollection()
    .AddScoped<IDITest1, DITest1>()
    .BuildServiceProvider();
            using (var scope = serviceProvider2.CreateScope())
            {
                var iDITest1 = scope.ServiceProvider.GetRequiredService<IDITest1>();
                //实际上是通过获取到IDITest1，然后直接使用了IDITest1Service服务类方法
                var iDITest1Service = new IDITest1Service(iDITest1);
                Debug.WriteLine("The result of dependency scope class DI is " + iDITest1Service.WriteDownStr());
            }

        }


        private class TransitDI
        {
            private readonly IDITest1 _dITest11;
            public TransitDI(IDITest1 dITest1)
            {
                _dITest11 = dITest1;
            }

            public string PubString()
            {
                return _dITest11.Print();
            }
        }

        //private class TransitPrismContainer
        //{
        //    private readonly IContainerProvider _containerProvider;

        //    public TransitPrismContainer(IContainerProvider containerProvider)
        //    {
        //        _containerProvider = containerProvider;
        //    }

        //    public string WriteString()
        //    {
        //        var cDITest1 = _containerProvider.Resolve<DITest1>();
        //        return cDITest1.Print();
        //    }
        //}

        private void TransitDITest2()
        {

        }
        #endregion
    }



}
