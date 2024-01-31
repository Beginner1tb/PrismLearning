## Prism学习记录
***
### 1.MD乱码解决
window下一般默认编码方式是gb2312，github上是utf-8，因此当上传带中文的markdown文件时，可能出现乱码。可以使用记事本打开markdown格式文件，另存为，就会出现可以选择编码方式的对话框，选择utf-8，即可。。
### 2. 无法在工程中建立指定名称的文件夹
原因可能是使用了Git工具，可以参考网页 <a href="https://www.cnblogs.com/lanrenka/p/17678884.html" title="Visual Studis 2019添加解决方案文件夹报错：未将对象引用设置到对象的实例">Visual Studis 2019添加解决方案文件夹报错：未将对象引用设置到对象的实例</a>  
实际操作为
1. 在工程内先建立默认文件夹NewFolder1;
2. 打开工程对应的.sln文件，用Notepad++打开;
3. 修改相应的文件名NewFolder1;
4. 重新打开工程，确认，重新加载