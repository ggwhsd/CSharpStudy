using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class Utils : Form
    {
        public Utils()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byteArray = new byte[1024];
            byteArray= System.Text.Encoding.Default.GetBytes("Hello");
            string str = System.Text.Encoding.Default.GetString(byteArray);
            Console.WriteLine(str);
            byteArray = Encoding.ASCII.GetBytes("world");
            str = System.Text.Encoding.ASCII.GetString(byteArray);
            Console.WriteLine(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string name = Console.ReadLine();
            string name = "你好";
            string welcome = "welcome to C#";
            string result = string.Format("Hello {0}, {1}", name, welcome);
            Console.WriteLine(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strDate = "2014-08-01";
            DateTime dt1 = Convert.ToDateTime(strDate);
            string strDateTime = "2014-08-01 10:57:31";
            DateTime dt2 = Convert.ToDateTime(strDateTime);

            DateTime dt3 = DateTime.Parse(strDateTime);

            DateTime.TryParse(strDateTime, out dt3);

            /*
             * 使用ParseExact方法进行转换
             * 这里需要带入要转换的日期格式参数
             * 这里的日期格式可以自定义，比如yyyyMMddHHmmss,就可以传入20140801135205进行转换
             * 第三个参数是区域性特定格式信息，这里使用当前系统默认区域(即中国)            
             */
            DateTime dt4 = DateTime.ParseExact(strDateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

            /*
            * 使用TryParseExact方法进行转换
            * 基本用法和大致参数ParseExact方法一样
            * 只是传入返回值的DateTime类型的out形参,这里是dt4
            * 第四个参数为：格式设置选项，既DateTimeStyles枚举，设置NONE即可
            */

            DateTime.TryParseExact(strDateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt4);

            strDateTime = "10:57:31";
            DateTime.TryParse(strDateTime, out dt3);
            Console.WriteLine("{0}",dt3.ToLongTimeString());
            Console.WriteLine("{0}", dt3.ToShortTimeString());

        }
    }
}
