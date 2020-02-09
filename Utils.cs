using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

namespace MarketRiskUI
{
    public partial class Utils : Form
    {
        public Utils()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byteArray = new byte[1024];
            byteArray= System.Text.Encoding.Default.GetBytes("Hellogod");
            
            string str = System.Text.Encoding.Default.GetString(byteArray);

            Console.WriteLine(str);
            Array.Clear(byteArray, 0, 8);
            byteArray = Encoding.ASCII.GetBytes("world");
            str = System.Text.Encoding.ASCII.GetString(byteArray);
            Console.WriteLine(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string name = Console.ReadLine();
            string name = "你好";
            string welcome = "welcome to C#";
            string result = string.Format("Hello {0}, {1}", name, welcome);
            Console.WriteLine(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strDate = "2014-08-01";
            DateTime dt1 = Convert.ToDateTime(strDate);
            string strDateTime = "2014-08-01 10:57:31";
            DateTime dt2 = Convert.ToDateTime(strDateTime);

            DateTime dt3 = DateTime.Parse(strDateTime);

            DateTime.TryParse(strDateTime, out dt3);

            /*
             * 使用ParseExact方法进行转换
             * 这里需要带入要转换的日期格式参数
             * 这里的日期格式可以自定义，比如yyyyMMddHHmmss,就可以传入20140801135205进行转换
             * 第三个参数是区域性特定格式信息，这里使用当前系统默认区域(即中国)            
             */
            DateTime dt4 = DateTime.ParseExact(strDateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

            /*
            * 使用TryParseExact方法进行转换
            * 基本用法和大致参数ParseExact方法一样
            * 只是传入返回值的DateTime类型的out形参,这里是dt4
            * 第四个参数为：格式设置选项，既DateTimeStyles枚举，设置NONE即可
            */

            DateTime.TryParseExact(strDateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt4);

            strDateTime = "10:57:31";
            DateTime.TryParse(strDateTime, out dt3);
            Console.WriteLine("{0}",dt3.ToLongTimeString());
            Console.WriteLine("{0}", dt3.ToShortTimeString());

        }
        DateTime lastTime = DateTime.Now;
        private void button5_Click(object sender, EventArgs e)
        {
            //播放系统声音
            
           

            DateTime lastTime2 = DateTime.Now;
            TimeSpan t1 = new TimeSpan(lastTime.Ticks);
            TimeSpan t2 = new TimeSpan(lastTime2.Ticks);
            double diff = (t2 - t1).Duration().TotalMilliseconds;
            if(diff>10000)
                System.Media.SystemSounds.Beep.Play();
            lastTime = lastTime2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        class Student:IComparable<Student>
        {
            private int age;
            private string name;

            public int Age { get => age; set => age = value; }
            public string Name { get => name; set => name = value; }

            public string ToString()
            {
                return Name + "-" + Age;
            }
            public Student(int age,string name)
            {
                this.Age = age;
                this.Name = name;
            
            }//默认比较函数
            public int CompareTo(Student other)
            {
                return this.Age.CompareTo(other.Age);
            }
        }

        //重写equals方法
        class MyStruct:IEquatable<MyStruct>
        {
            private string _Id;
            public int a;
            public int b;
            public string c;
            //重写equals
            public bool Equals(MyStruct other)
            {
                if (ReferenceEquals(null, other))
                    return false;
                //如果为同一对象，必然相等
                if (ReferenceEquals(this, other))
                    return true;
                if (a != other.a)
                {
                    return false;
                }
                else
                {
                    //如果基类不是从Object继承，需要调用base.Equals(other)
                    //如果从Object继承，直接返回true
                    return true;
                }

            }
            //其他类型对象
            public override bool Equals(object obj)
            {
                //this非空，obj如果为空，则返回false
                if (ReferenceEquals(null, obj)) return false;
                //如果为同一对象，必然相等
                if (ReferenceEquals(this, obj)) return true;
                //如果类型不同，则必然不相等
                if (obj.GetType() != this.GetType()) return false;
                //调用强类型对比
                return Equals((MyStruct)obj);
            }
            //实现Equals重写同时，必须重写GetHashCode，一些使用hashcode的集合中会调用该方法计算key
            public override int GetHashCode()
            {
                return (_Id != null ? StringComparer.InvariantCulture.GetHashCode(_Id) : 0);
            }
            //重写==操作符
            public static bool operator ==(MyStruct left, MyStruct right)
            {
                return Equals(left, right);
            }
            //重写!=操作符
            public static bool operator !=(MyStruct left, MyStruct right)
            {
                return !Equals(left, right);
            }
        };
        private void button6_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            list.Add(true);
            list.Add(1);
            list.AddRange(new int[] { 1,2,3,4,5,6,7});
            //list.Clear();
            //list.Remove(true);
            //list.RemoveAt(0);
            list.Insert(1,"wow");
            list.Contains("wow");
            MyStruct m1 = new MyStruct();
            m1.a = 2;
            m1.b = 2;
            MyStruct m2 = new MyStruct();
            m2.a = 1;
            MessageBox.Show(m1.Equals(m2).ToString());

            list.Add(m1);
            if (list.Contains(m2) == true)
                MessageBox.Show("contains");
            else
                MessageBox.Show("not contains");

            if (list.IndexOf(m2) >-1)
                MessageBox.Show("index");
            else
                MessageBox.Show("not index");











        }
        //排序方法一，采用Student:IComparable的方法，重写CompareTo。这种方法灵活性差点，但是一般都能用，sort方法默认就是调用该方法。
        //若是有特殊方法，则需要使用IComparer接口的Compare方法。
        //排序方法二，如下
        class AgeDESC : IComparer<Student> { public int Compare(Student x, Student y) { return y.Age.CompareTo(x.Age); } }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Student> list2 = new List<Student>();
            Student s1 = new Student(1, "tom");
            Student s2 = new Student(3, "jom");
            Student s3 = new Student(2, "kom");
            list2.Add(s1);
            list2.Add(s2);
            list2.Add(s3);
            //使用排序方法一
            list2.Sort();
            foreach (Student s in list2)
            {
                Console.WriteLine(s.ToString());
            }
            //使用排序方法二
            list2.Sort(new AgeDESC());
            for (int i=list2.Count-1;i>=0;i-- )
            {
                Student s = list2[i];
                Console.WriteLine(s.ToString());
                //list2.RemoveAt(i);
                
            }
            //使用find
            Student s4 = list2.Find(
                    delegate (Student user)
                    {
                        return user.Age == 3 && user.Name.Equals("jom");
                    });
            Student s5 = new Student(3, "jom");
            Console.WriteLine(list2.Contains(s2));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("E", "e");//添加keyvalue键值对
            ht.Add("A", "a");
            ht.Add("C", "c");
            ht.Add("B", "b");

            foreach(DictionaryEntry de in ht) //ht为一个Hashtable实例
            {
                Console.WriteLine(de.Key);//de.Key对应于keyvalue键值对key
                Console.WriteLine(de.Value);//de.Key对应于keyvalue键值对value
            }

            string s = (string)ht["A"];
            if (ht.Contains("E")) //判断哈希表是否包含特定键,其返回值为true或false
                Console.WriteLine("the E key exist");
            if (ht.ContainsValue("e")) //判断哈希表是否包含特定键,其返回值为true或false
                Console.WriteLine("the e value exist");
            ht.Remove("C");//移除一个keyvalue键值对
            Console.WriteLine(ht["A"]);//此处输出a
            ht.Clear();//移除所有元素
            Console.WriteLine(ht["A"]); //此处将不会有任何输出
        }




        class DouCube
        {
            public int Code { get { return _Code; } set { _Code = value; } }
            private int _Code;
            public string Page { get { return _Page; } set { _Page = value; } }
            private string _Page;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtfdd"]);

            foreach (string key in openWith.Keys)
            {
                Console.WriteLine("Key = {0}", key);
            }

            foreach (string value in openWith.Values)
            {
                Console.WriteLine("value = {0}", value);
            }

            //遍历字典
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            //添加存在的元素
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            openWith.Remove("doc");
            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }



            //判断键存在
            if (openWith.ContainsKey("bmp")) // True 
            {
                Console.WriteLine("An element with Key = \"bmp\" exists.");
            }

            //声明并添加元素
            Dictionary<int, DouCube> MyType = new Dictionary<int, DouCube>();
            for (int i = 1; i <= 9; i++)
            {
                DouCube element = new DouCube();
                element.Code = i * 100;
                element.Page = "com" + i.ToString() + ".";
                MyType.Add(i, element);
            }
            foreach (KeyValuePair<int, DouCube> kvp in MyType)
            {
                Console.WriteLine("Index {0} Code:{1} Page:{2}", kvp.Key, kvp.Value.Code, kvp.Value.Page);
            }
        }

