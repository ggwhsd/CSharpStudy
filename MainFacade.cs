﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarketRiskUI.FluentScheduler;
using MarketRiskUI.LittleExamples;
using MarketRiskUI.UserControls;
using MarketRiskUI.WebExamples;

namespace MarketRiskUI
{
    public partial class MainFacade : Form
    {
        public MainFacade()
        {
            InitializeComponent();
        }

        private void 屏幕保护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenProtectExample sce = new ScreenProtectExample();
            sce.Show();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 historyMain = new Form1();
            historyMain.Show();
        }

        private void 素数计算使用bool方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimeFilter pf = new PrimeFilter();
            pf.Show();
        }

        private void 排块游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridGame gg = new GridGame();
            gg.Show();
        }

        private void 常用工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils tools = new Utils();
            tools.Show();
        }

        private void 复制文件删除注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOStudy copyFile = new IOStudy();
            copyFile.StreamInFileStream("./AttributeExample.cs", "./AttributeExample.txt");
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcExample cal = new CalcExample();
            cal.Show();
        }

        private void gDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI gdi = new GDI();
            gdi.Show();
        }

        private void webClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClientExample wce = new WebClientExample();
            wce.Show();
        }

        private void webRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebRequestAndResponse req = new WebRequestAndResponse();
            req.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GuessEnCode ge = new GuessEnCode();
            ge.Show();
        }

        private void getGoldPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetGoldPrice gold = new GetGoldPrice();
            gold.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Crawler cl = new Crawler();
            cl.Show();
        }

        private void getBaiduSuggestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaiduSuggest bs = new BaiduSuggest();
            bs.Show();
        }

        private void gridviewnodatabindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_datagridview1 form_Datagridview1 = new Form_datagridview1();
            form_Datagridview1.Show();
        }

        private void gridviewvirtualModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_datagidview2 form_Datagidview2 = new Form_datagidview2();
            form_Datagidview2.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            datagridviewBindList dvg = new datagridviewBindList();
            dvg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double d = 123.33332321231123;

            MessageBox.Show(d.ToString("f6"));
        }

        private void log4NetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log4NetDemo demo = new Log4NetDemo();
            demo.Show();
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorUI col = new ColorUI();
            col.Show();
        }

        private void redisTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redisTest rt = new redisTest();
            rt.Show();
        }

        private void 创建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 拖拽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DragExample de = new DragExample();
            de.Show();
        }

        private void csv文件读写库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvHelperTest cht = new CsvHelperTest();
            cht.Show();
        }

        private void gDIlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI_line gdline = new GDI_line();
            gdline.Show();
        }

        private void tPL并行编程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskAsyncForm p = new TaskAsyncForm();
            p.Show();
        }

        private void task基本使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {






            
            
        }

        private void action和FuncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionExample ae = new ActionExample();
            ae.TestDelegate();
            ae.TestAction();
            ae.TestFunc();
            ae.TestActionLambda();
        }

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask1_Start();
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask2_Create1();
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask3_Create2();
        }

        private void task5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask4_MultiTaskManage();
        }

        private void task5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask5_parentTask();
        }

        private void task6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask6_multiTasksParalByparent();

        }

        private void task7多任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask6_UIupdate(textBox_test);
        }

        private void task8io型task返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskBaseExample tbe = new TaskBaseExample();
            tbe.TestTask7_TaskCompletionSource();
        }

        private void activeMQToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            ActiveMQ_TOPIC mQ = new ActiveMQ_TOPIC();
            mQ.Show();
        }

        private void activeMQQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMQ_QUEUE mQ_QUEUE = new ActiveMQ_QUEUE();
            mQ_QUEUE.Show();

        }

        private void fluentSchedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchedulerHelloExample.Hello();
            SchedulerHelloExample.AddJob();
            SchedulerHelloExample.AddOnceJob();
            SchedulerHelloExample.AddOnceJobAt();
        }

        private void iNI配置文件读写ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(INIHelper.getInstance().Get("test.ini", "test_key1", "test_value1"));
            Console.WriteLine(INIHelper.getInstance().Get("test.ini", "test_key2", "test_value2"));
            Console.WriteLine(INIHelper.getInstance().Get("test.ini", "test_key3", "test_value3"));
            Console.WriteLine(INIHelper.getInstance().Set("test.ini", "test_key4", "test_value4"));
            Console.WriteLine(INIHelper.getInstance().Set("test.ini", "test_key4", "test_value5"));
        }

        private void gDIRefreshAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UITest.GDITimerRefresh gdiTimer = new UITest.GDITimerRefresh();
            gdiTimer.Show();
        }

        private void 进程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessForm pf = new ProcessForm();
            pf.Show();
        }

        private void gridviewdatabindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datagridviewBindMethod dbl = new datagridviewBindMethod();
            dbl.Show();
        }

        private void 日历ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CalenderWeek cweek = new CalenderWeek();
            panel1.Controls.Add(cweek);
        }

        private void 子窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void gridviewcustomComboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_datagridview3 f = new Form_datagridview3();
            f.Show();
        }

        private void propertiesGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridTest t = new PropertyGridTest();
            t.Show();
        }


        private void 记录RecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //C# 10才支持
        }

        private void 特性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarketRiskUI.LittleExamples.UseDefaultAttribute.Demo();
        }
    }
}