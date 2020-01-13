namespace MarketRiskUI
{
    partial class SoundMediaTools
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadAsyncButton = new System.Windows.Forms.Button();
            this.loadSyncButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.playLoopAsyncButton = new System.Windows.Forms.Button();
            this.playOnceAsyncButton = new System.Windows.Forms.Button();
            this.filepathTextbox = new System.Windows.Forms.TextBox();
            this.playOnceSyncButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(47, 17);
            this.statusBar.Text = "Ready.";
            // 
            // loadAsyncButton
            // 
            this.loadAsyncButton.Location = new System.Drawing.Point(51, 314);
            this.loadAsyncButton.Name = "loadAsyncButton";
            this.loadAsyncButton.Size = new System.Drawing.Size(75, 23);
            this.loadAsyncButton.TabIndex = 14;
            this.loadAsyncButton.Text = "loadAsyncButton";
            this.loadAsyncButton.UseVisualStyleBackColor = true;
            this.loadAsyncButton.Click += new System.EventHandler(this.loadAsyncButton_Click);
            // 
            // loadSyncButton
            // 
            this.loadSyncButton.Location = new System.Drawing.Point(51, 285);
            this.loadSyncButton.Name = "loadSyncButton";
            this.loadSyncButton.Size = new System.Drawing.Size(75, 23);
            this.loadSyncButton.TabIndex = 15;
            this.loadSyncButton.Text = "loadSyncButton";
            this.loadSyncButton.UseVisualStyleBackColor = true;
            this.loadSyncButton.Click += new System.EventHandler(this.loadSyncButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(51, 247);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "stopButton";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(27, 173);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(161, 23);
            this.selectFileButton.TabIndex = 13;
            this.selectFileButton.Text = "selectFileButton";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // playLoopAsyncButton
            // 
            this.playLoopAsyncButton.Location = new System.Drawing.Point(27, 142);
            this.playLoopAsyncButton.Name = "playLoopAsyncButton";
            this.playLoopAsyncButton.Size = new System.Drawing.Size(161, 23);
            this.playLoopAsyncButton.TabIndex = 12;
            this.playLoopAsyncButton.Text = "playLoopAsyncButton";
            this.playLoopAsyncButton.UseVisualStyleBackColor = true;
            this.playLoopAsyncButton.Click += new System.EventHandler(this.playLoopAsyncButton_Click);
            // 
            // playOnceAsyncButton
            // 
            this.playOnceAsyncButton.Location = new System.Drawing.Point(27, 110);
            this.playOnceAsyncButton.Name = "playOnceAsyncButton";
            this.playOnceAsyncButton.Size = new System.Drawing.Size(161, 23);
            this.playOnceAsyncButton.TabIndex = 11;
            this.playOnceAsyncButton.Text = "playOnceAsyncButton";
            this.playOnceAsyncButton.UseVisualStyleBackColor = true;
            this.playOnceAsyncButton.Click += new System.EventHandler(this.playOnceAsyncButton_Click);
            // 
            // filepathTextbox
            // 
            this.filepathTextbox.Location = new System.Drawing.Point(218, 77);
            this.filepathTextbox.Multiline = true;
            this.filepathTextbox.Name = "filepathTextbox";
            this.filepathTextbox.Size = new System.Drawing.Size(490, 88);
            this.filepathTextbox.TabIndex = 10;
            this.filepathTextbox.Text = "ddd";
            this.filepathTextbox.TextChanged += new System.EventHandler(this.filepathTextbox_TextChanged);
            // 
            // playOnceSyncButton
            // 
            this.playOnceSyncButton.Location = new System.Drawing.Point(29, 77);
            this.playOnceSyncButton.Name = "playOnceSyncButton";
            this.playOnceSyncButton.Size = new System.Drawing.Size(159, 23);
            this.playOnceSyncButton.TabIndex = 9;
            this.playOnceSyncButton.Text = "playOnceSyncButton";
            this.playOnceSyncButton.UseVisualStyleBackColor = true;
            this.playOnceSyncButton.Click += new System.EventHandler(this.playOnceSyncButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Beep";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SoundMediaTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.loadAsyncButton);
            this.Controls.Add(this.loadSyncButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.playLoopAsyncButton);
            this.Controls.Add(this.playOnceAsyncButton);
            this.Controls.Add(this.filepathTextbox);
            this.Controls.Add(this.playOnceSyncButton);
            this.Controls.Add(this.button1);
            this.Name = "SoundMediaTools";
            this.Text = "SoundMediaTools";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private System.Windows.Forms.Button loadAsyncButton;
        private System.Windows.Forms.Button loadSyncButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button playLoopAsyncButton;
        private System.Windows.Forms.Button playOnceAsyncButton;
        private System.Windows.Forms.TextBox filepathTextbox;
        private System.Windows.Forms.Button playOnceSyncButton;
        private System.Windows.Forms.Button button1;
    }
}