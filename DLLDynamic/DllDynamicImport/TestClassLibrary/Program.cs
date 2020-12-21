using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DllDynamicImport;
namespace TestClassLibrary
{
    class Program
    {
        static List<InterfaceTest> list = new List<InterfaceTest>();

        static void Main(string[] args)
        {
            string dir = AppContext.BaseDirectory +@"\Libs\";
            Console.WriteLine(dir);
           
            string assemblyName = "ClassLibrary";
            for (int i = 0; i < 2; i++)
            {
                Assembly assembly = Assembly.LoadFile(dir + assemblyName + (i + 1).ToString() + ".dll");
                Type type = assembly.GetType(assemblyName + (i + 1).ToString() + ".Class1");
                DllDynamicImport.InterfaceTest instance = System.Activator.CreateInstance(type) as DllDynamicImport.InterfaceTest;
                list.Add(instance);
                try
                {
                    list[i].Run();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            System.Console.ReadLine();
            
        }
    }
}
