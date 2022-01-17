using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestClassLibrary
{
    /// <summary>
    /// 在一个新的appdomain里面进行创建assembly
    /// 
    /// </summary>
    public class MyAssemblyDynamicLoader
    {
        private AppDomain appDomain;
        public readonly RemoteLoader remoteLoader;

        public MyAssemblyDynamicLoader()
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationName = "ApplicationLoader";
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            setup.PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs");
            setup.CachePath = setup.ApplicationBase;
            setup.ShadowCopyFiles = "true";	// 重点
            setup.ShadowCopyDirectories = setup.ApplicationBase;
            //setup.ConfigurationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs", "xxx.exe.config");
            //AppDomain.CurrentDomain.SetShadowCopyFiles();
            this.appDomain = AppDomain.CreateDomain("ApplicationLoaderDomain", null, setup);
            Console.WriteLine("currentAssembly:" + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("new appDomain:" + appDomain.FriendlyName);
            String name = Assembly.GetExecutingAssembly().GetName().FullName;
            this.remoteLoader = (RemoteLoader)this.appDomain.CreateInstanceAndUnwrap(name, typeof(RemoteLoader).FullName);	// 重点
        
        }

        public void Unload()
        {
            try
            {
                if (appDomain == null) return;
                AppDomain.Unload(this.appDomain);
                this.appDomain = null;
            }
            catch (CannotUnloadAppDomainException ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// 自定义一个RemoteLoader类，稍后会在默认appdomain里面调用它。
    /// </summary>
    public class RemoteLoader : MarshalByRefObject
    {
        private Assembly _assembly;

        public void LoadAssembly(string assemblyFile)
        {
            try
            {
                Console.WriteLine("currentAssembly:"+AppDomain.CurrentDomain.FriendlyName);
                _assembly = Assembly.LoadFrom(assemblyFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteMothod(string typeName, string methodName)
        {
            if (_assembly == null)
            {
                return;
            }
            var type = _assembly.GetType(typeName);
            object obj = Activator.CreateInstance(type);

            MethodInfo[] mts = type.GetMethods();
            foreach (MethodInfo m in mts) 
            {
                Console.WriteLine(m.Name);
            }

            MethodInfo method = type.GetMethod(methodName);
            try
            {
                method.Invoke(obj, new object[] { });
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
