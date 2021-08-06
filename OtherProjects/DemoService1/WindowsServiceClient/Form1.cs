using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;

namespace WindowsServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listView1.ListViewItemSorter = new Common.ListViewColumnSorter();
            this.listView1.ColumnClick += new ColumnClickEventHandler(Common.ListViewHelper.ListView_ColumnClick);

        }

        string serviceFilePath = $"{Application.StartupPath}\\DemoService1.exe";
        string serviceName = "MyService";

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.UninstallService(serviceName);
            this.InstallService(serviceFilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.ServiceStart(serviceName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.ServiceStop(serviceName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                this.ServiceStop(serviceName);
                this.UninstallService(serviceFilePath);
            }
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //安装服务
        private void InstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        private void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }

        //启动服务
        private void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                }
            }
        }

        //停止服务
        private void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Ascending;
            
            listView1.Columns.Add("服务名称", 100);
            listView1.Columns.Add("服务后台名", 200);
            listView1.Columns.Add("状态", 50);

            ServiceController[] services = ServiceController.GetServices();
            listView1.BeginUpdate();
            foreach (ServiceController sc in services)
            {
               
                ListViewItem li = new ListViewItem(sc.DisplayName);
                
                li.SubItems.Add(sc.ServiceName);
                li.SubItems.Add(sc.Status.ToString());

                listView1.Items.Add(li);
                
            }
            listView1.EndUpdate();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            foreach(ListViewItem item in listView1.Items)
            {
                Console.WriteLine(item.Text);
            }
        }
    }
}
