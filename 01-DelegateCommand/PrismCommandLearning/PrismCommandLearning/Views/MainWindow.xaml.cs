using System.Windows;
using System.Collections.ObjectModel;

namespace PrismCommandLearning.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class MyData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public partial class MainWindow : Window
    {

        public ObservableCollection<MyData> MyDataCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            MyDataCollection = new ObservableCollection<MyData>
        {
            new MyData { Name = "John", Age = 25 },
            new MyData { Name = "Jane", Age = 30 },
            // 添加更多数据项...
        };

            // 将数据集合绑定到 DataGrid
            myDataGrid.ItemsSource = MyDataCollection;
        }
    }
}
