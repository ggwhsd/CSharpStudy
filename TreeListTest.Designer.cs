namespace MarketRiskUI
{
    partial class TreeListTest
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点16");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(9, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点4";
            treeNode1.Text = "节点4";
            treeNode2.Name = "节点5";
            treeNode2.Text = "节点5";
            treeNode3.Name = "节点6";
            treeNode3.Text = "节点6";
            treeNode4.Name = "节点7";
            treeNode4.Text = "节点7";
            treeNode5.Name = "节点0";
            treeNode5.Text = "节点0";
            treeNode6.Name = "节点8";
            treeNode6.Text = "节点8";
            treeNode7.Name = "节点9";
            treeNode7.Text = "节点9";
            treeNode8.Name = "节点10";
            treeNode8.Text = "节点10";
            treeNode9.Name = "节点11";
            treeNode9.Text = "节点11";
            treeNode10.Name = "节点1";
            treeNode10.Text = "节点1";
            treeNode11.Name = "节点12";
            treeNode11.Text = "节点12";
            treeNode12.Name = "节点13";
            treeNode12.Text = "节点13";
            treeNode13.Name = "节点14";
            treeNode13.Text = "节点14";
            treeNode14.Name = "节点2";
            treeNode14.Text = "节点2";
            treeNode15.Name = "节点15";
            treeNode15.Text = "节点15";
            treeNode16.Name = "节点16";
            treeNode16.Text = "节点16";
            treeNode17.Name = "节点17";
            treeNode17.Text = "节点17";
            treeNode18.Name = "节点3";
            treeNode18.Text = "节点3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10,
            treeNode14,
            treeNode18});
            this.treeView1.Size = new System.Drawing.Size(369, 407);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(384, 12);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(404, 407);
            this.treeView2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "展开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "收缩";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(390, 431);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "动态绑定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 428);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "遍历选中";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TreeListTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 479);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Name = "TreeListTest";
            this.Text = "TreeListTest";
            this.Load += new System.EventHandler(this.TreeListTest_Load);
            this.Shown += new System.EventHandler(this.TreeListTest_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}