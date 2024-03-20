### Region Adapt学习
#### 1. RegionAdapt原因
1. Region需要转换的原因：原有的ContentControl控件可以视为**空白**的控件，里面没有任何的结构，当然内部也不能添加控件。如果需要特殊的排布和事件，就需要将原有的控件转换成某种有特性的Region
#### 2. RegionAdapt使用方法
1. 首先需要建立对应的的转换类，以XXXRegionAdapt.cs为例，类需要继承RegionAdapterBase<>，同时构造函数需要调用基类的构造函数base(...)，并且要重载Adapt()和CreateRegion()方法，Adapt()表示在此region下，该控件的动作，CreateRegion()表示的是创建region的几种固定方法，包括每次只激活一个的SingleActive，全部激活的AllActive等;
2. 其次，要在App.xaml.cs文件中重载ConfigureRegionAdapterMappings(...)方法，表示把某个控件注册映射，从XXX注册映射到XXXRegionAdapt，表示启用该Region方法；
3. 这时，就可以在Xaml里将prism:RegionManager添加到该控件里，即可以进行管理和使用了；
#### 3. 应用小tips（暂时）
1. ViewModels里通过RegisterViewWithRegion()进行注册时，等于就是将用户控件view注册到指定的region中来，用多少注册多少