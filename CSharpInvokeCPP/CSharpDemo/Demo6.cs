using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo6
    {
        // Declares a managed prototype for an array of strings by value.
        //等价于  MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPArray, SizeParamIndex=1, ArraySubType=System.Runtime.InteropServices.UnmanagedType.LPStr)
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int TestArrayOfStrings(
            [In, Out] string[] stringArray, int size);


        public void Test()
        {
            string[] array1 = new string[10];
            Console.WriteLine("\n\nstring array passed ByVal before call:");
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = "hello";
                Console.Write(" " + array1[i]);
            }
         
        
            int lenSum = Demo6.TestArrayOfStrings(array1, array1.Length);
            Console.WriteLine("\nSum of string lengths:" + lenSum);
            
            Console.WriteLine("\nString array passed ByVal after call:");
            foreach (string i in array1)
            {
                Console.Write(" " + i);
            }
        }
    }
}
