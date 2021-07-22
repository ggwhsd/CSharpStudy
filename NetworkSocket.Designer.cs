namespace MarketRiskUI
{
    partial class NetworkSocket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox_Allcount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbSendC = new System.Windows.Forms.RichTextBox();
            this.lbStateC = new System.Windows.Forms.ListBox();
            this.rtbReceC = new System.Windows.Forms.RichTextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnCClose = new System.Windows.Forms.Button();
            this.btnCSend = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_random = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.rtbSend = new System.Windows.Forms.TextBox();
            this.rtbAccept = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "IPEndPoint";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 244);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 511);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox_start);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.textBox_Allcount);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.lbState);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.textBox_random);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.btnStartListen);
            this.tabPage2.Controls.Add(this.rtbSend);
            this.tabPage2.Controls.Add(this.rtbAccept);
            this.tabPage2.Controls.Add(this.textBoxPort);
            this.tabPage2.Controls.Add(this.textBoxIP);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(630, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "socketTcp";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_start
            // 
            this.textBox_start.Location = new System.Drawing.Point(175, 416);
            this.textBox_start.Name = "textBox_start";
            this.textBox_start.Size = new System.Drawing.Size(62, 21);
            this.textBox_start.TabIndex = 13;
            this.textBox_start.Text = "5500";
            this.textBox_start.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(112, 355);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "压力测试";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // textBox_Allcount
            // 
            this.textBox_Allcount.Location = new System.Drawing.Point(175, 444);
            this.textBox_Allcount.Name = "textBox_Allcount";
            this.textBox_Allcount.Size = new System.Drawing.Size(62, 21);
            this.textBox_Allcount.TabIndex = 13;
            this.textBox_Allcount.Text = "13000";
            this.textBox_Allcount.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbSendC);
            this.groupBox1.Controls.Add(this.lbStateC);
            this.groupBox1.Controls.Add(this.rtbReceC);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.tbIP);
            this.groupBox1.Controls.Add(this.btnCClose);
            this.groupBox1.Controls.Add(this.btnCSend);
            this.groupBox1.Controls.Add(this.btnRequest);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(265, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 348);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "socketClient";
            // 
            // rtbSendC
            // 
            this.rtbSendC.Location = new System.Drawing.Point(221, 45);
            this.rtbSendC.Name = "rtbSendC";
            this.rtbSendC.Size = new System.Drawing.Size(120, 141);
            this.rtbSendC.TabIndex = 4;
            this.rtbSendC.Text = "";
            // 
            // lbStateC
            // 
            this.lbStateC.FormattingEnabled = true;
            this.lbStateC.ItemHeight = 12;
            this.lbStateC.Location = new System.Drawing.Point(65, 201);
            this.lbStateC.Name = "lbStateC";
            this.lbStateC.Size = new System.Drawing.Size(252, 100);
            this.lbStateC.TabIndex = 3;
            // 
            // rtbReceC
            // 
            this.rtbReceC.Location = new System.Drawing.Point(65, 44);
            this.rtbReceC.Name = "rtbReceC";
            this.rtbReceC.Size = new System.Drawing.Size(100, 142);
            this.rtbReceC.TabIndex = 3;
            this.rtbReceC.Text = "";
            this.rtbReceC.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(221, 14);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(37, 21);
            this.tbPort.TabIndex = 2;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(65, 17);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 21);
            this.tbIP.TabIndex = 2;
            // 
            // btnCClose
            // 
            this.btnCClose.Location = new System.Drawing.Point(199, 311);
            this.btnCClose.Name = "btnCClose";
            this.btnCClose.Size = new System.Drawing.Size(75, 23);
            this.btnCClose.TabIndex = 1;
            this.btnCClose.Text = "关闭连接";
            this.btnCClose.UseVisualStyleBackColor = true;
            this.btnCClose.Click += new System.EventHandler(this.btnCClose_Click);
            // 
            // btnCSend
            // 
            this.btnCSend.Location = new System.Drawing.Point(118, 311);
            this.btnCSend.Name = "btnCSend";
            this.btnCSend.Size = new System.Drawing.Size(75, 23);
            this.btnCSend.TabIndex = 1;
            this.btnCSend.Text = "发送信息";
            this.btnCSend.UseVisualStyleBackColor = true;
            this.btnCSend.Click += new System.EventHandler(this.btnCSend_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(37, 311);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "请求连接";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "程序状态";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "接收状态";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "发送信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "请求端口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "服务器ip";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(114, 447);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "结束行号";
            // 
            // lbState
            // 
            this.lbState.FormattingEnabled = true;
            this.lbState.ItemHeight = 12;
            this.lbState.Location = new System.Drawing.Point(112, 208);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(120, 112);
            this.lbState.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(114, 419);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "开始行数";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(10, 312);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止监听";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 393);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "随机间隔";
            // 
            // textBox_random
            // 
            this.textBox_random.Location = new System.Drawing.Point(175, 390);
            this.textBox_random.Name = "textBox_random";
            this.textBox_random.Size = new System.Drawing.Size(57, 21);
            this.textBox_random.TabIndex = 11;
            this.textBox_random.Text = "1,1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(112, 326);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "发送信息方式2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnSendraw_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(10, 283);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送信息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(10, 254);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(75, 23);
            this.btnStartListen.TabIndex = 2;
            this.btnStartListen.Text = "开始监听";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.button9_Click);
            // 
            // rtbSend
            // 
            this.rtbSend.Location = new System.Drawing.Point(67, 142);
            this.rtbSend.Multiline = true;
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(100, 51);
            this.rtbSend.TabIndex = 1;
            // 
            // rtbAccept
            // 
            this.rtbAccept.Location = new System.Drawing.Point(67, 88);
            this.rtbAccept.Multiline = true;
            this.rtbAccept.Name = "rtbAccept";
            this.rtbAccept.Size = new System.Drawing.Size(100, 38);
            this.rtbAccept.TabIndex = 1;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(67, 52);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "28888";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(67, 11);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "发送信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务器状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "接收信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "监听端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器ip";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 166);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(619, 68);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "说明信息";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 55);
            this.button4.TabIndex = 6;
            this.button4.Text = "udpClient";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(119, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 55);
            this.button5.TabIndex = 7;
            this.button5.Text = "udpServer";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 29);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 60);
            this.button6.TabIndex = 8;
            this.button6.Text = "IPAddress获取所有网卡信息";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 16);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ascii";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(101, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 16);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "unicode";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(273, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收发编码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(180, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "UDP";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 915);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Name = "Form2";
            this.Text = "网络测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.TextBox rtbSend;
        private System.Windows.Forms.TextBox rtbAccept;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox lbState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbSendC;
        private System.Windows.Forms.RichTextBox rtbReceC;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnCClose;
        private System.Windows.Forms.Button btnCSend;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbStateC;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_random;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Allcount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_start;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}