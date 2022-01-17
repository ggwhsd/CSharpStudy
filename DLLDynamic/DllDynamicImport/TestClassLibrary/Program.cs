using System;
using System.Collections.Generic;
using System.IO;
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

        private static void LoadAssemblyInDefaultAppDomain()
        {
            string dir = AppContext.BaseDirectory + @"Libs\";
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
                    Console.WriteLine("异常啦:" + err.Message);
                }
            }
            System.Console.ReadLine();
        }

        private static void LoadAssemblyInNewAppDomain()
        {
            MyAssemblyDynamicLoader adl = new MyAssemblyDynamicLoader();
            string modulesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs/");
            adl.remoteLoader.LoadAssembly(Path.Combine("Libs/", "ClassLibrary1.dll"));
            adl.remoteLoader.ExecuteMothod("ClassLibrary1.Class1", "Run");
            adl.Unload();
        }
        /// <summary>
        /// 动态加载dll到默认程序集中
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //LoadAssemblyInDefaultAppDomain();
            LoadAssemblyInNewAppDomain();

        }
    }
}
