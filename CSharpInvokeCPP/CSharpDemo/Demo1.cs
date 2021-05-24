using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Demo1
    {
        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTime systemTime);

        [StructLayout(LayoutKind.Sequential)]
        class SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milsecond;
        }

        public void Test()

        {
            SystemTime st = new SystemTime();
            GetSystemTime(st);
            Console.WriteLine("StructLayout, call GetSystemTime " + st.Year + "-" + st.Month + "-" + st.Day + " " + st.Hour + ":" + st.Minute + ":" + st.Second);
        }
    }
}
