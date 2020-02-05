using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;




//一般是给编译器来使用，作为类的扩展元数据，
//自定义也可以用。
namespace MarketRiskUI.LittleExamples
{
    [AttributeUsage(AttributeTargets.Class
        | AttributeTargets.Method,
        AllowMultiple = true)]
    public class ExampleAttribute : System.Attribute
    {
        public readonly string Url;
        private string topic;
        public string Topic
        {
            get {
                return topic;
            }
            set
            {
                topic = value;
            }
        }
        public ExampleAttribute(string url)
        {
            this.Url = url;
        }
    }
    [ExampleAttribute("https://ggw/MyClassInfo", Topic = "Test"),
Example("https://ggw.com/about/class")]
    class MyClass
    {
        [Example("http;//ggw.com/about/method")]
        public void MyMethod(int i)
        {
            return;
        }
    }

    public class UseCustomAttribute
    {
        public static void Demo()
        {
            //自己使用自定义attribute，需要通过反射的方式。
            Type myType = typeof(MyClass);
            object[] attributes = myType.GetCustomAttributes(false);
            for (int i = 0; i < attributes.Length; i++)
            {
                PrintAttributeInfo(attributes[i]);
            }
            MemberInfo[] myMembers = myType.GetMembers();
            for (int i = 0; i < myMembers.Length; i++)
            {
                Console.WriteLine("\nNumber {0}", myMembers[i]);
                Object[] myAttributes = myMembers[i].GetCustomAttributes(false);
                new Thread(() =>
                {
                    for (int j = 0; j < myAttributes.Length; j++)
                    {
                        PrintAttributeInfo(myAttributes[i]);
                    }
                }).Start();
            }
        }

        private static void PrintAttributeInfo(object v)
        {
            if (v is ExampleAttribute)
            {
                ExampleAttribute attre = (ExampleAttribute)v;
                Console.WriteLine("{0} {1}",attre.Url,attre.Topic);
            }
        }
    }
}
