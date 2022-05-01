using DllDynamicImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 采用特性方式来定义
    /// </summary>
    [MyInterfaceAttribute(true, "InterfaceTest")]
    class Class3
    {
        public void Run()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
