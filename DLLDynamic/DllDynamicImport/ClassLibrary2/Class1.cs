using DllDynamicImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    
    public class Class1 : InterfaceTest
    {
        public void Run()
        {
            throw new Exception(this.GetType().ToString());
        }
    }
}
