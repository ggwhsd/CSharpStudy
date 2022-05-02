using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI
{
    /// <summary>
    /// 扩展方法，类必须是static，方法必须是static，方法第一个参数必须是要扩展的那个类且有this关键字.
    /// 
    /// 扩展方法，是c#很早就支持的功能，我是直到netcore5的时候才知道，因为看了aspnetcore的源代码，发现使用了。
    /// </summary>
    public static class ExtensionMethodExample
    {
        static public void ExtensionMethod1(this CoreClassForExtension minimumFunctionClass)
        {
            Console.WriteLine("CoreClassForExtension的扩展方法ExtensionMethod1");
        }
        static public int ExtensionMethod2(this CoreClassForExtension minimumFunctionClass, int a, int b)
        {
            Console.WriteLine("CoreClassForExtension的扩展方法ExtensionMethod2");
            return a + b;
        }

    }

    /// <summary>
    /// 没有任何方法
    /// </summary>
    public sealed class CoreClassForExtension
    {
        
    }

    public class TestExtensionMethod
    {
        public static void Example()
        {
            CoreClassForExtension cc = new CoreClassForExtension();
            cc.ExtensionMethod1();
            cc.ExtensionMethod2(1, 2);
        }
    }
}
