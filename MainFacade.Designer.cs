﻿namespace MarketRiskUI
{
    partial class MainFacade
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.littleExamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏幕保护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常用工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.littleExamplesToolStripMenuItem,
            this.formsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // littleExamplesToolStripMenuItem
            // 
            this.littleExamplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.屏幕保护ToolStripMenuItem});
            this.littleExamplesToolStripMenuItem.Name = "littleExamplesToolStripMenuItem";
            this.littleExamplesToolStripMenuItem.Size = new System.Drawing.Size(99, 21);
            this.littleExamplesToolStripMenuItem.Text = "littleExamples";
            // 
            // 屏幕保护ToolStripMenuItem
            // 
            this.屏幕保护ToolStripMenuItem.Name = "屏幕保护ToolStripMenuItem";
            this.屏幕保护ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.屏幕保护ToolStripMenuItem.Text = "屏幕保护";
            this.屏幕保护ToolStripMenuItem.Click += new System.EventHandler(this.屏幕保护ToolStripMenuItem_Click);
            // 
            // formsToolStripMenuItem
            // 
            this.formsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.form1ToolStripMenuItem,
            this.gDIToolStripMenuItem,
            this.jsonFormToolStripMenuItem,
            this.常用工具ToolStripMenuItem});
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.formsToolStripMenuItem.Text = "Forms";
            // 
            // form1ToolStripMenuItem
            // 
            this.form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            this.form1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.form1ToolStripMenuItem.Text = "历史主窗口";
            this.form1ToolStripMenuItem.Click += new System.EventHandler(this.form1ToolStripMenuItem_Click);
            // 
            // gDIToolStripMenuItem
            // 
            this.gDIToolStripMenuItem.Name = "gDIToolStripMenuItem";
            this.gDIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gDIToolStripMenuItem.Text = "GDI";
            // 
            // jsonFormToolStripMenuItem
            // 
            this.jsonFormToolStripMenuItem.Name = "jsonFormToolStripMenuItem";
            this.jsonFormToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jsonFormToolStripMenuItem.Text = "json";
            // 
            // 常用工具ToolStripMenuItem
            // 
            this.常用工具ToolStripMenuItem.Name = "常用工具ToolStripMenuItem";
            this.常用工具ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.常用工具ToolStripMenuItem.Text = "常用工具";
            // 
            // MainFacade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFacade";
            this.Text = "MainFacade";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem littleExamplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 屏幕保护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常用工具ToolStripMenuItem;
    }
}