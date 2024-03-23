### Dialog Service使用小结
#### 1. Dialog Service作用总结（目前的VS2019的8.0版本）
1. 显示对话框：ShowDialog方法可以显示各种类型的对话框，当然对话框是自定义的；
2. 向对话框传递参数：通过DialogParameters向新加对话框传递参数（目前8.0版本只有String）；
3. 从对话框获取执行结果：从对话框获取ButtonResult结果；
4. 其他新功能未实现（异步，回调等在9.0版本上）
#### 2.使用小结
1. 首先需要在要用到DialogService的ViewModel里，在构造函数注入IDialogService服务；
2. 建立对话框对应的用户控件，并在App.xaml.cs中将用户控件的view和viewmodel注册到container中；
3. 要打开对话框的位置通过DialogService的ShowDialog打开，可以不带参数，也可以带参数和委托；
4. 向对话框发送参数：ShowDialog参数中有一项是DialogParameters，注意此项可以加入一个String参数,但是需要以固定开头，比如```"message={字段名}"```，同时，对话框的IDialogParameters的GetValue方法要获取开头为```message```的string参数；
5. 对话框内容：对话框可以是单独的内容，通过X来关闭，也可以实现IDialogAware的接口来实现响应和传递ButtonResult。其中包括

|类型|名称|作用|备注|
|----|----|----|----|
|String|Title|代表对话框的名称|ShowDialog第一个参数，注意不是普通的文本
|Action|RequestClose|调用代表关闭对话框|IDialogResult是返回给主界面的值，一般为ButtonResult
|bool|CanCloseDialog|是否可以关闭对话框|如果是false，右上角X都无法强制关闭对话框
|void|OnDialogClosed|关闭对话框时调用|
|void|OnDialogOpened|打开对话框时调用|IDialogParameters用来传递主界面的参数（目前是字符串）|

6. RequestClose是一个专用方法，调用时对话框就关闭了，此时可以向主窗口传递ButtonResult，参数就放在RequestClose中；
7. 主界面可以根据委托获取对话框的ButtonResult并进行操作。