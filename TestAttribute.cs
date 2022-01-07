
//定义两个编译器选项
#define CONDITION1
//#define CONDITION2
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI
{
    class TestAttribute
    {
        public void TestMethod()
        {
            Console.WriteLine("Calling Method1");
            Method1();
            Console.WriteLine("Calling Method2");
            Method2();
            Console.WriteLine("Using the Debug class");
            Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.WriteLine("DEBUG is defined");
        }
        [Conditional("CONDITION1")]
        private void Method1()
        {
            Console.WriteLine("CONDITION1 is defined");
        }
        [Conditional("CONDITION2")]
        private void Method2()
        {
            Console.WriteLine("CONDITION2 is defined");
        }
    }
}