        class test1
        {
            public int i;
            public string str;

        }


        private void button12_Click(object sender, EventArgs e)
        {
            DateTime dt,dt1;
            dt = DateTime.Now;
            dt1 = dt.AddSeconds(70);
            MessageBox.Show("dt = DateTime.Now = "+ dt.ToLongTimeString()+ " \r\n dt.AddSeconds(70)=" + dt1.ToLongTimeString());
            MessageBox.Show("dt.substratc = " + dt1.Subtract(dt).TotalSeconds);
        }

        class ShowParameter
        {
            public string name;
            public string title;
            public void show() {
                MessageBox.Show(name,title,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            ShowParameter sp = new ShowParameter();
            sp.name = "xxx合约，成交记录xxx，报单编号xxx，报单编号xxx";
            sp.title = "交易违规提醒";
            Thread t = new Thread(new ThreadStart(sp.show));
            t.Start();

        }
        private SpeechSynthesizer voice = new SpeechSynthesizer();
        private void button15_Click(object sender, EventArgs e)
        {
            int voiceRate = 0;
            if (voiceRate>=10)
                voiceRate = 10;
            if (voiceRate<=-10)
                voiceRate = -10;
            voice.Rate = voiceRate; //语速,[-10,10]
            voice.Volume = 100; //音量,[0,100]
            //voice.SelectVoice("Microsoft Lili");
            //voice.SelectVoice("Microsoft Anna");
            //voice.Speak("醒醒啦，有自成交");
            
            voice.SpeakAsync(textBox_voiceSpeed.Text.Replace("au","黄金").Replace("ag","白银"));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string phrase = "对不起，我是好人";
            SpeechSynthesizer speech = new SpeechSynthesizer();
            CultureInfo keyboardCulture = System.Windows.Forms.InputLanguage.CurrentInputLanguage.Culture;
            InstalledVoice neededVoice = speech.GetInstalledVoices(keyboardCulture).FirstOrDefault();
            if (neededVoice == null)
            {
                phrase = "Unsupported Language";
            }
            else if (!neededVoice.Enabled)
            {
                phrase = "Voice Disabled";
            }
            else
            {
                speech.SelectVoice(neededVoice.VoiceInfo.Name);
            }

            speech.Speak(phrase);
        }

        public delegate int AddHandler(int a,int b);
        public class 加法类
        {
            public static int Add(int a, int b)
            {
                Console.WriteLine("开始计算：" + a + "+" + b);
                Thread.Sleep(3000);
                Console.WriteLine("计算完成！");
                return a + b;
            }
        }
        public class 减法类
        {
            public  int substract(int a, int b)
            {
                Console.WriteLine("开始计算：" + a + "-" + b);
                Thread.Sleep(3000);
                Console.WriteLine("计算完成！");
                return a - b;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //同步调用delegate
            AddHandler handler = new AddHandler(加法类.Add);
            int result = handler.Invoke(1, 2);
            
            //int result = handler(1, 2);
            Console.WriteLine("做别的事情了");
            Console.WriteLine("计算结果{0}",result);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //异步调用delegate
            Console.WriteLine("异步调用");
            AddHandler handler = new AddHandler(加法类.Add);
            IAsyncResult result = handler.BeginInvoke(1, 2, null, null);
            Console.WriteLine("继续别的事情");
            Console.WriteLine(handler.EndInvoke(result));
        }

        private void callBack(IAsyncResult result)
        {
            Console.WriteLine("回调处理开始");
            AddHandler handler = (AddHandler)((AsyncResult)result).AsyncDelegate;
            Console.WriteLine(handler.EndInvoke(result));
            Console.WriteLine(result.AsyncState);
            Console.WriteLine("回调处理结束");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //异步回调delegate
            Console.WriteLine("异步回调");
            AddHandler handler = new AddHandler(加法类.Add);
            IAsyncResult result = handler.BeginInvoke(1, 2, new AsyncCallback(callBack), "AsycState:OK");
            Console.WriteLine("继续别的事情");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //同步调用delegate
            减法类 sub = new 减法类();
            AddHandler handler = new AddHandler(sub.substract);
            int result = handler.Invoke(2, 1);
            Console.WriteLine("做别的事情了");
            Console.WriteLine("计算结果{0}", result);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Enabled)
                MessageBox.Show("text="+comboBox1.Text + "\r\nvalue=" + comboBox1.SelectedValue);
        }

        class orderType
        {
            public string orderName;
            public string Type;

            public string OrderName { get => orderName; set => orderName = value; }
            public string OrderType { get => Type; set => Type = value; }
        }
        List<orderType> orders= new List<orderType>();
        private void button18_Click(object sender, EventArgs e)
        {
            this.comboBox1.Enabled=false;
            orders.Add(new orderType() { OrderName = "Quote", OrderType = "Q" });
            orders.Add(new orderType() { OrderName = "ReQuote", OrderType = "R" });
            orders.Add(new orderType() { OrderName = "order", OrderType = "O" });
            comboBox1.DataSource = orders;
            comboBox1.DisplayMember = "OrderName";
            comboBox1.ValueMember = "OrderType";
            comboBox1.Enabled = true;

        }

        class Example
        {
            public event AddHandler event_addHander;
            public void Test()
            {
                AddHandler handler = new AddHandler(加法类.Add);
                event_addHander += new AddHandler(加法类.Add);   //添加委托
                event_addHander += add;   //直接添加方法
                event_addHander += 加法类.Add;   //直接添加方法
                int result = event_addHander(1, 2);
                MessageBox.Show("event result = " + result);
            }
            public int add(int i, int j)
            {
                return i + j;
            }

            public event EventHandler event_addHander2;   //EventHandler其实是一个委托
            public void Test2()
            {
                object sender = 10;
                MyEventArgs e = new MyEventArgs("hahaha");
                event_addHander2 += Print;
                event_addHander2 += Print2;
                event_addHander2(sender, e);

            }
            void Print(object sender, EventArgs e)
            {
                Console.WriteLine(sender);
            }
            void Print2(object sender, EventArgs e)
            {
                MyEventArgs args = (MyEventArgs)(e);
                Console.WriteLine(sender+ args.Message);
            }
        }

        class MyEventArgs : EventArgs
        {
            private string message;
            public MyEventArgs(string message)
            {
                this.message = message;
            }
            public string Message
            {
                get { return message; }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Example exa = new Example();
            exa.Test();
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Example exa = new Example();
            exa.Test2();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
            DateTime start = DateTime.Now;
            DateTime end;
            int count = 10000000;
            MyStruct[] ss = new MyStruct[count];
            for (int i = 0; i < count; i++)
            {
                MyStruct child = new MyStruct();
                child.a = i;
                child.b = 1;
                child.c = "d";
               end = DateTime.Now;
                ss[i] = child;
            }
            end = DateTime.Now;
            TimeSpan ts = end - start;
            MessageBox.Show("timespan 生成" + count + "个元素，耗时毫秒 " + ts.TotalMilliseconds);

            DateTime start1 = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                if (ss[i].a == count)
                    break;
            }
            DateTime end1 = DateTime.Now;
            TimeSpan ts1 = end1 - start1;
            MessageBox.Show("timespan 遍历" + count + "个元素，耗时毫秒 " + ts1.TotalMilliseconds);


        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar) == true)
            {
                MessageBox.Show("you press whitespace");
            }
            else
            {
                
            }
        }


    
        class WaitPulse
        {
            private int result = 0;
            private Object lockObject;
            private int id = 0;
            public WaitPulse()
            {
            }

