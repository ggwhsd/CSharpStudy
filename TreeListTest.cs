using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class TreeListTest : Form
    {
        public TreeListTest()
        {
            InitializeComponent();
            treeView1.SelectedNode = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           Console.WriteLine(e.Node.Name);
        }

        private void BindTreeView()
        {
            
            treeView2.LabelEdit = false;
            TreeNode root = new TreeNode();
            root.Text = "根节点";
            root.Name = "All";

            TreeNode node1 = new TreeNode();
            node1.Text = "新增";
            node1.Name = "add";

            TreeNode node2 = new TreeNode();
            node2.Text = "编辑";
            node2.Name = "edit";

            TreeNode node11 = new TreeNode();
            node11.Text = "新增管理员";
            node11.Name = "AddManager";
            TreeNode node12 = new TreeNode();
            node12.Text = "新增普通用户";
            node12.Name = "AddUser";
            TreeNode node21 = new TreeNode();
            node21.Text = "编辑管理员";
            node21.Name = "EditManager";
            TreeNode node22 = new TreeNode();
            node22.Text = "编辑普通用户";
            node22.Name = "EditUser";

            node1.Nodes.Add(node11);
            node1.Nodes.Add(node12);
            node2.Nodes.Add(node21);
            node2.Nodes.Add(node22);

            root.Nodes.Add(node1);
            root.Nodes.Add(node2);

            treeView2.Nodes.Add(root);
        }

        public Queue<string> ll = new Queue<string>();

        private void button3_Click(object sender, EventArgs e)
        {
            BindTreeView();

        }


        void SetCheckedTreeViewList(string tab,TreeNode node)
        {
            if (node.Checked == true)
            {
                ll.Enqueue(tab+node.Text+",");
            }
            else
            { }
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode cnode in node.Nodes)
                {
                    SetCheckedTreeViewList(tab+" ", cnode);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ll.Clear();
            foreach (TreeNode node in treeView1.Nodes)//实际上treeVIew1里面只有1个根节点，所以要用递归方法
            {
                SetCheckedTreeViewList(" ",node);
            }
           
            foreach (string str in ll)
            {
                Console.WriteLine(str);
            }
        }

        private void TreeListTest_Load(object sender, EventArgs e)
        {
            Console.WriteLine("load");
            treeView1.SelectedNode = null;
            
        }

        private void TreeListTest_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("shown");
        }
        //子节点递归
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
        }
        //父节点递归
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked)
                {
                    setChildNodeCheckedState(e.Node, true);
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, true);
                    }
                }
                else
                {
                    setChildNodeCheckedState(e.Node, false);
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
               
            }
            else
            {

            }
        }
    }
}
