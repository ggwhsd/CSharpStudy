# CSharpStudy
How to use C# to develop different kinds of desktop application

WeChat:ggwhsd
email:738257101@qq.com

MainFacade.cs为主入口程序

* delegate *
跟C++的指针相似，用以代替某个具体的执行方法。效果类似于回调函数。
我觉得最大的好处是，不同线程之间可以使用委托的方式。比如A线程是程序主线程，负责界面更新，B线程是数据处理，处理完了，调用A线程的方法A1来执行委托更新，将方法的执行权限交给线程A来执行，而不是调用者B线程。

`private delegate void SetTextCallBack(string strValue);`是定义一个delegate。然后`button1_Click`里面会设定委托对应的具体方法。
[示例](./Form1.cs)
通过`this.txt_Log.Invoke(setCallBack, "连接成功");`的方式来调用委托，可以很好的解决不同线程之间更新导致主界面卡顿闪烁的问题。

* Socket的发送和接收 *
`button1_Click`方法，详见[示例](./Form1.cs)。
由于要循环接收，因此单独开启了一个线程来接收数据。


* Thread使用 *
```
				//开启一个新的线程不停的接收服务器发送消息的线程
                threadReceive = new Thread(new ThreadStart(Receive));
                //设置为后台线程
                threadReceive.IsBackground = true;
                threadReceive.Start();
```
`button1_Click`方法，详见[示例](./Form1.cs)。

* 数组转String *
```
 byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(strMsg);
```

* Excel文件的读写操作 *
[示例](./ExcelOp.cs)

* XML文件操作 *
[示例](./Form1.cs)  
`button21_Click`方法,读取xml。
`button22_Click`方法，写入xml。
`button23_Click`方法，修改xml并保存。

* 文本文件操作 *
[示例](./FormPart1.cs)
`button6_Click`方法，创建文本文件。
`button7_Click`方法，删除文本文件。
`button8_Click`方法，当前目录下修改文件名。
`button9_Click`方法，移动文件。
`button10_Click`方法，写入文件。
`button11_Click`方法，读取文件。
`button14_Click`方法，切换目录。

* 网络编程 *
UPD和TCP的服务端建立，客户端建立，互相之间发送消息等。[示例](./Form2.cs)
异步方法没有写示例代码。大致过程如下：异步socket，其实相比较于同步socket的方式，就是在发送、接收等过程中，使用了回调函数，
比如connect过程，使用connect则必须要等到连接建立完成后，程序才能往下走；使用beginConnect和endConnect则可以实现异步方式，BeginConnect(remoteip,new AsyncCallback(ConnectServer),socket)，则会发起连接，当连接返回信息后会回调ConnectServer方法，该方法中之行EndConnect，然后就可以之行发送和接收等下一步操作了。

* String *
`btnString_Click`方法。[示例](./Form2.cs)
[示例](./Utils.cs)

* json读写 *
[示例](./JsonForm.cs)

* 系统声音 *
`button5_Click`方法。 [示例](./Utils.cs)

* 多媒体声音 *
同步播放音乐，异步播放音乐，异步循环播放音乐，异步播放系统声音
[示例](./SoundMediaTools.cs)

* 时间 *
DateTime [示例](./Utils.cs)

* 编码 *
Encoding [示例](./Utils.cs)

* 线程锁，以及线程的通知和等待
[示例](./Utils.cs)


* 委托同步调用和异步调用，回调。
[示例](./Utils.cs)

* event事件+委托+EventArgs自定义事件参数。
[示例](./Utils.cs)

* 常用数据集合List、ArrayList、HashTable等，LinkList，以及泛型集合自定义类型的查找和比较。
[示例](./Utils.cs)

* 异步接收网络数据的示例
[示例](./AsyncNetworkStream.cs)

* Form2中增加了一个压力测试用的功能，读取文件中的报文，构造简单格式进行发送。


* 正则表达式
[示例](./Utils.cs)

* List、arrayList、Dictionary集合以及自定义比较
[示例](./Utils.cs)

* 重写equals方法，用于集合查找自定义类的相等
[示例](./Utils.cs)

* LINQ的简单使用
[示例](./Utils.cs)

* 简单配置ini文件读写，key=value
[示例](./INIHelper.cs)

## 界面 ##

* datagridview界面 * 
功能强大，设置好二级缓存，添加20W记录轻轻松松不成问题。使用datatable类来和其绑定，这样只要更新datatable就会更新datagridview。但是如果不同线程，则需要使用委托或者调用 `songsDataGridView.Invalidate();`的方式将其重新绘制。
`button1_Click`方法设置表格的列，
`button1_Click_1`方法设置表格的列格式。
详见[示例](./Form1.cs)。
`PopulateDataGridView`方法设置不通过datatable的方式来更新数据，显示列的顺序位置。
`button3_Click`绑定datatable的方式更细数据。

* datagridview界面 *

* datagridview控件自身的使用，比如添加行，添加列，设置格式，使用datagridview的非绑定源示例，包含绘画单元格，设置错误提示，输入校验等。。[示例1](./Form_datagridview1.cs)

* 使用datagridview的绑定源示例，包含虚拟模式和绑定数据源模式的分别使用。虚拟模式是对非绑定列进行操作，比如点击控件某个单元格，此时触发cellValueneeded，传入控件的位置，我们就可以自己给该单元格赋值，如果对控件提交了修改，我们可以通过cellvaluepushed事件来保存控件提交上来的值到自己的数据结构中。这样可以做到用户看到什么就显示什么，而不用预期加载所有数据。
交替行样式的使用。
[示例2](./Form_datagridview2.cs)

