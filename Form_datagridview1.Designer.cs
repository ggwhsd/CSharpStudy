namespace MarketRiskUI
{
    partial class Form_datagridview1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addNewRowButton = new System.Windows.Forms.Button();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.songsDataGridView = new System.Windows.Forms.DataGridView();
            this.onlySet = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addNewRowButton
            // 
            this.addNewRowButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addNewRowButton.Location = new System.Drawing.Point(0, 0);
            this.addNewRowButton.Name = "addNewRowButton";
            this.addNewRowButton.Size = new System.Drawing.Size(808, 23);
            this.addNewRowButton.TabIndex = 0;
            this.addNewRowButton.Text = "Add Row";
            this.addNewRowButton.UseVisualStyleBackColor = true;
            this.addNewRowButton.Click += new System.EventHandler(this.addNewRowButton_Click);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteRowButton.Location = new System.Drawing.Point(0, 23);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(808, 23);
            this.deleteRowButton.TabIndex = 1;
            this.deleteRowButton.Text = "Delete Row";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.songsDataGridView);
            this.panel1.Controls.Add(this.deleteRowButton);
            this.panel1.Controls.Add(this.addNewRowButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 439);
            this.panel1.TabIndex = 2;
            // 
            // songsDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.songsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.songsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songsDataGridView.Location = new System.Drawing.Point(0, 46);
            this.songsDataGridView.Name = "songsDataGridView";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.songsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.songsDataGridView.RowTemplate.Height = 23;
            this.songsDataGridView.Size = new System.Drawing.Size(808, 393);
            this.songsDataGridView.TabIndex = 0;
            this.songsDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.songsDataGridView_CellBeginEdit);
            this.songsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.songsDataGridView_CellEndEdit);
            this.songsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.songsDataGridView_CellFormatting);
            this.songsDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.songsDataGridView_CellPainting);
            this.songsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.songsDataGridView_CellValidating);
            this.songsDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.songsDataGridView_RowPostPaint);
            this.songsDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.songsDataGridView_RowPrePaint);
            // 
            // onlySet
            // 
            this.onlySet.Location = new System.Drawing.Point(20, 15);
            this.onlySet.Name = "onlySet";
            this.onlySet.Size = new System.Drawing.Size(54, 26);
            this.onlySet.TabIndex = 3;
            this.onlySet.Text = "只读";
            this.onlySet.UseVisualStyleBackColor = true;
            this.onlySet.Click += new System.EventHandler(this.onlySet_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(89, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "绘画单元格";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(192, 15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "单元格输入方式";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form_datagridview1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 531);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.onlySet);
            this.Controls.Add(this.panel1);
            this.Name = "Form_datagridview1";
            this.Text = "Form_datagridview1";
            this.Load += new System.EventHandler(this.Form_datagridview1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addNewRowButton;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView songsDataGridView;
        private System.Windows.Forms.Button onlySet;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}