using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo7
    {    
        [DllImport("CSharpInvokeCPP.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setStruct2(CPPDLL.User user, ref CPPDLL.User user2);

        public void Test()
        {
            CPPDLL.User user = new CPPDLL.User();
            user.Name = "ddd";
            user.Age = 0;
            CPPDLL.User user2 = new CPPDLL.User();

            Demo7.setStruct2(user, ref user2);
        }
    }
}
