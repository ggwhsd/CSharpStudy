namespace VLCDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vlcControl2 = new Vlc.DotNet.Forms.VlcControl();
            this.button2 = new System.Windows.Forms.Button();
            this.vlcControl3 = new Vlc.DotNet.Forms.VlcControl();
            this.button3 = new System.Windows.Forms.Button();
            this.vlcControl4 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl5 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl6 = new Vlc.DotNet.Forms.VlcControl();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.vlcControl7 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl8 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl9 = new Vlc.DotNet.Forms.VlcControl();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(13, 55);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(299, 210);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Tag = "0";
            this.button1.Text = "播放";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vlcControl2
            // 
            this.vlcControl2.BackColor = System.Drawing.Color.Black;
            this.vlcControl2.Location = new System.Drawing.Point(329, 55);
            this.vlcControl2.Name = "vlcControl2";
            this.vlcControl2.Size = new System.Drawing.Size(299, 210);
            this.vlcControl2.Spu = -1;
            this.vlcControl2.TabIndex = 0;
            this.vlcControl2.Text = "vlcControl1";
            this.vlcControl2.VlcLibDirectory = null;
            this.vlcControl2.VlcMediaplayerOptions = null;
            this.vlcControl2.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Tag = "1";
            this.button2.Text = "播放";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // vlcControl3
            // 
            this.vlcControl3.BackColor = System.Drawing.Color.Black;
            this.vlcControl3.Location = new System.Drawing.Point(645, 55);
            this.vlcControl3.Name = "vlcControl3";
            this.vlcControl3.Size = new System.Drawing.Size(299, 210);
            this.vlcControl3.Spu = -1;
            this.vlcControl3.TabIndex = 0;
            this.vlcControl3.Text = "vlcControl1";
            this.vlcControl3.VlcLibDirectory = null;
            this.vlcControl3.VlcMediaplayerOptions = null;
            this.vlcControl3.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(645, 271);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Tag = "2";
            this.button3.Text = "播放";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // vlcControl4
            // 
            this.vlcControl4.BackColor = System.Drawing.Color.Black;
            this.vlcControl4.Location = new System.Drawing.Point(13, 300);
            this.vlcControl4.Name = "vlcControl4";
            this.vlcControl4.Size = new System.Drawing.Size(299, 210);
            this.vlcControl4.Spu = -1;
            this.vlcControl4.TabIndex = 0;
            this.vlcControl4.Text = "vlcControl1";
            this.vlcControl4.VlcLibDirectory = null;
            this.vlcControl4.VlcMediaplayerOptions = null;
            this.vlcControl4.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // vlcControl5
            // 
            this.vlcControl5.BackColor = System.Drawing.Color.Black;
            this.vlcControl5.Location = new System.Drawing.Point(329, 300);
            this.vlcControl5.Name = "vlcControl5";
            this.vlcControl5.Size = new System.Drawing.Size(299, 210);
            this.vlcControl5.Spu = -1;
            this.vlcControl5.TabIndex = 0;
            this.vlcControl5.Text = "vlcControl1";
            this.vlcControl5.VlcLibDirectory = null;
            this.vlcControl5.VlcMediaplayerOptions = null;
            this.vlcControl5.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // vlcControl6
            // 
            this.vlcControl6.BackColor = System.Drawing.Color.Black;
            this.vlcControl6.Location = new System.Drawing.Point(645, 300);
            this.vlcControl6.Name = "vlcControl6";
            this.vlcControl6.Size = new System.Drawing.Size(299, 210);
            this.vlcControl6.Spu = -1;
            this.vlcControl6.TabIndex = 0;
            this.vlcControl6.Text = "vlcControl1";
            this.vlcControl6.VlcLibDirectory = null;
            this.vlcControl6.VlcMediaplayerOptions = null;
            this.vlcControl6.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 516);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Tag = "3";
            this.button4.Text = "播放";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(329, 516);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Tag = "4";
            this.button5.Text = "播放";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(645, 516);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Tag = "5";
            this.button6.Text = "播放";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // vlcControl7
            // 
            this.vlcControl7.BackColor = System.Drawing.Color.Black;
            this.vlcControl7.Location = new System.Drawing.Point(13, 545);
            this.vlcControl7.Name = "vlcControl7";
            this.vlcControl7.Size = new System.Drawing.Size(299, 210);
            this.vlcControl7.Spu = -1;
            this.vlcControl7.TabIndex = 0;
            this.vlcControl7.Text = "vlcControl1";
            this.vlcControl7.VlcLibDirectory = null;
            this.vlcControl7.VlcMediaplayerOptions = null;
            this.vlcControl7.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // vlcControl8
            // 
            this.vlcControl8.BackColor = System.Drawing.Color.Black;
            this.vlcControl8.Location = new System.Drawing.Point(329, 545);
            this.vlcControl8.Name = "vlcControl8";
            this.vlcControl8.Size = new System.Drawing.Size(299, 210);
            this.vlcControl8.Spu = -1;
            this.vlcControl8.TabIndex = 0;
            this.vlcControl8.Text = "vlcControl1";
            this.vlcControl8.VlcLibDirectory = null;
            this.vlcControl8.VlcMediaplayerOptions = null;
            this.vlcControl8.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // vlcControl9
            // 
            this.vlcControl9.BackColor = System.Drawing.Color.Black;
            this.vlcControl9.Location = new System.Drawing.Point(645, 545);
            this.vlcControl9.Name = "vlcControl9";
            this.vlcControl9.Size = new System.Drawing.Size(299, 210);
            this.vlcControl9.Spu = -1;
            this.vlcControl9.TabIndex = 0;
            this.vlcControl9.Text = "vlcControl1";
            this.vlcControl9.VlcLibDirectory = null;
            this.vlcControl9.VlcMediaplayerOptions = null;
            this.vlcControl9.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(13, 761);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 1;
            this.button7.Tag = "6";
            this.button7.Text = "播放";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(329, 761);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 1;
            this.button8.Tag = "7";
            this.button8.Text = "播放";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(645, 761);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 1;
            this.button9.Tag = "8";
            this.button9.Text = "播放";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(738, 761);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 21);
            this.textBox1.TabIndex = 2;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(151, 15);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "停止";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "视频序号";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(83, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown1.TabIndex = 6;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(237, 15);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 7;
            this.button11.Text = "放大";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(318, 15);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 7;
            this.button12.Text = "缩小";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 764);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vlcControl9);
            this.Controls.Add(this.vlcControl6);
            this.Controls.Add(this.vlcControl3);
            this.Controls.Add(this.vlcControl8);
            this.Controls.Add(this.vlcControl5);
            this.Controls.Add(this.vlcControl2);
            this.Controls.Add(this.vlcControl7);
            this.Controls.Add(this.vlcControl4);
            this.Controls.Add(this.vlcControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Vlc.DotNet.Forms.VlcControl vlcControl2;
        private System.Windows.Forms.Button button2;
        private Vlc.DotNet.Forms.VlcControl vlcControl3;
        private System.Windows.Forms.Button button3;
        private Vlc.DotNet.Forms.VlcControl vlcControl4;
        private Vlc.DotNet.Forms.VlcControl vlcControl5;
        private Vlc.DotNet.Forms.VlcControl vlcControl6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private Vlc.DotNet.Forms.VlcControl vlcControl7;
        private Vlc.DotNet.Forms.VlcControl vlcControl8;
        private Vlc.DotNet.Forms.VlcControl vlcControl9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}

