﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDynamicImport;
namespace ClassLibrary1
{
    [MyInterfaceAttribute(true, "InterfaceTest")]
    public class Class1 : InterfaceTest
    {
        public void Run()
        {
            throw new Exception(this.GetType().ToString());
        }
    }
}
