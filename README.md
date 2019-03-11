# CSharpStudy
How to use C# to develop different kinds of desktop application

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

* 时间 *
DateTime [示例](./Utils.cs)

* 编码 *
Encoding [示例](./Utils.cs)

## 界面 ##

* datagridview界面 * 
功能强大，设置好二级缓存，添加20W记录轻轻松松不成问题。使用datatable类来和其绑定，这样只要更新datatable就会更新datagridview。但是如果不同线程，则需要使用委托或者调用 `songsDataGridView.Invalidate();`的方式将其重新绘制。
`button1_Click`方法设置表格的列，
`button1_Click_1`方法设置表格的列格式。
详见[示例](./Form1.cs)。
`PopulateDataGridView`方法设置不通过datatable的方式来更新数据，显示列的顺序位置。
`button3_Click`绑定datatable的方式更细数据。

* 蜡烛图 *
[示例](./Form3.cs)
* 点状图 *
[示例](./Form3.cs)
* 阶梯和柱状图 *
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
包含了画画基本线条，曲线，多变现，扇形，字符串，图像，圆形，贝塞尔曲线。



