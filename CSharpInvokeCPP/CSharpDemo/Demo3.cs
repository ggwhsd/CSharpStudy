using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo3
    {
        public void Test()
        {
            //创建空间，利用IntPtr来保存创建的对象
            IntPtr ptr = CPPDLL.CreateArray(1000000);
            int i = 100;
            while (i > 0)
            {
                //利用IntPtr来操作对象。
                CPPDLL.refStructs(ptr, 3);
                CPPDLL.refStructs(ptr, 3);
                CPPDLL.refStructs(ptr, 3);
                CPPDLL.refStructs(ptr, 3);
                i--;
            }
            //释放空间
            CPPDLL.DestroyArray(ptr);
        }
    }
}
