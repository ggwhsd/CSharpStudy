namespace MarketRiskUI.LittleExamples
{
    partial class PrimeFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Number = new System.Windows.Forms.TextBox();
            this.txtBox_results = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "正整数范围";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "素数结果";
            // 
            // textBox_Number
            // 
            this.textBox_Number.Location = new System.Drawing.Point(143, 24);
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.Size = new System.Drawing.Size(100, 21);
            this.textBox_Number.TabIndex = 2;
            this.textBox_Number.TextChanged += new System.EventHandler(this.textBox_Number_TextChanged);
            // 
            // txtBox_results
            // 
            this.txtBox_results.Location = new System.Drawing.Point(143, 59);
            this.txtBox_results.Multiline = true;
            this.txtBox_results.Name = "txtBox_results";
            this.txtBox_results.Size = new System.Drawing.Size(628, 208);
            this.txtBox_results.TabIndex = 2;
            // 
            // PrimeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 288);
            this.Controls.Add(this.txtBox_results);
            this.Controls.Add(this.textBox_Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PrimeFilter";
            this.Text = "PrimeFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Number;
        private System.Windows.Forms.TextBox txtBox_results;
    }
}