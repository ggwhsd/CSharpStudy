

using UItest;

namespace UITest
{
    partial class GDITimerRefresh
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.画图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动画图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox画图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存界面图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入图片到pictureBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用图片填充某块区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制圆角矩形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.文本框重绘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.画很多圈圈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userControl11 = new UserControlTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.画图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 画图ToolStripMenuItem
            // 
            this.画图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动画图ToolStripMenuItem,
            this.pictureBox画图ToolStripMenuItem,
            this.保存界面图像ToolStripMenuItem,
            this.导入图片到pictureBoxToolStripMenuItem,
            this.用图片填充某块区域ToolStripMenuItem,
            this.截屏ToolStripMenuItem,
            this.绘制圆角矩形ToolStripMenuItem,
            this.文本框重绘ToolStripMenuItem,
            this.画很多圈圈ToolStripMenuItem});
            this.画图ToolStripMenuItem.Name = "画图ToolStripMenuItem";
            this.画图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.画图ToolStripMenuItem.Text = "画图";
            // 
            // 自动画图ToolStripMenuItem
            // 
            this.自动画图ToolStripMenuItem.Name = "自动画图ToolStripMenuItem";
            this.自动画图ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.自动画图ToolStripMenuItem.Text = "自动界面画图";
            this.自动画图ToolStripMenuItem.Click += new System.EventHandler(this.自动画图ToolStripMenuItem_Click);
            // 
            // pictureBox画图ToolStripMenuItem
            // 
            this.pictureBox画图ToolStripMenuItem.Name = "pictureBox画图ToolStripMenuItem";
            this.pictureBox画图ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pictureBox画图ToolStripMenuItem.Text = "pictureBox画图";
            this.pictureBox画图ToolStripMenuItem.Click += new System.EventHandler(this.pictureBox画图ToolStripMenuItem_Click);
            // 
            // 保存界面图像ToolStripMenuItem
            // 
            this.保存界面图像ToolStripMenuItem.Name = "保存界面图像ToolStripMenuItem";
            this.保存界面图像ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.保存界面图像ToolStripMenuItem.Text = "保存界面图像";
            this.保存界面图像ToolStripMenuItem.Click += new System.EventHandler(this.保存界面图像ToolStripMenuItem_Click);
            // 
            // 导入图片到pictureBoxToolStripMenuItem
            // 
            this.导入图片到pictureBoxToolStripMenuItem.Name = "导入图片到pictureBoxToolStripMenuItem";
            this.导入图片到pictureBoxToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.导入图片到pictureBoxToolStripMenuItem.Text = "导入图片到pictureBox";
            this.导入图片到pictureBoxToolStripMenuItem.Click += new System.EventHandler(this.导入图片到pictureBoxToolStripMenuItem_Click);
            // 
            // 用图片填充某块区域ToolStripMenuItem
            // 
            this.用图片填充某块区域ToolStripMenuItem.Name = "用图片填充某块区域ToolStripMenuItem";
            this.用图片填充某块区域ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.用图片填充某块区域ToolStripMenuItem.Text = "用图片填充某块区域";
            this.用图片填充某块区域ToolStripMenuItem.Click += new System.EventHandler(this.用图片填充某块区域ToolStripMenuItem_Click);
            // 
            // 截屏ToolStripMenuItem
            // 
            this.截屏ToolStripMenuItem.Name = "截屏ToolStripMenuItem";
            this.截屏ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.截屏ToolStripMenuItem.Text = "类似截屏";
            this.截屏ToolStripMenuItem.Click += new System.EventHandler(this.截屏ToolStripMenuItem_Click);
            // 
            // 绘制圆角矩形ToolStripMenuItem
            // 
            this.绘制圆角矩形ToolStripMenuItem.Name = "绘制圆角矩形ToolStripMenuItem";
            this.绘制圆角矩形ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.绘制圆角矩形ToolStripMenuItem.Text = "绘制圆角矩形";
            this.绘制圆角矩形ToolStripMenuItem.Click += new System.EventHandler(this.绘制圆角矩形ToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(798, 320);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(536, 421);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // 文本框重绘ToolStripMenuItem
            // 
            this.文本框重绘ToolStripMenuItem.Name = "文本框重绘ToolStripMenuItem";
            this.文本框重绘ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.文本框重绘ToolStripMenuItem.Text = "文本框重绘";
            this.文本框重绘ToolStripMenuItem.Click += new System.EventHandler(this.文本框重绘ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(692, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(798, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 258);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // 画很多圈圈ToolStripMenuItem
            // 
            this.画很多圈圈ToolStripMenuItem.Name = "画很多圈圈ToolStripMenuItem";
            this.画很多圈圈ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.画很多圈圈ToolStripMenuItem.Text = "画很多圈圈";
            this.画很多圈圈ToolStripMenuItem.Click += new System.EventHandler(this.画很多圈圈ToolStripMenuItem_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(466, 58);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(133, 119);
            this.userControl11.TabIndex = 4;
            // 
            // GDITimerRefresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GDITimerRefresh";
            this.Text = "GDITimerRefresh";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GDITimerRefresh_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 画图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动画图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureBox画图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存界面图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入图片到pictureBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用图片填充某块区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截屏ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 绘制圆角矩形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文本框重绘ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private UserControlTextBox userControl11;
        private System.Windows.Forms.ToolStripMenuItem 画很多圈圈ToolStripMenuItem;
    }
}