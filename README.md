# CSharpStudy
How to use C# to develop different kinds of desktop application

* delegate *
跟C++的指针相似，用以代替某个具体的执行方法。我觉得最大的好处是，不同线程之间可以使用委托的方式。比如A线程是程序主线程，负责界面更新，B线程是数据处理，处理完了，调用A线程的方法A1来执行委托更新，将方法的执行权限交给线程A来执行，而不是调用者B线程。

