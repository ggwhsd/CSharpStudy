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

        /// <summary>
        /// 导入程序集到默认应用域。应用域可以看作是一个exe启动之后的程序运行环境，该环境中负责创建和管理对象，一个进程可以开启多个应用域，多个环境之间无法直接调用对方管理的类对象。
        /// 此处使用接口方式，展示了一个插件方式开发的基本框架。
        /// </summary>
        private static void LoadAssemblyInDefaultAppDomain()
        {
            Console.WriteLine($"》》》》》》》》》》》》》》示例: 接口定义方式导入插件到默认应用域《《《《《《《《《《《《");
            string dir = AppContext.BaseDirectory + @"Libs\";
            Console.WriteLine($"  当前Lib目录:{dir}");

            string assemblyName = "ClassLibrary";
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"  导入ClassLibrary{i}.dll文件为程序集:{dir}  【开始】");
                Assembly assembly = Assembly.LoadFile(dir + assemblyName + (i + 1).ToString() + ".dll");
                Console.WriteLine($"  导入ClassLibrary{i}.dll文件:{dir}  【完成】");
                Console.WriteLine();
              
                Console.WriteLine($"  获取程序集中的ClassLibrary{i}中所有实现了InterfaceTest的类");
                //如果导入特定名称的类，使用该方法，不过一般都是导入特定实现接口的类，所以应该使用循环
                //Type type = assembly.GetType(assemblyName + (i + 1).ToString() + ".Class1");
                foreach (Type type in assembly.GetTypes())
                {
                   

                    Console.WriteLine($"  判断是否实现了接口InterfaceTest");
                    if (type.GetInterface("InterfaceTest") == typeof(InterfaceTest) && type.IsAbstract==false && type.IsInterface==false)
                    {
                        Console.WriteLine($"  {type.FullName} 实现了接口InterfaceTest，所以可以直接创建类型实例，返回该接口");
                        DllDynamicImport.InterfaceTest instance = System.Activator.CreateInstance(type) as DllDynamicImport.InterfaceTest;

                        Console.WriteLine($"  将刚创建的{type.Name}实例添加到列表中保存，此处可以将实例当作一个插件");
                        list.Add(instance);
                    }
                    else
                    {
                        Console.WriteLine($"  {type.FullName}类型 没有 实现了接口InterfaceTest，跳过该类");
                    }
                }
               
            }
            Console.WriteLine($"  执行所有插件");
            foreach (var pluginInterface in list)
            {
                try
                {
                    
                    pluginInterface.Run();
                }
                catch (Exception err)
                {
                    Console.WriteLine("  异常:" + err.Message);
                }
            }
            System.Console.ReadLine();
        }




        /// <summary>
        /// 导入程序集到默认应用域。应用域可以看作是一个exe启动之后的程序运行环境，该环境中负责创建和管理对象，一个进程可以开启多个应用域，多个环境之间无法直接调用对方管理的类对象。
        /// 此处使用接口+特性方式，展示了一个插件方式开发的基本框架。
        /// </summary>
        private static void LoadAssemblyInDefaultAppDomain2()
        {
            Console.WriteLine($"》》》》》》》》》》》》》》示例: 接口定义+特性  导入插件到默认应用域《《《《《《《《《《《《");
            string dir = AppContext.BaseDirectory + @"Libs\";
            Console.WriteLine($"  当前Lib目录:{dir}");

            string assemblyName = "ClassLibrary";
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"  导入ClassLibrary{i}.dll文件为程序集:{dir}  【开始】");
                Assembly assembly = Assembly.LoadFile(dir + assemblyName + (i + 1).ToString() + ".dll");
                Console.WriteLine($"  导入ClassLibrary{i}.dll文件:{dir}  【完成】");
                Console.WriteLine();

                Console.WriteLine($"  获取程序集中的ClassLibrary{i}中所有定义了特性MyInterfaceAttribute.isenable=true，且 实现了InterfaceTest的类");
                foreach (Type type in assembly.GetTypes())
                {
                    //获取类的特性
                    object[] attrs = type.GetCustomAttributes(false);
                    foreach (Attribute att in attrs)
                    {
                        if (att.GetType() == typeof(MyInterfaceAttribute))
                        {
                            MyInterfaceAttribute a = att as MyInterfaceAttribute;
                            if (a.IsEnable)
                            {
                                Console.WriteLine($"  判断是否实现了接口InterfaceTest");
                                if (type.GetInterface("InterfaceTest") == typeof(InterfaceTest) && type.IsAbstract == false && type.IsInterface == false)
                                {
                                    Console.WriteLine($"  {type.FullName} 实现了接口InterfaceTest，所以可以直接创建类型实例，返回该接口");
                                    DllDynamicImport.InterfaceTest instance = System.Activator.CreateInstance(type) as DllDynamicImport.InterfaceTest;

                                    Console.WriteLine($"  将刚创建的{type.Name}实例添加到列表中保存，此处可以将实例当作一个插件");
                                    list.Add(instance);
                                }
                                else
                                {
                                    Console.WriteLine($"  {type.FullName}类型 没有 实现了接口InterfaceTest，跳过该类");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"  {type.FullName}类型 特性定义了关闭，跳过该类");
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"  执行所有插件");
            foreach (var pluginInterface in list)
            {
                try
                {

                    pluginInterface.Run();
                }
                catch (Exception err)
                {
                    Console.WriteLine("  异常:" + err.Message);
                }
            }
            System.Console.ReadLine();
        }

        /// <summary>
        /// 创建一个新的应用域，并且在这个新环境中导入程序集和调用类对象方法。
        /// </summary>
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
            LoadAssemblyInDefaultAppDomain2();
            //LoadAssemblyInNewAppDomain();

        }
    }
}
