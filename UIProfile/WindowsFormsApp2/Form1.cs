using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (System.IO.File.Exists("profile.cfg"))
            {
                foreach (string s in System.IO.File.ReadLines(@"profile.cfg"))
                {
                    if (string.IsNullOrEmpty(s) == true)
                    { }
                    else
                    {
                        
                        string[] numbers = s.Replace("\r\n", "").Split('|');
                        string name = numbers[0];
                        Point windowPoint = new Point(int.Parse(numbers[1]),
                                    int.Parse(numbers[2]));
                        Size windowSize = new Size(int.Parse(numbers[3]), int.Parse(numbers[4]));

                        if (name == "ShowForm1")
                        {
                            ColorConverter cc = (new ColorConverter());
                            ShowForm1 sf = new ShowForm1();
                            sf.BackColor = (Color)cc.ConvertFromString(numbers[6]);
                            sf.Show();
                            sf.Size = windowSize;
                            sf.Location = windowPoint;
                            

                        }
                        else if (name == "Form1")
                        {
                            this.Location = windowPoint;
                            this.Size = windowSize;
                        }
                        else if (name == "ShowFome2")
                        {
                            ShowFome2 sf = new ShowFome2();
                            sf.Show();
                            sf.Size = windowSize;
                            sf.Location = windowPoint;
                            
                        }
                        
                        {


                            string windowString = numbers[4];
                            if (windowString == "Normal")
                            {
                                 
                                //this.StartPosition = FormStartPosition.Manual;
                                
                            }
                            else if (windowString == "Maximized")
                            {
                                //this.Location = new Point(100, 100);
                                //this.StartPosition = FormStartPosition.Manual;
                                //this.WindowState = FormWindowState.Maximized;
                            }
                        }
                    }
                }


            }
            else
            {
                this.StartPosition =  FormStartPosition.CenterScreen;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void GeometryToString(Form mainForm)
        {
            string str = "";
            if (mainForm.Name == "ShowForm1")
            {
                str = mainForm.Name + "|" + mainForm.Location.X.ToString() + "|" +
                    mainForm.Location.Y.ToString() + "|" +
                    mainForm.Size.Width.ToString() + "|" +
                    mainForm.Size.Height.ToString() + "|" +
                    mainForm.WindowState.ToString() + "|" +
                    mainForm.BackColor.Name;
            }
            else {
                str = mainForm.Name + "|" + mainForm.Location.X.ToString() + "|" +
                    mainForm.Location.Y.ToString() + "|" +
                    mainForm.Size.Width.ToString() + "|" +
                    mainForm.Size.Height.ToString() + "|" +
                    mainForm.WindowState.ToString();
            }

            using (StreamWriter sw = new StreamWriter("profile.cfg", true, Encoding.Default))
            {
                
                sw.WriteLine(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mainForm = this;
            string str = "相对屏幕: " + mainForm.Location.X.ToString() + "|" +
               mainForm.Location.Y.ToString() + "|" +
               mainForm.Size.Width.ToString() + "|" +
               mainForm.Size.Height.ToString() + "|" +
               mainForm.WindowState.ToString();
            textBox1.Text += str;
            textBox1.Text += "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string str = "相对窗口工作区："+btn.Location.X.ToString() + "|" + btn.Location.Y.ToString() + "|" +
                btn.Size.Width.ToString() + "|" + btn.Size.Height.ToString();
            textBox1.Text += str;
            textBox1.Text += "\r\n";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //相对按钮的参考
            string str = btn.PointToScreen(btn.Location).ToString();
            textBox1.Text += str;
            textBox1.Text += "\r\n";
            //相对窗口的参考，这个才是我们需要的
            str = this.PointToScreen(btn.Location).ToString();
            textBox1.Text += "相对屏幕:"+str;
            textBox1.Text += "\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GeometryToString(this);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowForm1 sf = new ShowForm1()
                ;
            sf.Show();
            ShowFome2 sf2 = new ShowFome2();
            sf2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCollection collection = Application.OpenForms;
            if (File.Exists("profile.cfg"))
            {
                File.Delete("profile.cfg");
            }
            foreach (Form form in collection)
            {
                
                textBox1.Text += $"{form.Text},{form.Name},{form.GetType().Name},{form.ParentForm},{form.OwnedForms},{form.DesktopLocation},{form.Location}";
                textBox1.Text += "\r\n";
                GeometryToString(form);
            }
        }
    }
}
