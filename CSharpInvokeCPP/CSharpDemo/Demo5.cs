using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo5
    {
        //by value方式
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        static extern int TestArrayOfInts([In, Out] int[] array, int size);


        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr NewArray(int size);
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        static extern int DeleteArray(IntPtr ppArray);
        
        //引用方式处理指针，引用本身对应C++中的指针，所以如下
        //ref对应指针，IntPtr对应指针，等价于 int** array
        //ref int size等价于 int* size
        [DllImport("CSharpInvokeCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int TestRefArrayOfInts(ref IntPtr array, ref int size);

        //by value方式，不可改变pMatrix的内存空间大小，先把pMatrix从托管拷贝到非托管，最后pMatrix会从非托管内存中回拷贝到托管内存中。
        [DllImport("CSharpInvokeCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int TestMatrixOfInts([In, Out] int[,] pMatrix, int row);



        public void Test()
        {
            int[] array1 = new int[10];
            Console.WriteLine("Integer array passed ByVal before call:");
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i;
                Console.Write(" " + array1[i]);
            }
            int count = 10000;
            while (count > 0)
            {
                count--;
                int sum1 = Demo5.TestArrayOfInts(array1, array1.Length);
               
                
            }
            Console.WriteLine("\nInteger array passed ByVal after call:");
            foreach (int i in array1)
            {
                Console.Write(" " + i);
            }
        }

        public void Test2()
        {
            int[] array2 = new int[10];
            int size = array2.Length;
            Console.WriteLine("\n\nInteger array passed ByRef before call:");
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = i;
                Console.Write(" " + array2[i]);
            }
            //两种非托管内存申请方式，对于简单的字节内存，可以使用Marshal.AllocHGlobal，对于创建复杂类的内存，采用类似Demo5.NewArray方式。
            //IntPtr buffer = Demo5.NewArray(10);
            IntPtr buffer = Marshal.AllocHGlobal(10);
            Marshal.Copy(array2, 0, buffer, 10);

            int sum2 = Demo5.TestRefArrayOfInts(ref buffer, ref size);
            Console.WriteLine("\nSum of elements:" + sum2);
            if (size > 0)
            {
                int[] arrayRes = new int[size];
                Marshal.Copy(buffer, arrayRes, 0, size);
                Console.WriteLine("\nInteger array passed ByRef after call:");
                foreach (int i in arrayRes)
                {
                    Console.Write(" " + i);
                }
            }
            else
            {
                Console.WriteLine("\nArray after call is empty");
            }
            //Demo5.DeleteArray(buffer);
            Marshal.FreeHGlobal(buffer);
        }

        public void Test3()
        {
            // matrix ByVal
            const int DIM = 5;
            int[,] matrix = new int[DIM, DIM];

            Console.WriteLine("\n\nMatrix before call:");
            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    matrix[i, j] = j;
                    Console.Write(" " + matrix[i, j]);
                }

                Console.WriteLine("");
            }

            int sum3 = Demo5.TestMatrixOfInts(matrix, DIM);
            Console.WriteLine("\nSum of elements:" + sum3);
            Console.WriteLine("\nMatrix after call:");
            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }

                Console.WriteLine("");
            }
        }
    }
}
