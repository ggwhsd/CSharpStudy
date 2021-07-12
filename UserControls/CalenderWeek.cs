using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MarketRiskUI.UserControls
{
    public partial class CalenderWeek : UserControl
    {
        public CalenderWeek()
        {
            InitializeComponent();
        }

        private DateTime chooseTime;




        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            chooseTime = monthCalendar1.SelectionStart;
            textBox1.Text = getWeekStartEnd(chooseTime);
            textBox2.Text = "第" + getWeekOfYear(chooseTime) + "周";
        }


        //根据某天，计算出该天所在的周开始和周结束的日期
        private string getWeekStartEnd(DateTime date)
        {

            var dayOfWeek = (int)date.DayOfWeek; //中国日历的星期一为一周的第一天，星期日为第七天
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //周日
                dayOfWeek = 7;
            }
            else
            {

            }
            DateTime weekStart = date.AddDays(1 - dayOfWeek);
            DateTime weekEnd = date.AddDays(7 - dayOfWeek);
            monthCalendar1.SelectionStart = weekStart;
            monthCalendar1.SelectionEnd = weekEnd;

            return weekStart.ToString("yyyy/MM/dd") + "~" + weekEnd.ToString("yyyy/MM/dd") + "\r\n";
        }
        //根据日期，计算第几周
        private int getWeekOfYear(DateTime dt)
        {
            CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
        }



    }
}
