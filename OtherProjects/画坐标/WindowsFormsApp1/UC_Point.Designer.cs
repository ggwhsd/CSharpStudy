namespace WindowsFormsApp1
{
    partial class UC_Point
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPointY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPointX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPointY
            // 
            this.txtPointY.Location = new System.Drawing.Point(137, 3);
            this.txtPointY.Name = "txtPointY";
            this.txtPointY.Size = new System.Drawing.Size(29, 21);
            this.txtPointY.TabIndex = 13;
            this.txtPointY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPointY_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "y：";
            // 
            // txtPointX
            // 
            this.txtPointX.Location = new System.Drawing.Point(83, 3);
            this.txtPointX.Name = "txtPointX";
            this.txtPointX.Size = new System.Drawing.Size(29, 21);
            this.txtPointX.TabIndex = 11;
            this.txtPointX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPointX_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "点坐标   x：";
            // 
            // UC_Point
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPointY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPointX);
            this.Controls.Add(this.label1);
            this.Name = "UC_Point";
            this.Size = new System.Drawing.Size(175, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPointY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPointX;
        private System.Windows.Forms.Label label1;
    }
}
