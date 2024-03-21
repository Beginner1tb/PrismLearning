### Event Aggregator使用小结
#### 1. Event Aggregator一些说明
1. EventAggregator类是容器里的一项服务，由IEventAggregator接口提供，用来构造事件；
2. EventAggregator中的Publisher和Subscriber之间是解耦，互无直接关系；
3. EventAggregator是多播的，Publisher可以发布多个事件，当然SubScriber也可以监听同一个事件；
4. EventAggregator可用于模块之间的跨模块事件；
5. Prism库所创建的事件都是类型化事件，便于编译时的错误检查；
#### 2. EventAggregator的使用
1. PubSubEvent<...>类的使用：首先建立专门的一个类，用于容纳PubSubEvent事件，注意，如果由多个事件，可以考虑建立专门的一个.Core类库和文件夹来管理这些类；
2. 创建事件：再如上的的类中创建对应的事件，继承自PubSubEvent<...>，<...>中是装载的内容的类型，比如string；
3. 发布事件：在需要发布事件的Module的ViewModel中先建立IEventAggregator对象，然后注入到ViewModel中，通过GetEvent<...>().Publish(...)发布内容;
4. 订阅事件：修改订阅事件的Module的构造函数，加入IEventAggregator，并GetEvent<...>().Subscribe(具体方法)，订阅事件的在接收到参数后会自动跳转到方法；
5. 线程选项：如果需要通过PubSubEvent来修改UI内容，可以使用ThreadOption.UIThread来处理事件，当然，也可以用PublisherThread和BackgroundThread两个参数；
6. 订阅过滤：暂未学习
#### 3. 其他tips
1. 注意如果使用config文件来添加Module的引用，注意要手动添加VS提供的配置文件(.config)，不能手动输入App.config，由于会自动生成一些内容，所以会造成错误;
2. 如果使用config文件，优点就是不需要自己在程序段里添加对Module工程的引用，但是此时主程序不会自动添加Module.dll，要么就是手动放入，要么就是生成选项中加入
```
xcopy "$(TargetDir)*.*" "$(SolutionDir)\$(SolutionName)\bin\Debug\$(TargetFramework)\" /Y
```
3. 待补充