            public WaitPulse(Object obj)
            {
                this.lockObject = obj;
            }
            public void SetId(int id)
            {
                this.id = id;
            }


            public void CriticalSection()
            {
                Monitor.Enter(this.lockObject);
                
                Console.WriteLine(id+": Entered Thread "  + Thread.CurrentThread.GetHashCode());

                for (int i = 1; i <= 5; i++)
                {
                    Monitor.Wait(this.lockObject);  //释放当前锁，并进入等待锁状态

                    Console.WriteLine(id+": WokeUp  Result = " + result++ + " ThreadID " + Thread.CurrentThread.GetHashCode());

                    Monitor.Pulse(this.lockObject);   //唤醒等待锁进入待执行状态
                }
                Console.WriteLine(id+": Exiting Thread " + Thread.CurrentThread.GetHashCode());

                
                Monitor.Exit(this.lockObject);
            }
        }

        class PulseWait
        {
            private int result = 0;
            private Object lockObject;
            private int id = 0;
            public PulseWait()
            {
            }

            public PulseWait(Object obj)
            {
                this.lockObject = obj;
            }
            public void SetId(int id)
            {
                this.id = id;
            }


            public void CriticalSection()
            {
                Monitor.Enter(this.lockObject);

                Console.WriteLine(id + ": Entered Thread " + Thread.CurrentThread.GetHashCode());

                for (int i = 1; i <= 5; i++)
                {
                    Monitor.Pulse(this.lockObject);   //唤醒等待锁进入待执行状态

                    Monitor.Wait(this.lockObject);  //释放当前锁，并进入等待锁状态
                    Console.WriteLine(id + ": WokeUp  Result = " + result++ + " ThreadID " + Thread.CurrentThread.GetHashCode());

                }
                Console.WriteLine(id + ": Exiting Thread " + Thread.CurrentThread.GetHashCode());


                Monitor.Exit(this.lockObject);
            }
        }
        private void buttonThread_Click(object sender, EventArgs e)
        {
            Object obj = new Object();
            WaitPulse w1 = new WaitPulse(obj);
            w1.SetId(1);
            WaitPulse w2 = new WaitPulse(obj);
            w2.SetId(2);
            PulseWait p1 = new PulseWait(obj);
            p1.SetId(3);
            Thread t1 = new Thread(new ThreadStart(w1.CriticalSection));
            Thread t2 = new Thread(new ThreadStart(w2.CriticalSection));
            Thread t3 = new Thread(new ThreadStart(p1.CriticalSection));
            t1.Start();
            t2.Start();
            t3.Start();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            List<string> inputs = new List<String> { "1851","1999","1950","1905","2003" };
            string pattern = @"99";
            foreach (string input in inputs)
            {
                foreach (Match match in Regex.Matches(input, pattern))
                    Console.WriteLine(match.Value);
            }

            Match match1 = Regex.Match(textBox_content.Text,textBox_pattern.Text);
            if (match1 != Match.Empty)
                MessageBox.Show("正则表达式匹配成功:"+ match1.Value);
        }
        class Person : IComparable<Person>
        {
            private string _name ;
            private int _age;
            public Person(string Name, int Age)
            {
                this._name = Name;
                this._age = Age;
            }
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }
            public void SayHi()
            {
                Console.WriteLine($"Name{_name},Age{_age}");
            }
            //按名称比较,用于sort会调用这个函数
            public int CompareTo(Person p)
            {
                return this._name.CompareTo(p.Name);
            }
            //重写equals
            public bool Equals(Person other)
            {
                if (ReferenceEquals(null, other))
                    return false;
                //如果为同一对象，必然相等
                if (ReferenceEquals(this, other))
                    return true;
                if (Name != other.Name)
                {
                    return false;
                }
                else
                {
                    //如果基类不是从Object继承，需要调用base.Equals(other)
                    //如果从Object继承，直接返回true
                    return true;
                }
            }
            //其他类型对象
            public override bool Equals(object obj)
            {
                //this非空，obj如果为空，则返回false
                if (ReferenceEquals(null, obj)) return false;
                //如果为同一对象，必然相等
                if (ReferenceEquals(this, obj)) return true;
                //如果类型不同，则必然不相等
                if (obj.GetType() != this.GetType()) return false;
                //调用强类型对比
                return Equals((Person)obj);
            }
            //实现Equals重写同时，必须重写GetHashCode，一些使用hashcode的集合中会调用该方法计算key
            public override int GetHashCode()
            {
                return (Name != null ? StringComparer.InvariantCulture.GetHashCode(Name) : 0);
            }
            //重写==操作符
            public static bool operator ==(Person left, Person right)
            {
                return Equals(left, right);
            }
            //重写!=操作符
            public static bool operator !=(Person left, Person right)
            {
                return !Equals(left, right);
            }
        }
        //定义方法，通过委托方式传递给List进行find查找
        class PersonPredicate
        {
            public string Name;
            public bool isMyPerson(Person p)
            {
                if(Name.Equals(p.Name)==true)
                    return true;
                else
                    return false;
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            
            LinkedList<Person> peoples = new LinkedList<Person>();
            //新增
            for (int i = 1; i < 10; i++)
            {
                peoples.AddLast(new Person($"程序员{i}", i + 18));

            }
            Console.WriteLine($"新增的总人数：{peoples.Count}");
            Console.WriteLine("-------------------------------------------------------");
            //遍历调用
            LinkedListNode<Person> NodePerson = peoples.First;
            NodePerson.Value.SayHi();
            while (NodePerson.Next != null)
            {
                NodePerson = NodePerson.Next;
                NodePerson.Value.SayHi();
            }
            Console.WriteLine("-------------------------------------------------------");
            //查找
            LinkedListNode<Person> findPerson = peoples.Find(new Person("程序员3", 21));
            if (findPerson != null)
                findPerson.Value.SayHi();
            else
                Console.WriteLine("not find");
            //遍历删除
            while (NodePerson.Value != null && peoples.Count > 0)
            {
                NodePerson = peoples.Last;
                Console.Write($"当前总人数{peoples.Count},即将移除：{NodePerson.Value.Name}");
                peoples.RemoveLast();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //md5解密
            string input = "Yoda said, Do or do not. There is no try.";

            if (input == null)
            {
                return;
            }

            MD5 md5Hash = MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // 创建一个 Stringbuilder 来收集字节并创建字符串 
            StringBuilder sBuilder = new StringBuilder();

            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            MessageBox.Show(sBuilder.ToString());
        }

        /* 加密
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
         */
        private void button25_Click(object sender, EventArgs e)
        {
           
            
        }
        //encryptedText假设为base64编码
        public string Decrypt(string encryptedText, string pathToPrivateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateXmlKey = File.ReadAllText(pathToPrivateKey);
                    rsa.FromXmlString(privateXmlKey);
                    //rsa.ImportCspBlob

                    var bytesEncrypted = Convert.FromBase64String(encryptedText);

                    var bytesPlainText = rsa.Decrypt(bytesEncrypted, false);

                    return System.Text.Encoding.Unicode.GetString(bytesPlainText);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
       

        public byte[] GetBytesFromHex(string hexString)
        {
            if (hexString == null)
            {
                throw new ArgumentException("hex is null!");
            }

            if (hexString.Length % 2 != 0)
            {
                hexString += "20";//空格
                            //throw new ArgumentException("hex is not a valid number!", "hex");
            }

            // 需要将 hex 转换成 byte 数组。
            byte[] bytes = new byte[hexString.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。
                    bytes[i] = byte.Parse(hexString.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message.
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }

            // 获得 GB2312，Chinese Simplified。
            //Encoding chs = System.Text.Encoding.GetEncoding("GB2312");
            //return chs.GetString(bytes);
            return (bytes);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            //方法一：
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            string public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
            string private_Key = Convert.ToBase64String(RSA.ExportCspBlob(true));
            File.WriteAllText("./pub", public_Key);
            File.WriteAllText("./pri",private_Key);

        }

        private void button27_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            string public_Key = RSA.ToXmlString(false);
            string private_Key = RSA.ToXmlString(true);
            File.WriteAllText("./pub.xml", public_Key);
            File.WriteAllText("./pri.xml", private_Key);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int[] arr = new int[] { 8, 4, 5, 6, 3, 4, 3, 2, 1 };
            var m = from n in arr where n < 5 orderby n select n*n;
            foreach (var n in m)
            {
                Console.WriteLine(n);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ArrayList myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            ArrayList mySyncdAL = ArrayList.Synchronized(myAL);
            Console.WriteLine(myAL.IsSynchronized); //False
            Console.WriteLine(mySyncdAL.IsSynchronized); //True
        }
    }
}
