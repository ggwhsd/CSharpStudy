using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            byteArray= System.Text.Encoding.Default.GetBytes("Hello");
            string str = System.Text.Encoding.Default.GetString(byteArray);
            Console.WriteLine(str);
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

        private void button5_Click(object sender, EventArgs e)
        {
            //播放系统声音
            System.Media.SystemSounds.Beep.Play();
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
            
            }
            public int CompareTo(Student other)
            {
                return this.Age.CompareTo(other.Age);
            }
        }
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
            foreach (Student s in list2)
            {
                Console.WriteLine(s.ToString());
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
        private void button10_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DateTime dt,dt1;
            dt = DateTime.Now;
            dt1 = dt.AddSeconds(70);
            MessageBox.Show("dt = DateTime.Now = "+ dt.ToLongTimeString()+ " \r\n dt.AddSeconds(70)=" + dt1.ToLongTimeString());
            MessageBox.Show("dt.substratc = " + dt1.Subtract(dt).TotalSeconds);
        }
    }
}
