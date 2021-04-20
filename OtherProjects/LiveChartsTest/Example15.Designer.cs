namespace LiveChartsTest
{
    partial class Example15
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(800, 450);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.ChartOnDataClick);
            this.cartesianChart1.DataHover += new LiveCharts.Events.DataHoverHandler(this.Chart_OnDataHover);
            this.cartesianChart1.UpdaterTick += new LiveCharts.Events.UpdaterTickHandler(this.ChartOnUpdaterTick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(483, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(305, 394);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 61);
            this.button1.TabIndex = 2;
            this.button1.Text = "add a new node";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 88);
            this.button2.TabIndex = 3;
            this.button2.Text = "change axis";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(401, 196);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 58);
            this.button3.TabIndex = 4;
            this.button3.Text = "modify 2th value";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Example15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "Example15";
            this.Text = "Example15";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}