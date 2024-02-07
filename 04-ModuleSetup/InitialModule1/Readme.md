## 学习记录
### 1. Module的理解
1. Module可以看作.dll形式的插件；
2. 因此作为dll本身，应用方式与其他调用dll方式相同，比如默认与exe在一个目录下；
3. 使用module本质上还是需要找到module的dll文件，不管是通过文件还是配置；
4. 使用module报错可能主程序并不会出现断点或者跳出等问题，需要在module本身写好Exception；