using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class ProcessForm : Form
    {
        public ProcessForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string appName = "NetworkTools.exe";
            ProcessStartInfo process = new ProcessStartInfo();
            process.FileName = appName;
            process.Arguments = "process";
            process.UseShellExecute = false;
            process.CreateNoWindow = true;
            process.RedirectStandardOutput = true;
            Process ps1 = Process.Start(process);
            // string Result = p.StandardOutput.ReadToEnd();
            // Console.WriteLine("the console app output is {0}", Result);
            //ps1.WaitForExit(); //等待该进程执行结束，才会继续后续操作。
            Process ps2 = Process.Start(process);
            DateTime start = DateTime.Now;
            int i = 10;
            while (i>0)
            {
                i--;
                await Task.Delay(1000);
                TimeSpan end = DateTime.Now - start;
                richTextBox1.Text += $"ps1 id:{ps1.Id},name:{ps1.ProcessName},path:{ps1.MainModule.FileName},mem:{ps1.PrivateMemorySize64} {ps1.VirtualMemorySize64}, cpu:{ps1.TotalProcessorTime.TotalMilliseconds/ end.TotalMilliseconds}\r\n";
                richTextBox1.Text += $"ps2 id:{ps2.Id},name:{ps2.ProcessName},path:{ps2.MainModule.FileName},mem:{ps2.PrivateMemorySize64} {ps2.VirtualMemorySize64},cpu:{ps2.TotalProcessorTime.TotalMilliseconds/ end.TotalMilliseconds}\r\n";
            }
            ps1.Kill();
            ps2.Kill();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += $"cpu个数：{Environment.ProcessorCount}";
            //获得物理内存
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["TotalPhysicalMemory"] != null)
                {
                    long mem = long.Parse(mo["TotalPhysicalMemory"].ToString());
                    richTextBox1.Text += $"物理内存：{mem}\r\n";
                }
            }

            ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject mo in mos.GetInstances())
            {
                if (mo["FreePhysicalMemory"] != null)
                {
                    long availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                    richTextBox1.Text += $"可用内存：{availablebytes}\r\n";
                }
            }

            Process[] processes = Process.GetProcesses();
            richTextBox1.Text += $"进程信息，pid\t name\t ";
            foreach (Process process in processes)
            {
                richTextBox1.Text += $"{process.Id}\t {process.ProcessName}\t \r\n";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Process process = Process.GetProcessById(pid);
            //process.Kill();
        }
    }
}
