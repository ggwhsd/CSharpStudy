using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Program
    {
        static void TestOne()
        {
            Console.WriteLine("调用 Native C++的dll结果：");
            int result = CPPDLL.Add(10, 20);
            Console.WriteLine("10 + 20 = {0}", result);

            result = CPPDLL.Sub(30, 12);
            Console.WriteLine("30 - 12 = {0}", result);

            result = CPPDLL.Multiply(5, 4);
            Console.WriteLine("5 * 4 = {0}", result);

            result = CPPDLL.Divide(30, 5);
            Console.WriteLine("30 / 5 = {0}", result);


            IntPtr ptr = CPPDLL.Create("李平", 27);
            //将结构体指针转换为C#对应的类
            CPPDLL.User user = (CPPDLL.User)Marshal.PtrToStructure(ptr, typeof(CPPDLL.User));
            //将字符串数组转换为string的方式
            //IntPtr tempAddrName = BthGetName(allAddrs[i])；//接收返回的数组
            //string m_strAddrName = Marshal.PtrToStringAnsi(tempAddrName);//将其转换为字符串

            Console.WriteLine("Name: {0}, Age: {1},", user.Name, user.Age);
            Console.WriteLine("Name2: {0}, Age2: {1},", user.Name2, user.Age2);


            Console.WriteLine("设置c++的字符串指针解析：");
            CPPDLL.setStringTest("asdfsdf");

            Console.WriteLine("c++返回的字符串指针解析：");
            IntPtr tempPtr = CPPDLL.getStringTest("xxx", 32);
            Console.WriteLine("{0:10}", Marshal.PtrToStringAnsi(tempPtr));

            Console.WriteLine("函数参数传出：");
            int i = 5;
            CPPDLL.setRef(ref i);
            Console.WriteLine(" i = {0}", i);

            Console.WriteLine("函数参数传入数组：");
            int[] sumArray = new int[10];
            sumArray[2] = 188;
            int sumA = CPPDLL.sumArray(sumArray, sumArray.Length);
            Console.WriteLine("数组求和{0}", sumA);

            Console.WriteLine("函数参数传出数组：");
            int[] sumArray2 = new int[10];
            CPPDLL.copyArray(sumArray, sumArray.Length, sumArray2);
            foreach (int value in sumArray2)
            {
                Console.WriteLine("{0} ", value);
            }

            Console.WriteLine("函数参数传入struct：");
            CPPDLL.User user2 = new CPPDLL.User();
            user2.Name = "我们";
            user2.Age = 2;
            CPPDLL.setStruct(user2);

            Console.WriteLine("函数参数传出struct数组：");
            CPPDLL.User[] user3 = new CPPDLL.User[3];
            user3[0].Name = "老鹰一号";
            user3[0].Age = 1;
            CPPDLL.getStruct(user3, 3);

            foreach (CPPDLL.User value in user3)
            {
                Console.WriteLine("Name: {0}, Age: {1},", value.Name, value.Age);
            }

            Console.WriteLine("函数参数传入传出struct数组：");
            CPPDLL.User[] user5 = new CPPDLL.User[3];
            user5[0].Name = "老鹰二号";
            user5[0].Age = 2;
            CPPDLL.copyStructs(user5, user5, 3);
            foreach (CPPDLL.User value in user5)
            {
                Console.WriteLine("Name: {0}, Age: {1},", value.Name, value.Age);
            }


            Console.WriteLine("调用 C#的dll结果：");
            CSharpDLL.Class1 dllTest = new CSharpDLL.Class1();
            Console.WriteLine(dllTest.Show());



        }
        static void Main(string[] args)
        {
            TestOne();

            //获取系统时间函数
            Demo1 d1 = new Demo1();
            d1.Test();

            //托管内存和非托管内存之间的创建和拷贝
            Demo2 d2 = new Demo2();
            //d2.Test();
            d2.Test3();
            GC.Collect();

            //创建非托管程序中指针的对应托管指针，从而为后续访问非托管对象提供方便。
            Demo3 d3 = new Demo3();
            d3.Test();
            
            //回调函数的示例
            Demo4 d4 = new Demo4();
            d4.Test();


            Demo5 d5 = new Demo5();
            d5.Test();

            d5.Test2();
            d5.Test3();

            //字符串数组
            Demo6 d6 = new Demo6();
            d6.Test();

         

            Console.ReadLine();



        }
    
    }
}
