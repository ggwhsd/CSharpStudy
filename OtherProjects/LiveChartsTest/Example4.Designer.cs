namespace LiveChartsTest
{
    partial class Example4
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
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge2 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge3 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge4 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge5 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge6 = new LiveCharts.WinForms.SolidGauge();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // solidGauge1
            // 
            this.solidGauge1.Location = new System.Drawing.Point(65, 12);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Size = new System.Drawing.Size(513, 389);
            this.solidGauge1.TabIndex = 0;
            this.solidGauge1.Text = "solidGauge1";
            // 
            // solidGauge2
            // 
            this.solidGauge2.Location = new System.Drawing.Point(118, 407);
            this.solidGauge2.Name = "solidGauge2";
            this.solidGauge2.Size = new System.Drawing.Size(200, 100);
            this.solidGauge2.TabIndex = 1;
            this.solidGauge2.Text = "solidGauge2";
            // 
            // solidGauge3
            // 
            this.solidGauge3.Location = new System.Drawing.Point(460, 407);
            this.solidGauge3.Name = "solidGauge3";
            this.solidGauge3.Size = new System.Drawing.Size(200, 100);
            this.solidGauge3.TabIndex = 1;
            this.solidGauge3.Text = "solidGauge2";
            // 
            // solidGauge4
            // 
            this.solidGauge4.Location = new System.Drawing.Point(809, 416);
            this.solidGauge4.Name = "solidGauge4";
            this.solidGauge4.Size = new System.Drawing.Size(200, 100);
            this.solidGauge4.TabIndex = 1;
            this.solidGauge4.Text = "solidGauge2";
            // 
            // solidGauge5
            // 
            this.solidGauge5.Location = new System.Drawing.Point(1175, 416);
            this.solidGauge5.Name = "solidGauge5";
            this.solidGauge5.Size = new System.Drawing.Size(200, 100);
            this.solidGauge5.TabIndex = 1;
            this.solidGauge5.Text = "solidGauge2";
            // 
            // solidGauge6
            // 
            this.solidGauge6.Location = new System.Drawing.Point(1117, 652);
            this.solidGauge6.Name = "solidGauge6";
            this.solidGauge6.Size = new System.Drawing.Size(200, 100);
            this.solidGauge6.TabIndex = 1;
            this.solidGauge6.Text = "solidGauge2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Example4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 821);
            this.Controls.Add(this.solidGauge6);
            this.Controls.Add(this.solidGauge5);
            this.Controls.Add(this.solidGauge4);
            this.Controls.Add(this.solidGauge3);
            this.Controls.Add(this.solidGauge2);
            this.Controls.Add(this.solidGauge1);
            this.Name = "Example4";
            this.Text = "仪表";
            this.Load += new System.EventHandler(this.Example4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private LiveCharts.WinForms.SolidGauge solidGauge2;
        private LiveCharts.WinForms.SolidGauge solidGauge3;
        private LiveCharts.WinForms.SolidGauge solidGauge4;
        private LiveCharts.WinForms.SolidGauge solidGauge5;
        private LiveCharts.WinForms.SolidGauge solidGauge6;
        private System.Windows.Forms.Timer timer1;
    }
}