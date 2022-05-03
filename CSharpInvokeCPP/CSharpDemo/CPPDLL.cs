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

        /// <summary>
        /// 一般可以不用MarshalAs进行类型明确，.NET都有自己的默认值，但是有时候需要明确从托管转换为非托管的类型时，则需要MarshalAs进行明确。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 对于简单类型，可以使用ref，进行双向传递。
        /// </summary>
        /// <param name="age"></param>
        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "setRef", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setRef(ref int age);

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumArray(int[] arr,int length);

        /// <summary>
        /// LPArray 指向 C 样式数组的第一个元素的指针。可以进行双向操作。
        /// 当从托管到非托管进行封送处理时，该数组的长度由托管数组的长度确定。
        /// 当从非托管到托管进行封送处理时，将根据 MarshalAsAttribute.SizeConst 和 MarshalAsAttribute.SizeParamIndex 字段确定该数组的长度。
        /// 
        /// 以下函数将数组拷贝到另一个数组上。在C#中可以直接读取另一个数组来验证结果是否正确。
        /// 对于参数，默认都是in，即单向传递给非托管。 
        /// 使用LPArray会回传。
        /// </summary>
        /// <param name="number">传入数组，即从托管到非托管，供c程序使用的</param>
        /// <param name="length">传入数组长度</param>
        /// <param name="ptr">LPArray说明此处要转换为非托管环境的指针，同时指定数组长度为当前参数中位置为1的参数，即length。不过，在实际使用时，指定错了位置，也没发现异常，奇了怪了</param>
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyArray(int[] number, int length, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] ptr);

        /// <summary>
        /// 参数默认是In修饰，在Dll内部修改不会回传给C#
        /// </summary>
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStruct(User user);

        /// <summary>
        ///  Out修饰，会回传给C#。此处参数为结构体数组，则会将对应结构体进行从非托管环境转换一份到托管环境，这个过程肯定会在托管环境申请内存创建对象的。
        ///  * 使用out，则该参数无法传入，只能用作传出；.
        ///  * 使用in则无法传出，只能传入,默认为in
        /// </summary>
        /// <param name="user"></param>
        /// <param name="length"></param>
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getStruct([Out] User[] user,int length); 

        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void copyStructs(User[] user, [Out]User[] user2,int length);



        /// <summary>
        /// c++返回的指针，C#可以用IntPtr来保管。 从而实现后续以此IntPtr传递给C++进行对象维护。
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateArray(int length);

        /// <summary>
        /// 通过创建得到的指针，对其进行调用方法操作。不过，指针是没有类型的，也就是一切类型。传递到c或者c++的dll中后，可以c或者c++程序自己从void*转换为对应类型操作。
        /// </summary>
        /// <param name="user"></param>
        /// <param name="length"></param>
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refStructs(IntPtr user, int length);


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
