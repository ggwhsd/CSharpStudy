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
        public static extern IntPtr getStringTest(string name, int age); //返回值为IntPtr则是引用非托管内存。如果为string，则直接是从非托管copy back到托管内存环境中

        //string的处理方式，
        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "setStringTest", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStringTest([MarshalAs(UnmanagedType.LPStr, SizeConst = 10)]string Name);

        //引用，by reference
        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "setRef", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setRef(ref int age);  

        //传入数组，by value
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumArray(int[] arr,int length); 

        //int[] 可以对应 c++中的int *。调用完成后，会自动将非托管环境中的int *对应的内存空间数据copy back到C#的托管环境的int []中。
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyArray(int[] number, int length, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] ptr);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStruct(User user);// by value

        //使用out，则该参数无法传入，只能用作传出；使用in则无法传出，只能传入,默认为in。  [Out,in]同时
        //out对应的变量是在托管环境中调用该函数前由用户创建的，不能在非托管中进行创建
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getStruct([Out] User[] user,int length); 

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyStructs(User[] user, [Out]User[] user2,int length);

        //IntPtr 用于指针，可以用来表示非托管环境中的对象地址
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refStructs(IntPtr user, int length);

        //IntPtr 用于指针，在非托管环境中创建地址，返回指针给IntPtr，用于后续操作该对象，后续只要继续传入该地址，在非托管环境中就可以找到对应的地址空间了。
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateArray(int length);

        //针对创建的IntPtr的内存进行释放。
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DestroyArray(IntPtr user);

        [StructLayout(LayoutKind.Sequential)]
        public struct DeviceInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szDeviceName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
            public string szMACAddress;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
            public string szDeviceIP;


        }
      
    }
}
