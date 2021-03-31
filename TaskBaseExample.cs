using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace MarketRiskUI
{
    class TaskBaseExample
    {
        public void log(string msg)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " "+msg);
        }
        public void TestTask1_Start()
        {
            //创建任务的一种方式
            Task t = new Task(() =>
            {
                log("开始任务");
                Thread.Sleep(10);
            });
            //启动任务
            t.Start();
            //设置任务完成之后的工作
            t.ContinueWith((task) =>
            {
                log("任务完成，完成时候的状态");
                log(string.Format("IsCanceled={0}\t" +
                    "IsCompleted={1}\t" +
                    "IsFaulted={2}\t" +
                    "Id={3}", 
                    task.IsCanceled, 
                    task.IsCompleted, 
                    task.IsFaulted,
                    task.Id));
            }
            ).Wait();  //此处不加wait，则不会等待异步执行完成。
            
            log("TestTask1_Start 测试完成");
        }
        public void TaskMethod(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
        //不带返回值的Task
        public void TestTask2_Create1()
        {
            //创建task的第一种方式
            Task t1 = new Task(() => TaskMethod("Task1"));
            log("TestTask2_Create1 status:" + t1.Status.ToString() + " asystatus:"+ t1.AsyncState?.ToString());
            t1.Start();
            log("TestTask2_Create1 status:" + t1.Status.ToString() + " asystatus:" + t1.AsyncState?.ToString());
            //等待Task执行完毕

            //第二种创建task的方式，创建完了，立即异步运行。
            Task t2=Task.Run(() => TaskMethod("Task3"));
            //第三种创建task方式，可以标记长时间运行任务，会单独使用线程，而不会在线程池中。
            Task.Factory.StartNew(() => TaskMethod("Task 4"), TaskCreationOptions.LongRunning);
            Task.WaitAll(t1,t2);
            //t2.Wait(); //单独某个任务进行等待。
            log("TestTask2_Create1 测试完成");
        }

        //带返回值的Task
        public Task<int> CreateTask(string name)
        {
            return new Task<int> (() => ReturnTaskMethod(name));
        }
        public int ReturnTaskMethod(string name)
        {
            log(string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return 42;
        }
        public void TestTask3_Create2()
        {
            log("TestTask3_Create2 开始");
            ReturnTaskMethod("main");
            Task<int> task = CreateTask("create return task 1");
            task.Start();
            //调用Result会等待任务执行完成。
            int result = task.Result;
            log("Task 1 Result is: "+ result);


            
            task = CreateTask("create return task 2");
            task.RunSynchronously();
            result = task.Result;
            log("Task 2 Result is: " + result);


            task = CreateTask("create return task 3");
            log("task 3 status " + task.Status);
            task.Start();
            while (task.IsCompleted != true)
            {
                log("status "+ task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            log(" result " + task.Result);

        }
        /// <summary>
        /// 多个任务并行计算，串行计算
        /// </summary>
        public void TestTask4_MultiTaskManage()
        {
            log("TestTask4_MultiTaskManage开始执行");
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            Action a1 = new Action(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });
            var t1 = Task.Factory.StartNew(a1);
            
            var t2 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
                log(string.Format("Task t2 result={0},Thread id {1}  {2}", result, Thread.CurrentThread.ManagedThreadId,t.Id));
            });
            var t3 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
                log(string.Format("Task t2 result={0},Thread id {1}  {2}", result, Thread.CurrentThread.ManagedThreadId,t.Id));
            });

            Task.WaitAll(t2,t3);
            var t4 = Task.Factory.StartNew(()=>
                log(string.Format("当前集合元素个数：{0},Thread id {1}", stack.Count, Thread.CurrentThread.ManagedThreadId)));

        }

        /// <summary>
        /// 关于父任务和子任务的概念
        /// </summary>
        public void TestTask5_parentTask()
        {
            log("TestTask5_parentTask开始执行");
            string showParent="所有child Task执行完，我才会执行w完";
            Task<string[]> parent = new Task<string[]>(
                state =>
                {
                    log((string)state+" begin");
                    string[] result = new string[2];
                    new Task(() => { result[0] = "我是child 1"; }, TaskCreationOptions.AttachedToParent)
                    .Start();
                    new Task(() => { result[1] = "我是child 2"; }, TaskCreationOptions.AttachedToParent)
                    .Start();
                    log((string)state+ " end");
                    return result;
                   
                }, showParent
                );

            Task<string>  t_res = parent.ContinueWith<string>(t =>
           {
               Array.ForEach<string>(t.Result, r => log(r));
               return "TestTask5_parentTask 执行完毕";
           });
            parent.Start();
            log("我是主线程，也就是子任务的父线程");
            string res = t_res.Result;

            log(res);

        }

        /// <summary>
        /// 利用树结构，并发执行其中的节点任务
        /// </summary>
        public void TestTask6_multiTasksParalByparent()
        {
            log("TestTask6_multiTasksParalByparent 开始");
            Node root = GetNode();
            DisplayTree(root);
        }
        internal class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public string Text { get; set; }
        }
        private Node GetNode()
        {
            Node root = new Node
            {
                Left = new Node
                {
                    Left = new Node
                    {
                        Text = "L-L"
                    },
                    Right = new Node
                    {
                        Text = "L-R"
                    },
                    Text = "L"
                },
                Right = new Node
                {
                    Left = new Node
                    {
                        Text = "R-L"
                    },
                    Right = new Node
                    {
                        Text = "R-R"
                    },
                    Text = "R"
                },
                Text = "Root"
            };
            return root;
        }
        void DisplayTree(Node root)
        {
            var task = Task.Factory.StartNew(() => DisplayNode(root),
                                            CancellationToken.None,
                                            TaskCreationOptions.None,
                                            TaskScheduler.Default);
            task.Wait();
        }
        private void DisplayNode(Node current)
        {

            if (current.Left != null)
                Task.Factory.StartNew(() => DisplayNode(current.Left),
                                            CancellationToken.None,
                                            TaskCreationOptions.AttachedToParent,
                                            TaskScheduler.Default);
            if (current.Right != null)
                Task.Factory.StartNew(() => DisplayNode(current.Right),
                                            CancellationToken.None,
                                            TaskCreationOptions.AttachedToParent,
                                            TaskScheduler.Default);
            log(string.Format("当前节点的值为{0};处理的ThreadId={1}", current.Text, Thread.CurrentThread.ManagedThreadId));
        }


        private void DoProcessing(IProgress<int> progress)
        {
            for (int i = 0; i <= 100; ++i)
            {
                Thread.Sleep(100);
                if (progress != null)
                {
                    progress.Report(i);
                    
                }
            }
           
        }
        /// <summary>
        /// 将任务中运行的数据传递给任务以外的地方
        /// </summary>
        public async Task Display(TextBox txtShow)
        {
            //当前线程,可以通过这种方式在UI线程上进行显示
            var progress = new Progress<int>(percent =>
            {
                txtShow.Text = percent.ToString();
                Console.Write("{0}%", percent);
                
            });
            //启动task线程池线程
            await Task.Run(() => DoProcessing(progress));
        }

      

        public void TestTask6_UIupdate(TextBox txt)
        {
            var tsk = Display(txt);
            //tsk.Start();
        }

        //该TaskCompletionSource功能是用于在一个工作完成后，设置完成结构，比如一些IO操作，本身或者异步回调等，用来传递一个结果。
        //因为new Task本身不支持直接设定结果，都是通过任务返回值来。  而TaskCompletionSource可以通过SetResult设定结果。
        public void TestTask7_TaskCompletionSource()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString()+"TaskCompletionSource开始");
            var task = SomeEventsWrapper();
            //task.Result会阻塞直到有结果
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "等待结果:" +task.Result + "\r\n TaskCompletionSource结束");
        }
        private Task<String> SomeEventsWrapper()
        {
            var tcs = new TaskCompletionSource<string>();
            var eventCallback = new EventCallBack();
            eventCallback.Done += (args) => { tcs.SetResult(args); };
            eventCallback.Do();
            return tcs.Task;
            
        }
        private class EventCallBack
        {
            public Action<string> Done = (args) => {; };
            public void Do()
            {
                Thread.Sleep(3000);
                Console.WriteLine(DateTime.Now.ToLongTimeString() + "EventCallBack:" +Thread.CurrentThread.ManagedThreadId);
                Done("Done");
            }
        }
    }
}
