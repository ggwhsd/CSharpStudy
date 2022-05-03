using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo2
    {    // 通过托管字符串，分配非托管内存
        private IntPtr CreateGlobalAnsi(string str)
        {
            return Marshal.StringToHGlobalAnsi(str);
        }
        // 通过长度，分配非托管内存
        private IntPtr CreateGlobal(int copylen)
        {
            return Marshal.AllocHGlobal(copylen + 1);
        }
        public void Test()
        {
            string stringA = "I seem to be turned around!";
            int copylen = stringA.Length;
            int count = 10000000;
            IntPtr sptr = CreateGlobalAnsi(stringA);
            IntPtr dptr = CreateGlobal(copylen + 1);
            while (count > 0)
            {
                count--;
                IntPtr sptr1 = CreateGlobalAnsi(stringA);
                IntPtr dptr2 = CreateGlobal(copylen + 1);
                //如果不释放，则内存会占用1G左右。直到程序关闭为止。
                Marshal.FreeHGlobal(sptr1);
                Marshal.FreeHGlobal(dptr2);
            }


            // The unsafe section where byte pointers are used.
            unsafe
            {
                byte* src = (byte*)sptr.ToPointer();
                byte* dst = (byte*)dptr.ToPointer();

                if (copylen > 0)
                {
                    // set the source pointer to the end of the string
                    // to do a reverse copy.
                    src += copylen - 1;

                    while (copylen-- > 0)
                    {
                        *dst++ = *src--;
                    }
                    *dst = 0;
                }
            }

            string stringB = Marshal.PtrToStringAnsi(dptr);
            Console.WriteLine("Original:\n{0}\n", stringA);
            Console.WriteLine("Reversed:\n{0}", stringB);

            // 释放托管内存
            Marshal.FreeHGlobal(dptr);
            Marshal.FreeHGlobal(sptr);
        }
        /// <summary>
        /// HandleRef的使用
        /// </summary>
        public void Test2()
        {

            var obj = new object();

            var ptr = new IntPtr(1337);
            var handleRef = new HandleRef(obj, ptr);
            if (ptr == (IntPtr)handleRef)
            {
                Console.WriteLine("ptr == (IntPtr)handleRef");
            }
            if (ptr == HandleRef.ToIntPtr(handleRef))
            {
                Console.WriteLine("ptr == HandleRef.ToIntPtr(handleRef)");
            }
            if (obj == handleRef.Wrapper)
            {
                Console.WriteLine("obj == handleRef.Wrapper");
            }
            if (ptr == handleRef.Handle)
            {
                Console.WriteLine("ptr == handleRef.Handle");
            }

        }
        class DateHandle
        {
            //将非托管的字符串和托管对象进行绑定，以便管理资源
            //swig开源库就是采用此类方法进行的。
            private HandleRef ptr;
            public DateHandle(string str)
            {
                //创建非托管内存中
                IntPtr data = Marshal.StringToHGlobalAnsi(str);
                //将Object和非托管内存作为绑定，进行一一映射。
                ptr = new HandleRef(this, data);
            }
            public string get()
            {
                //将非托管的内存拷贝到托管内存中。
                return Marshal.PtrToStringAnsi(ptr.Handle);
            }
            ~DateHandle()
            {
                Console.WriteLine("释放非托管内存");
                //释放非托管内存
                Marshal.FreeHGlobal(ptr.Handle);
            }
        }
        public void Test3()
        {
            DateHandle df = new DateHandle("test HandleRef");
            Console.WriteLine("获取数据:" + df.get());

        }

    }
}
