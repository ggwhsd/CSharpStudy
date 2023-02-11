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


Stopwatch的耗时计算。[示例](./Form1.cs)。


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
UPDClient示例。 TCP的Socket的服务端建立，客户端建立，互相之间发送消息等。[示例](./NetworkSocket.cs)
异步方法没有写示例代码。大致过程如下：异步socket，其实相比较于同步socket的方式，就是在发送、接收等过程中，使用了回调函数，
比如connect过程，使用connect则必须要等到连接建立完成后，程序才能往下走；使用beginConnect和endConnect则可以实现异步方式，BeginConnect(remoteip,new AsyncCallback(ConnectServer),socket)，则会发起连接，当连接返回信息后会回调ConnectServer方法，该方法中之行EndConnect，然后就可以之行发送和接收等下一步操作了。

* String *
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

* 线程锁，以及线程的通知和等待。线程使用Thread。
[示例](./Utils.cs)


* 委托同步调用和异步调用，回调。
[示例](./Utils.cs)

* event事件+委托+EventArgs自定义事件参数。
[示例](./Utils.cs)

* 常用数据集合List、ArrayList、HashTable等，LinkList，以及泛型集合自定义类型的查找和比较。
[示例](./Utils.cs)

* 异步接收网络数据的示例
[示例](./AsyncNetworkStream.cs)

* AsyncNetworkStream中增加了一个压力测试用的功能，读取文件中的报文，构造简单格式进行发送。


* 正则表达式
[示例](./Utils.cs)

* List、arrayList、Dictionary集合以及自定义比较
[示例](./Utils.cs)

* 重写equals方法，用于集合查找自定义类的相等，IComparable接口
[示例](./Utils.cs)

* LINQ的简单使用
[示例](./Utils.cs)

* 简单配置ini文件读写，key=value
[示例](./INIHelper.cs)

* 使用Winform自带的Setting设置配置信息，该信息通过运行程序修改之后，只能有效作用于当前环境，若更换其他电脑，则重新读取配置的默认数据。
常用于运行环境数据，比如是否第一次打开，窗体默认位置等个性化的数据等。
[示例](./Utils.cs)



* 索引器[,,]的使用，可以实现类似除了数组以外的多参数索引方式。
[示例](./Utils.cs)

* 反射的使用：根据字符串获取对应类型的各种成员信息，以及根据字符串中提到的方法名调用对应方法。
这样可以实现根据字符串动态创建和执行不同的类和方法
[示例](./Utils.cs)

* 应用程序域、程序集的基础使用。
[示例](./Utils.cs)

* C#的扩展方法。可以通过一种方式去扩展一个类的方法，而无需修改那个类。这种机制可以用于最小化设计原则，然后后续扩展都可以在其他类中完成，而无需修改原有类，从而完成一个灵活扩展。
[示例](./ExtensionMethodExample.cs)

* IDisposable接口的一般用法，用于释放非托管资源。
[示例](./TestDisposable.cs)

* 优先队列的实现。程序集唯一递增序列ID的实现。
[示例](./TestPriorityQueue.cs)

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

* datagridview 自定义单元格，点击显示下拉框、日历等。使用DataGridViewComboxColumn的话，则绑定数据最好使用datatable，如果使用list可能会出DataGridviewComboxCell值无效异常
[示例](./Form_datagridview3.cs)

* 蜡烛图 滑动条 点状图 阶梯和柱状图 图形上箭头指示*
[示例](./NPlotTest.cs)

* 窗口和MDI子窗口的关系使用，获取屏幕 *
[示例](./Form4.cs)

* 菜单的使用，状态栏的使用,利用按钮模拟菜单 *
[示例](./Form4.cs)
 
* 右下角系统托盘图标的使用 *
右下角图标，以及图标的右键菜单
[示例](./Form4.cs)

系统托盘的闪烁提醒，窗口关闭事件的拦截，终止程序。
[示例](./Form5.cs)

* 窗口闪烁, 进度条,系统托盘通知 *
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

* PropertiyGrid的使用
[示例](./PropertyGridTest.cs)



# 一些小例子,以下代码的例子都是来自于 唐大仕 老师的关于C#的书中的例子。

* 屏幕保护程序原型，其实就是将exe改为scr后缀，放到windows/system32目录下面，就可以在屏幕保护中找到。
[示例](./LittleExamples/ScreenProtectExample.cs)

* 素数
[示例](./LittleExamples/PrimeFilter.cs)

* 排块游戏
[示例](./LittleExamples/GridGame.cs)

* Attribute的自定义使用,特性。
[示例](./LittleExamples/AttributeExample.cs)

* ConditionAttribute的使用
[示例](./TestAttribute.cs)


* IO基础说明,
* 按存储位置分，FileStream, MemoryStream, BufferedStream
* 按读写方式,二进制流 BinaryReader和BinaryWriter； 
* 字符流，用于处理文本文件。 抽象类TextReader和TextWriter，子类有StreamReader和StringReader等。
[示例](./LittleExamples/IOStudy.cs)

* 计算器
[示例](./LittleExamples/CalcExample.cs)

