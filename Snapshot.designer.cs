namespace UITest
{
    partial class Snapshot
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
            this.SuspendLayout();
            // 
            // Snapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 657);
            this.Name = "Snapshot";
            this.Text = "Snapshot";
            this.Load += new System.EventHandler(this.Snapshot_Load);
            this.DoubleClick += new System.EventHandler(this.Snapshot_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Snapshot_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Snapshot_MouseDoubleClick);
            this.MouseCaptureChanged += new System.EventHandler(this.Snapshot_MouseCaptureChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Snapshot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Snapshot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Snapshot_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}