* datagridview的bindlist使用。[示例3](./datagridviewBindList.cs)
* datagridview与list、datatable、普通变量等的绑定方式，BindList的使用，文本控件的数据源绑定等。[示例4](./datagridviewBindMethod.cs)

* 蜡烛图 *
[示例](./Form3.cs)
* 点状图 *
[示例](./Form3.cs)
* 阶梯和柱状图 *
[示例](./Form3.cs)
* 图形上箭头指示 *
[示例](./Form3.cs)
* 滑动条 *
[示例](./Form3.cs)

* 窗口和新窗口的使用 *
[示例](./Form4.cs)

* 菜单的使用 *
[示例](./Form4.cs)

* 状态栏的使用 *
[示例](./Form4.cs)
 
* 右下角系统托盘图标的使用 *
右下角图标，以及图标的右键菜单
[示例](./Form4.cs)

* panel的使用 *
[示例](./Form4.cs)

* 窗口闪烁 *
[示例](./Form4.cs)

* 进度条 *
[示例](./Form4.cs)

* 系统通知 *
[示例](./Form4.cs)

* GDI绘图 *
[示例](./GDI.cs)
包含了画画基本线条，曲线，多变现，扇形，字符串，图像，圆形，贝塞尔曲线。空心文字，渐变颜色的文字，渐变颜色的图形

* GDI利用定时器实现画动画的圆圈 *
[示例](./GDITimerRefresh.cs)

* GDI截屏幕图片并保存 *
[示例](./GDITimerRefresh.cs)

* GDI 自定义控件内部图像颜色 *
[示例](./GDITimerRefresh.cs)

* GDI 复制图片 *
[示例](./GDITimerRefresh.cs)



* 拖拽鼠标改变控件的位置
[示例](./PanelTest.cs)

* 增加动画淡入淡出窗口
[示例](./Form1.cs)

* datagridview的隐藏列，和访问隐藏列的数据
[示例](./Form1.cs)

* spltieContianer 分割条与panel的使用
[示例](./SpliterTest.cs)


* 菜单保留历史文件打开记录 
[示例](./MenuContext.cs)




# CSharp访问C++的dll的方法：Marsheling机制。指针、数组、回调等均有示例。参考[项目](./CSharpInvokeCPP/CSharpInvokeCPP.sln)

# 一些小例子,以下代码的例子都是来自于 唐大仕 老师的关于C#的书中的例子。

* 屏幕保护程序原型，其实就是将exe改为scr后缀，放到windows/system32目录下面，就可以在屏幕保护中找到。
[示例](./LittleExamples/ScreenProtectExample.cs)

* 素数
[示例](./LittleExamples/PrimeFilter.cs)

* 排块游戏
[示例](./LittleExamples/GridGame.cs)

* Attribute的自定义使用
[示例](./LittleExamples/AttributeExample.cs)

* IO基础说明,
* 按存储位置分，FileStream, MemoryStream, BufferedStream
* 按读写方式,二进制流 BinaryReader和BinaryWriter； 
* 字符流，用于处理文本文件。 抽象类TextReader和TextWriter，子类有StreamReader和StringReader等。
[示例](./LittleExamples/IOStudy.cs)

* 计算器
[示例](./LittleExamples/CalcExample.cs)

* 文件浏览器,关于驱动器的获取，文件和文件夹的使用，listview，treeview，imagelist控件的综合使用。
[示例](./LittleExamples/FileExplorer)

# Web方面的代码

* WebClient的使用，当然，比较好的，还是用webbrowser，因为webbrowser几乎是一个浏览器。
[示例](./WebExamples/WebClientExample.cs)

* WebCLientExample中讲解webRequest的使用。
[示例](./WebExamples/WebRequestAndResponse.cs)

* 使用http的header字段，获取网页编码
[示例](./WebExamples/GuessEnCode.cs)

* 使用webclient爬取纸黄金的数据
[示例](./WebExamples/GetGoldPrice.cs)

* 爬取网页中多个链接的例子
[示例](./WebExamples/Crawler.cs)

* 获取百度建议词，额外引入了system.web的dll
[示例](./WebExamples/BaiduSuggest.cs)

* webbrowser配合Echart.js进行图表展示
[示例](./OtherProjects/EChartByOther/EChartByOther/Form1.cs)


# 进阶使用知识：

* 使用CodeDom技术 动态生成dll或者exe。(./DLLDynamic/ClassCompileLoad)

* 动态加载dll，(./DLLDynamic/DllDynamicImport)

* 调用线程新的方式，Task async wait （./TaskAsyncDemo.cs)

* 语音库，调用微软语音输出。
[示例](./Utils.cs)

* 日志库，github上的C#语言开源项目Simple Logger，库文件为SimpleLogger.dll
[示例](./LoggerTest.cs)

* 使用servicestack.redis库访问redis的示例。
[示例](./redisTest.cs)

* ActiveMQ的Topic使用示例
[示例](./ActiveMQ_TOPIC.cs)

* ActiveMQ的Queue使用示例
[示例](./ActiveMQ_QUEUE.cs)

* MD5加密和解密，RSA
[示例](./Utils.cs)

* 字节编解码示例项目
[示例](./EncodingsTools/EncodingsTools/Form1.cs)

* fluentScheduler 轻量级时间调度工具库
[示例](./FluentScheduler/SchedulerHelloExample.cs)

* LiveChart，一款非常好用的画图控件。在数据点特别多的时候，效率没有NPlot高。
[示例](./OtherProjects/LiveChartsTest/Form1.cs)

* 微软的workflow功能的使用，用于流程性的开发框架。

* 进程启动，进程查看等
[示例](./ProcessForm.cs)

* 通过日期判断所属周的开始和结束。
[示例](./UserControls/CalenderWeek.cs)






