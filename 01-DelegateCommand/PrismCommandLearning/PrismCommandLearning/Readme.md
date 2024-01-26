#### 注意：1. 绑定的属性用法与一般属性用法不同，要注意BindableBase的属性设置方法
#### 2. DelegateCommand仅使用了简单的方法，还有其他方法要学习
#### 3. 本内容仅针对MainWindow与MainWindowViewModel，如果是contentcontrol下的Region不适用
---
#### 2024.1.26更新
1. DelegateCommand的几种方式主要是界面数据信息通知的方式不同  
(1) **原始的方式**：类似ICommand实现，需要在CanExcute对应的属性set部分增加RaiseCanExecuteChanged()方法；  
(2) **ObservesProperty方式**：在DelegateCommand初始化时使用DelegateCommand的ObservesProperty(() => {实现条件})的方法；  
(3) **ObservesCanExecute方式**：在DelegateCommand初始化时使用DelegateCommand的ObservesCanExecute(() => {实现条件})的方法，此时并不需要CanExcute方法，其包含在了实现条件内；  
(4) 除此之外还有个**带参数的通用方法**：以上方式默认Execute方法不带参数，但可以带参数的，参数来源是控件的CommandParameter属性，而且声明此种类型的DelegateCommand是需要带Action< T >委托，注意形式不同；
2. radiobutton也能使用类似checkbox的方式来实现带条件的DelegateCommand；
3. 以上Command仅针对控件默认的简单动作，一般视为clicked，如果较为复杂的控件如datagrid，如实现selectionChanged事件，可以使用事件可以通过 EventToCommand 行为与命令关联，而不是直接使用 Command 属性，使用了 i:Interaction.Triggers 来定义触发器，然后使用 i:EventTrigger 来监听 SelectionChanged 事件。 InvokeCommandAction 行为允许我们将事件绑定到命令；
4. Interaction.Triggers 等内容现在是Microsoft.Xaml.Behaviors.Wpf的内容，注意Xaml引用，原有的System.Windows.Interactivity已过时；
5. ObservesCanExecute，注意只能观察一个属性，不能链式注册，一个触发一个