using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDynamicImport;
namespace ClassLibrary1
{
    public class Class1 : InterfaceTest
    {
        void InterfaceTest.Run()
        {
            throw new Exception(this.GetType().ToString());
        }
    }
}
