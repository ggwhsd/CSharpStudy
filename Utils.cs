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

using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;

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
            strDate = "10:30:00";
            DateTime dtstr = DateTime.Parse(strDate);

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
            Console.WriteLine("{0}", DateTime.Now.ToString("hh:mm:ss"));

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

            public override string ToString()
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
            //字符串转换日期
            DateTime date = DateTime.ParseExact("2021/7/12", "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);

            DateTime dt,dt1;
            dt = DateTime.Now;
            dt1 = dt.AddSeconds(70);
            MessageBox.Show("dt = DateTime.Now = "+ dt.ToLongTimeString()+ " \r\n dt.AddSeconds(70)=" + dt1.ToLongTimeString());
            //时间加减
            MessageBox.Show("dt.substratc = " + dt1.Subtract(dt).TotalSeconds);
            //字符串转换时间
            DateTime dat1 = DateTime.Parse("10:35:21");
            DateTime dat2 = DateTime.Parse("13:35:21");
           
            TimeSpan ts = dat2 - dat1;
            MessageBox.Show(Convert.ToString(ts.TotalSeconds));
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
            string input = "Yoda said, Do or do not. There is no try. 信息摘要算法（英语：MD5 Message-Digest Algorithm），一种被广泛使用的密码散列函数，可以产生出一个128位（16字节）的散列值（hash value），用于确保信息传输完整一致。MD5由美国密码学家罗纳德·李维斯特（Ronald Linn Rivest）设计，于1992年公开，用以取代MD4算法。这套算法的程序在 RFC 1321 标准中被加以规范。1996年后该算法被证实存在弱点，可以被加以破解，对于需要高度安全性的数据，专家一般建议改用其他算法，如SHA-2。2004年，证实MD5算法无法防止碰撞（collision），因此不适用于安全性认证，如SSL公开密钥认证或是数字签名等用途。";

            if (input == null)
            {
                return;
            }

            MD5 md5Hash = MD5.Create(); //   等价于  MD5 md5Hash = new MD5CryptoServiceProvider()

            // 将输入字符串转换为字节数组并计算哈希数据 
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] encryptdata = md5Hash.ComputeHash(data);

            MessageBox.Show(Convert.ToBase64String(encryptdata));

            // 创建一个 Stringbuilder 来收集字节并创建字符串 
            StringBuilder sBuilder = new StringBuilder();
            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < encryptdata.Length; i++)
            {
                sBuilder.Append(encryptdata[i].ToString("x2"));
            }

            MessageBox.Show(sBuilder.ToString()+" 十六进制数字个数:"+ sBuilder.Length/2);


        }

   
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
            var m = from n in arr
                    where n < 5
                    orderby n
                    select n*n;
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

        private void button30_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog()!=DialogResult.OK)
            {
                return;
            }
            FileStream fs  = new FileStream(opf.FileName,FileMode.Open,FileAccess.Read);

            MD5 md5Hash = MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据 
            byte[] data = md5Hash.ComputeHash(fs);

            // 创建一个 Stringbuilder 来收集字节并创建字符串 
            StringBuilder sBuilder = new StringBuilder();

            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            MessageBox.Show(sBuilder.ToString());
        }
        private string des_encryptdata;
        private void button31_Click(object sender, EventArgs e)
        {
            string data = "这是要加密的数据";
            string key = "12345678";//8位字符的密钥字符串
            string iv = "abcdefgd";//8位字符的初始化向量字符串
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.Encoding.ASCII.GetBytes(iv);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            MessageBox.Show("加密后数据:"+Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length));
            des_encryptdata = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string key = "12345678";//8位字符的密钥字符串
            string iv = "abcdefgd";//8位字符的初始化向量字符串
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.Encoding.ASCII.GetBytes(iv);

            try
            {
                byte[] byEnc = Convert.FromBase64String(des_encryptdata);
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(byEnc);
                CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cst);
                MessageBox.Show("解密数据:"+sr.ReadToEnd());
            }

            catch
            {
                MessageBox.Show("转换失败");
            }
        }
        private string rsa_encryptdata;
        private void button33_Click(object sender, EventArgs e)
        {
            string data = "abcdefgh";
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = "keySeedCode"; //密匙容器的名称，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(data);
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                rsa_encryptdata = Convert.ToBase64String(encryptdata);
                MessageBox.Show(rsa_encryptdata);
            }
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = "keySeedCode";//密匙容器的名称，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(rsa_encryptdata);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                MessageBox.Show(System.Text.Encoding.Default.GetString(decryptdata));
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string data = "跟md5一样是不可逆的算法，把原始数据转化为长度较短、位数固定的输出序列即散列值";
            var bytes = System.Text.Encoding.Default.GetBytes(data);
            var SHA = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var encryptbytes = SHA.ComputeHash(bytes);
            MessageBox.Show(Convert.ToBase64String(encryptbytes));
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string data = "跟md5一样是不可逆的算法，把原始数据转化为长度较短、位数固定的输出序列即散列值";
            var bytes = System.Text.Encoding.Default.GetBytes(data);
            var SHA = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            var encryptbytes = SHA.ComputeHash(bytes);
            MessageBox.Show(Convert.ToBase64String(encryptbytes));
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string data = "跟md5一样是不可逆的算法，把原始数据转化为长度较短、位数固定的输出序列即散列值";
            var bytes = System.Text.Encoding.Default.GetBytes(data);
            var SHA = new System.Security.Cryptography.SHA384CryptoServiceProvider();
            var encryptbytes = SHA.ComputeHash(bytes);
            MessageBox.Show(Convert.ToBase64String(encryptbytes));
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string data = "跟md5一样是不可逆的算法，把原始数据转化为长度较短、位数固定的输出序列即散列值";
            var bytes = System.Text.Encoding.Default.GetBytes(data);
            var SHA = new System.Security.Cryptography.SHA512CryptoServiceProvider();
            var encryptbytes = SHA.ComputeHash(bytes);
            MessageBox.Show(Convert.ToBase64String(encryptbytes));
        }
        private string aes_encryptdata = "";
        private void button38_Click(object sender, EventArgs e)
        {
            string data = "高级加密标准（英语：Advanced Encryption Standard，缩写：AES）"+
                "AES的CBC加密模式下的128位、192位、256位加密区别，" +
                "参考 对称加密和分组加密中的四种模式(ECB、CBC、CFB、OFB) 。" +
                "这三种的区别，主要来自于密钥的长度，16位密钥 = 128位，24位密钥 = 192位，32位密钥 = 256位。";


            Byte[] plaindata = Encoding.UTF8.GetBytes(data);

            string key = new string('a',16);

            RijndaelManaged rm = new RijndaelManaged
            {
                IV = Encoding.UTF8.GetBytes("1234567890abcdef"),
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] encryptbytes = cTransform.TransformFinalBlock(plaindata, 0, plaindata.Length);
            MessageBox.Show(Convert.ToBase64String(encryptbytes));
            aes_encryptdata = Convert.ToBase64String(encryptbytes);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            
            Byte[] encryptbytes = Convert.FromBase64String(aes_encryptdata);
            string key = new string('a', 16);
            RijndaelManaged rm = new RijndaelManaged
            {
                IV = Encoding.UTF8.GetBytes("1234567890abcdef"),
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] plaindata = cTransform.TransformFinalBlock(encryptbytes, 0, encryptbytes.Length);

            MessageBox.Show(Encoding.UTF8.GetString(plaindata));
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string str = textBoxString.Text;

            textBoxString.AppendText("length:" + str.Length + "\r\n");
            str = str.Trim();
            textBoxString.AppendText("trim():" + str + "\r\n");
            char[] trimChars = { ' ', 'a', 'c' };
            textBoxString.AppendText("trim(char[] ):" + str.Trim(trimChars) + "\r\n");
            textBoxString.AppendText("upper:" + str.ToUpper() + "\r\n");
            char[] split = { ':', ' ' };
            string[] nWords = str.Split(split, 2);
            textBoxString.AppendText("split(\':\'):" + nWords[0] + " : " + nWords[1].PadLeft(10, '0') + "\r\n");
            textBoxString.AppendText("Substring()" + str.Substring(0, 5) + "\r\n");
            textBoxString.AppendText("Replace(\"a\",\"b\")" + str.Replace('a', '*') + "\r\n");
            textBoxString.AppendText("ToCharArray()" + str.ToCharArray());
            Console.WriteLine(sizeof(char));
        }
        private Thread thread1;
        private Thread thread2;
        private void button41_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(method1));
            thread2 = new Thread(new ThreadStart(method2));
            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Normal;
            thread1.Start();
            thread2.Start();
        }
        public void method1()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 200)
                    Thread.Sleep(30);
                else
                    textBox1.AppendText("#" + i.ToString());
            }

        }
        public void method2()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 400)
                    Thread.Sleep(5);
                else
                    textBox2.AppendText("*" + i.ToString());
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.WelcomeMsg);
            Properties.Settings.Default.WelcomeMsg = "欢迎━(*｀∀´*)ノ亻!";
            //对于Scope为User的属性，可以修改并保存。 Application的属性无法修改。
            Properties.Settings.Default.Save();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            IndexersExample<int> ie = new IndexersExample<int>();
            ie[1, 2, 3] = 100;
            Console.WriteLine(ie[1, 2, 3]);
            ie["100"] = 100;
            Console.WriteLine(ie["100"]);
        }

        class IndexersExample<T>
        {
            // [] Indexers
            private T[] arr = new T[100];
            private Dictionary<String, T> dict = new Dictionary<string, T>();
            public T this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }
            public T this[int i, int j]
            {
                get { return arr[i + j]; }
                set { arr[i + j] = value; }
            }
            public T this[int i, int j, int k]
            {
                get { return arr[i + j + k]; }
                set { arr[i + j + k] = value; }
            }
            public T this[string s]
            {
                get { return dict[s]; }
                set { dict[s] = value; }
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //以下都是从当前程序集中获取信息

            //方法1:直接根据类名获取Type
            //Type t = typeof(ReflectExample);
            
            //方法2:也可以根据字符串获取,先获取当前程序集
            Assembly ass = typeof(Utils).Assembly;
            Type t = ass.GetType("MarketRiskUI.ReflectExample");

            string msg = $"{t.Name} {t.FullName} {t.Assembly}";
            MessageBox.Show("类信息："+msg);
            //获取构造函数,
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            msg=getMembers<ConstructorInfo>(ci);
            MessageBox.Show("获取构造函数:" + msg);
            //对于非public的，获取不了。
            MemberInfo[] memberInfos = t.GetMembers();
            msg = getMembers<MemberInfo>(memberInfos);
            MessageBox.Show("获取所有成员,默认包含（方法+字段+属性):" + msg);

            MethodInfo[] mi = t.GetMethods();
            msg = getMembers<MethodInfo>(mi);
            MessageBox.Show("获取方法:" + msg);

            FieldInfo[] fi = t.GetFields();
            msg = getMembers<FieldInfo>(fi);
            MessageBox.Show("获取字段:" + msg);

            PropertyInfo[] pi = t.GetProperties();
            msg = getMembers<PropertyInfo>(pi);
            MessageBox.Show("获取属性:" + msg);

            EventInfo[] ei = t.GetEvents(BindingFlags.NonPublic);
            msg = getMembers<EventInfo>(ei);
            MessageBox.Show("获取事件:" + msg);

            


        }

        public string getMembers<T>(T[] ms)
        {
            string value="";
            foreach (T m in ms)
            {
                value +=string.Format("{0}{1}", "     ", m.ToString());
            }
            return value;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Assembly ass = typeof(Utils).Assembly;
            Type t = ass.GetType("MarketRiskUI.ReflectExample");
            var obj = Activator.CreateInstance(t) as ReflectExample;
            obj.value1 = "value1";
            MessageBox.Show("执行反射创建的实例：" + obj.Show());
            
        }

        private void button46_Click(object sender, EventArgs e)
        {
            //将对象序列化字符串
            ReflectExample r = new ReflectExample();
            r.value1 = "v1";
            r.value2 = 2;
            r.property1 = "p1";
            string json = JsonConvert.SerializeObject(r, Formatting.Indented);
            //告知字符串表示的对象类型名
            string json_type = r.GetType().FullName;


            //==========================>
            
            Type t = typeof(ReflectExample);
            if (json_type == t.FullName)
            {
                ReflectExample value = JsonConvert.DeserializeObject<ReflectExample>(json);
                MessageBox.Show(value.Show());
            }
            
        }

        private string SendObjectToStr<T>(T value)
        {
            string json_type = typeof(T).FullName;
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            return json_type+":"+json;
        }
        private string GetTypeStr(string json)
        {
            string header = json.Substring(0, json.IndexOf(":"));
            return header;
        }

        private T GetObject<T>(string json_v)
        {

             T value = JsonConvert.DeserializeObject<T>(json_v);
            return value;
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ReflectExample r = new ReflectExample();
            r.value1 = "v1";
            r.value2 = 2;
            r.property1 = "p1";
            //转换为字符串
            string jsonpheader = SendObjectToStr<ReflectExample>(r);


            //转换为对象
            if (GetTypeStr(jsonpheader) == r.GetType().FullName)
            {
                ReflectExample v= GetObject<ReflectExample>(jsonpheader.Substring(jsonpheader.IndexOf(":")));
            }
        }
        /// <summary>
        /// 根据字符串输入的如下:类名、方法名、方法参数类型。 通过反射进行调用执行类的对应方法。
        /// 反射相比直接定义和调用来说，更适合编译器中的编写，以及注解Attribute的调用，但是性能开销也相比多些。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button48_Click(object sender, EventArgs e)
        {
            Assembly ass = typeof(Utils).Assembly;
            Type t = ass.GetType("MarketRiskUI.ReflectExample");

           

            object[] ps = new object[]{ "construct 1" };
            //调用有参数的构造函数
            object obj = Activator.CreateInstance(t, ps);
            //获取方法，有两个参数类型
            MethodInfo method = t.GetMethod("Show",new Type[] { Type.GetType("System.String"), Type.GetType("System.Int32") });
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance; //这个其实是GetMethod默认设置
            object[] ps2 = new object[] { "p1",2 };
            //执行方法
            object rtn = method.Invoke(obj, flag, Type.DefaultBinder, ps2, null);
            MessageBox.Show(rtn.ToString());



        }

        private void button49_Click(object sender, EventArgs e)
        {
            string str_log = "";
            str_log +="Host domain: " + AppDomain.CurrentDomain.FriendlyName + "\r\n";
            str_log +="Creating new AppDomain.\r\n";
            AppDomain domain = AppDomain.CreateDomain("MyDomain");
            str_log +="child domain: " + domain.FriendlyName;
            MessageBox.Show(str_log);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            string str_log = "";
            str_log += "Host domain: " + AppDomain.CurrentDomain.FriendlyName + "\r\n";
            str_log += "Creating new AppDomain.\r\n";
            AppDomain domain = AppDomain.CreateDomain("MyDomain");
            str_log += "child domain: " + domain.FriendlyName + "\r\n";
            
            try
            {
                AppDomain.Unload(domain);

                str_log += domain.FriendlyName;

            }
            catch (AppDomainUnloadedException err)
            {
                str_log += err.GetType().FullName;
            }


            MessageBox.Show(str_log);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            string str_log = "";
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = @"d:\domainTest\";
            str_log += "Host domain: " + AppDomain.CurrentDomain.FriendlyName + "\r\n";
            str_log += "Creating new AppDomain.\r\n";
            AppDomain domain = AppDomain.CreateDomain("MyDomain");
            str_log += "child domain: " + domain.FriendlyName + "\r\n";
            str_log += "Application base is: " + domain.SetupInformation.ApplicationBase +"\r\n";
            try
            {
                
                AppDomain.Unload(domain);

            }
            catch (AppDomainUnloadedException err)
            {
                
            }


            MessageBox.Show(str_log);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            string str_log = "";
            str_log = AppDomain.CurrentDomain.BaseDirectory + "\r\n";
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain domain = AppDomain.CreateDomain("mydomain", null, domaininfo);
            //TODO：未完成 ，等待某天吧，可以参考 DLLDynamic\DllDynamicImport\TestClassLibrary\MyAssemblyDynamicLoader.cs

            //https://www.cnblogs.com/weifeng123/p/8855629.html  程序集

        }

        private void button51_Click(object sender, EventArgs e)
        {
            TestExtensionMethod.Example();
        }

   


    }

    class ReflectExample
    {
        private string value0;
        public string value1;
        public int value2;
        public string property1 { get; set; }
        private event Action evt1;
        public ReflectExample()
        { 
        }

        public ReflectExample(string def)
        {
            Console.WriteLine("构造函数调用："+ def);
        }

        public string Show()
        {
            return value0+":"+value1 + "-" + value2.ToString();
        }
        public string Show(string v1, int v2)
        {
            return v1+v2.ToString();
        }
    }
}
