using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace CSharpDemo
{
    class CPPDLL
    {
        /*
         * DllImport作为C#中对C++的DLL类的导入入口特征，并通过static extern对extern “C”进行对应。
         */
        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Add", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Sub", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sub(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Multiply", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Divide", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Divide(int x, int y);


        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Create", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Create([MarshalAs(UnmanagedType.LPStr, SizeConst = 32)]string name, int age);



        [StructLayout(LayoutKind.Sequential)]
        public struct User
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name;

            public int Age;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public string Name2;

            public double Age2;
        }
  


        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "getStringTest", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr getStringTest(string name, int age);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "setStringTest", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStringTest([MarshalAs(UnmanagedType.LPStr, SizeConst = 10)]string Name);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "setRef", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setRef(ref int age);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumArray(int[] arr,int length);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyArray(int[] number, int length, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] ptr);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStruct(User user);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getStruct([Out] User[] user,int length); //使用out，则该参数无法传入，只能用作传出；使用in则无法传出，只能传入,默认为in

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyStructs(User[] user, [Out]User[] user2,int length);


    }
}