* 文件浏览器,关于驱动器的获取，文件和文件夹的使用，listview，treeview，imagelist控件的综合使用。
[示例](./LittleExamples/FileExplorer)

* listView的使用。
[示例](./ListViewTest.cs)

* listView的组的使用，以及在listview上添加按钮。
[示例](./ListViewTest.cs)

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

* webview2的示例，一种替代webbrowser的组件，以selenium3+edgedriver
[示例](./OtherProjects/WinFormsAppWebView2/WindowsFormsApp1/Form1.cs)

* 除了webclient，后面又出现了httpclient，更加灵活和易于使用。
[示例](./OtherProjects/HttpClientTest/Form1.cs)

# 进阶使用知识：

* 使用CodeDom技术 动态生成dll或者exe。[示例](./DLLDynamic/ClassCompileLoad)

* 程序域上动态加载程序集，如dll，[示例](./DLLDynamic/DllDynamicImport)

* 新建程序域上（在netcore5上已经取消了该功能），动态加载程序集.  [实例](./DLLDynamic/DllDynamicImport/TestClassLibrary/MyAssemblyDynamicLoader.cs)

* 调用线程新的方式，当前推荐的异步调用模式，Task async wait [示例]（./TaskAsyncDemo.cs)

* 语音库，调用微软语音输出。
[示例](./Utils.cs)

* 日志库，github上的C#语言开源项目Simple Logger，库文件为SimpleLogger.dll。  一般用log4j的也很多。但是Simple这个代码较为简单。
[示例](./LoggerTest.cs)

* 使用servicestack.redis库访问redis的示例。据说是微软推荐的redis库。
此处的servicestack的redis库并非nuget下载，而是下载的源代码，修改了其中读写频率限制之后编译的dll。
包含了常用的字符串、list、hash、set等数据类型和使用方法。
也包含了pub/sub、数字自增等场景。
[示例](./redisTest.cs)



* ActiveMQ的Topic使用示例
[示例](./ActiveMQ_TOPIC.cs)

* ActiveMQ的Queue使用示例
[示例](./ActiveMQ_QUEUE.cs)

* 字节编解码示例项目
[示例](./EncodingsTools/EncodingsTools/Form1.cs)

* fluentScheduler 轻量级时间调度工具库
[示例](./FluentScheduler/SchedulerHelloExample.cs)

* LiveChart，一款非常好用的画图控件。在数据点特别多的时候，效率没有NPlot高。
[示例](./OtherProjects/LiveChartsTest/Form1.cs)

* 微软的workflow功能的使用，用于流程性的开发框架。

* 进程启动，进程查看等，查看内存、cpu等性能信息。
[示例](./ProcessForm.cs)

* 通过日期判断所属周的开始和结束。
[示例](./UserControls/CalenderWeek.cs)

* MD5签名、SHA签名、DES加密和解密，RSA加密和解密，RSA生成公钥和私钥文件、AES加密和解密、Base64编码。
[示例](./Utils.cs)

* window服务的开发，服务的安装工具
[说明文档](./OtherProjects/DemoService1/c#windows服务开发说明文档.docx)
[示例](./OtherProjects/DemoService1/DemoService1.sln)

* libvlc库的使用播放视频
[示例](./OtherProjects/LivVlcPlayer/VLCDemo/Form1.cs)

* 控制台小游戏：俄罗斯方块（实时）。熟悉最基本的游戏开发模式。
[示例](./OtherProjects/GameTetris/GameTetris/MyTetrisGame.cs)

* 控制台小游戏：炸弹人（实时）。进阶最典型的游戏元素，有这个基础可以做个rpg游戏了。如果再用unity等游戏框架就更容易了。
[示例](./OtherProjects/GameBomber/Bomber/GameCore.cs)

* 控制台小游戏: 回合制游戏。最适合讲故事的游戏模式。
[示例](./OtherProjects/GameTurnBaseStrategy/Program.cs)

* 七段LED显示，熟悉画图控件的制作。
[示例](./OtherProjects/SevenSegment/SevenSegment.cs)

* 多位七段LED显示
[示例](./OtherProjects/SevenSegment/SevenSegment.cs)

* 坐标系的制作
[示例](./OtherProjects/画坐标/WindowsFormsApp1/AxisControl.cs)

* 自定义TextBox，通过底层WndProc重绘界面以及控制输入、占位提示功能。这些功能实际上等价于OnPaint、OnFoucs、OnKeyPress的一些组合。
[示例](./OtherProjects/CustomTextBox/Form1.cs)

* TCP的Socket的Client和Server示例，演示客户端自动重连、大量客户端连接、服务端定时自动关闭客户端连接等应用场景。
[客户端示例](./OtherProjects/NetworkTest/ConsoleApp1/Program.cs)
[服务端示例](./OtherProjects/NetworkTest/ConsoleApp2/Program.cs)

* 使用windows自带的TTS功能和语音转文字功能
[示例](./OtherProjects/SpeechAndSynthesis/Form1.cs)

# CSharp访问C++的dll的方法【P/Invoke】：Marsheling机制。指针、数组、回调等均有示例。参考[项目](./CSharpInvokeCPP/CSharpInvokeCPP.sln)

# WPF

[示例](./WPF/HappyWpf/MainW.xaml)














