using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllDynamicImport
{
    //定义一个特性。  从而增加程序配置的灵活性。 特性是一种允许我们向程序的程序集添加元数据的语言结构，它是用于保存程序结构信息的某种特殊类型的类。
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class MyInterfaceAttribute:System.Attribute
    {

        readonly bool isnable;
        readonly string name;
      
        public MyInterfaceAttribute(bool isnable, string myInterfaceName)
        {
            this.isnable = isnable;
            this.name = myInterfaceName;
           
        }

        public bool IsEnable
        {
            get { return isnable; }
        }
        public string MyInterfaceName
        {
            get { return name; }
        }


    }

    
   
}
