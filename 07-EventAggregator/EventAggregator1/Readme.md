### Event Aggregatorʹ��С��
#### 1. Event AggregatorһЩ˵��
1. EventAggregator�����������һ�������IEventAggregator�ӿ��ṩ�����������¼���
2. EventAggregator�е�Publisher��Subscriber֮���ǽ������ֱ�ӹ�ϵ��
3. EventAggregator�Ƕಥ�ģ�Publisher���Է�������¼�����ȻSubScriberҲ���Լ���ͬһ���¼���
4. EventAggregator������ģ��֮��Ŀ�ģ���¼���
5. Prism�����������¼��������ͻ��¼������ڱ���ʱ�Ĵ����飻
#### 2. EventAggregator��ʹ��
1. PubSubEvent<...>���ʹ�ã����Ƚ���ר�ŵ�һ���࣬��������PubSubEvent�¼���ע�⣬����ɶ���¼������Կ��ǽ���ר�ŵ�һ��.Core�����ļ�����������Щ�ࣻ
2. �����¼��������ϵĵ����д�����Ӧ���¼����̳���PubSubEvent<...>��<...>����װ�ص����ݵ����ͣ�����string��
3. �����¼�������Ҫ�����¼���Module��ViewModel���Ƚ���IEventAggregator����Ȼ��ע�뵽ViewModel�У�ͨ��GetEvent<...>().Publish(...)��������;
4. �����¼����޸Ķ����¼���Module�Ĺ��캯��������IEventAggregator����GetEvent<...>().Subscribe(���巽��)�������¼����ڽ��յ���������Զ���ת��������
5. �߳�ѡ������Ҫͨ��PubSubEvent���޸�UI���ݣ�����ʹ��ThreadOption.UIThread�������¼�����Ȼ��Ҳ������PublisherThread��BackgroundThread����������
6. ���Ĺ��ˣ���δѧϰ
#### 3. ����tips
1. ע�����ʹ��config�ļ������Module�����ã�ע��Ҫ�ֶ����VS�ṩ�������ļ�(.config)�������ֶ�����App.config�����ڻ��Զ�����һЩ���ݣ����Ի���ɴ���;
2. ���ʹ��config�ļ����ŵ���ǲ���Ҫ�Լ��ڳ��������Ӷ�Module���̵����ã����Ǵ�ʱ�����򲻻��Զ����Module.dll��Ҫô�����ֶ����룬Ҫô��������ѡ���м���
```
xcopy "$(TargetDir)*.*" "$(SolutionDir)\$(SolutionName)\bin\Debug\$(TargetFramework)\" /Y
```
3. ������