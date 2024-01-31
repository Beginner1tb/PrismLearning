### Region和Navigator学习记录
---
#### 1. Region使用注意
1. Region视为一种容器，不是仅提供单纯的显示；
2. Region在涉及到Navigate动作时，需要在App.xaml中的RegisterTypes内先注册，表示container里存在这个动作；
3. RegisterTypes中还有其他的动作，待学习
4. 目前看来仅显示的Region不一定需要在RegisterTypes内注册，待观察
#### 2. RegionManager使用
1. 目前所有的Region管理都是通过构造函数初始化RegionManager完成，该构造函数派生自ViewModelRegionBase类，实现了多个接口；
2. 与官方示例不同，由于所有管理都是通过统一的RegionManager完成，所以不管是MainViewModel还是别的ViewModel中，是使用构造函数的RegionManager；
#### 3. 建立View和ViewModel快捷方法
1. 可以使用Prism自带的模板创建，在**Views**文件夹下建立**Prism UserControl**文件,工程会自动创建相应的ViewModel类；
2. 当然，类结构是默认的，如果需要使用2.中的RegionManager，则要修改相应的构造函数
#### 4. RegisterViewWithRegion使用小结
1. 界面上的contentcontrol可以使用字符串，也可以指定静态字段表示
2. Region在contentcontrol做单一显示不一定需要在RegisterTypes内先注册
#### 5. 从0开始MainWindow.xaml注入Region和Navigator尝试
1. 建立空的Prism的App工程；
2. 在MainWindow.xaml上划分好contentcontrol位置，并设置好RegionName；
3. 建立ViewModelRegionBase基类，实现相关的接口；
4. 根据ViewModelRegionBase基类，建立View和ViewModel；
5. 根据需求在各自的View和ViewModel上写好数据和命令绑定方式；
6. 显示内容需要RegisterViewWithRegion到相应的RegionName上；
7. 如果涉及到Navigator,Singleton等事件，则需要在App.xaml中的RegisterTypes内先注册
