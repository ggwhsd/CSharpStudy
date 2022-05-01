#define XXX


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;




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




    /// <summary>
    /// 演示基础库默认的特性。Obsolete,Conditional,CallerMemberName,CallerFilePath,CallerLineNumber
    /// </summary>
    public class UseDefaultAttribute
    {
        [Obsolete("不推荐后续使用，请注意改为调用use方法")]
        private static void useObsolete()
        { 

        }
        /// <summary>
        /// 文件首行定义了  #define XXX，如下方法才能使用
        /// </summary>
        [Conditional("XXX")]
        private static void useDebugConditional()
        {
            Console.WriteLine("define XXX");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        private static void WriteLog(object message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("文件:{0} 行号:{1} 方法名:{2},消息:{3}", sourceFilePath, sourceLineNumber, memberName, message);
        }
        private static void use()
        {

        }

        public static void Demo()
        {
            UseDefaultAttribute.useObsolete();
            UseDefaultAttribute.useDebugConditional();
            UseDefaultAttribute.WriteLog("记录一行信息，并显示对应文件名、行号和方法名。");



        }
    }
}
