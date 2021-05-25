using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo4
    {
        //必须声明，否则执行一次就会程序终止退出。
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackDelegate(int a, string param); //声明委托  

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void processCallback(int a, CallbackDelegate call);

        public void Test()
        {
            CallbackDelegate myDelegate = new CallbackDelegate(CallbackFunc);
            int i = 0;
            while (i < 3)
            {
                processCallback(25, myDelegate);
                i++;
                Thread.Sleep(1000);
            }

   
        }
        public static void CallbackFunc(int a, string param)
        {
            Console.WriteLine("1: {0}", a);
            Console.WriteLine("2: {0}", param);
        }
    }
}
