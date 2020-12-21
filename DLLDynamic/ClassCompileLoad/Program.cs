using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassCompileLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            //(1)
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            //(2)生成对应的代码文件
            CodeDomExample.GenerateCode(provider, CodeDomExample.BuildHelloWorldGraph());

            //(3)编译生成的代码文件
            CompilerResults cr = CodeDomExample.CompileCode(provider, CodeDomExample.dllorexeName + ".cs", CodeDomExample.dllorexeName + ".exe");

            if (cr.Errors.Count <= 0)
            {
                Console.WriteLine("把 "+ CodeDomExample.dllorexeName+"编译成 " + cr.PathToAssembly + " 时没有出现错误。");
            }

            /*
            //（4）可选，获取编译后的程序
            Assembly assembly = cr.CompiledAssembly;
            //（5）可选，如果是dll的话动态调用,
            object eval = assembly.CreateInstance("TestComipleUnit");
            
            MethodInfo method = eval.GetType().GetMethod("Main");
            Object rtn=method.Invoke(eval, null);
            GC.Collect();
            */



        }
       

    }

    
}
