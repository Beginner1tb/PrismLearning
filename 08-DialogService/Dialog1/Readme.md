### Dialog Serviceʹ��С��
#### 1. Dialog Service�����ܽᣨĿǰ��VS2019��8.0�汾��
1. ��ʾ�Ի���ShowDialog����������ʾ�������͵ĶԻ��򣬵�Ȼ�Ի������Զ���ģ�
2. ��Ի��򴫵ݲ�����ͨ��DialogParameters���¼ӶԻ��򴫵ݲ�����Ŀǰ8.0�汾ֻ��String����
3. �ӶԻ����ȡִ�н�����ӶԻ����ȡButtonResult�����
4. �����¹���δʵ�֣��첽���ص�����9.0�汾�ϣ�
#### 2.ʹ��С��
1. ������Ҫ��Ҫ�õ�DialogService��ViewModel��ڹ��캯��ע��IDialogService����
2. �����Ի����Ӧ���û��ؼ�������App.xaml.cs�н��û��ؼ���view��viewmodelע�ᵽcontainer�У�
3. Ҫ�򿪶Ի����λ��ͨ��DialogService��ShowDialog�򿪣����Բ���������Ҳ���Դ�������ί�У�
4. ��Ի����Ͳ�����ShowDialog��������һ����DialogParameters��ע�������Լ���һ��String����,������Ҫ�Թ̶���ͷ������```"message={�ֶ���}"```��ͬʱ���Ի����IDialogParameters��GetValue����Ҫ��ȡ��ͷΪ```message```��string������
5. �Ի������ݣ��Ի�������ǵ��������ݣ�ͨ��X���رգ�Ҳ����ʵ��IDialogAware�Ľӿ���ʵ����Ӧ�ʹ���ButtonResult�����а���

|����|����|����|��ע|
|----|----|----|----|
|String|Title|����Ի��������|ShowDialog��һ��������ע�ⲻ����ͨ���ı�
|Action|RequestClose|���ô���رնԻ���|IDialogResult�Ƿ��ظ��������ֵ��һ��ΪButtonResult
|bool|CanCloseDialog|�Ƿ���ԹرնԻ���|�����false�����Ͻ�X���޷�ǿ�ƹرնԻ���
|void|OnDialogClosed|�رնԻ���ʱ����|
|void|OnDialogOpened|�򿪶Ի���ʱ����|IDialogParameters��������������Ĳ�����Ŀǰ���ַ�����|

6. RequestClose��һ��ר�÷���������ʱ�Ի���͹ر��ˣ���ʱ�����������ڴ���ButtonResult�������ͷ���RequestClose�У�
7. ��������Ը���ί�л�ȡ�Ի����ButtonResult�����в�����