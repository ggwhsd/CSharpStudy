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
    public partial class datagridviewBindList : Form
    {
        public datagridviewBindList()
        {
            InitializeComponent();
        }
        public class relation_safe_strategy
        {
            private string id;
            private string sid;
            private string sid_protect;
            private string safeType;
            private string isUse;
            //一定要用属性才能绑定到datagridview上显示。
            public string Id { get => id; set => id = value; }
            public string Sid { get => sid; set => sid = value; }
            public string Sid_protect { get => sid_protect; set => sid_protect = value; }
            public string SafeType { get => safeType; set => safeType = value; }
            public string IsUse { get => isUse; set => isUse = value; }

            public relation_safe_strategy(string id, string sid, string sid_protect, string safeType, string isUse)
            {
                this.id = id;
                this.sid = sid;
                this.sid_protect = sid_protect;
                this.safeType = safeType;
                this.isUse = isUse;
            }
            public override string ToString()
            {
                return id + "," + sid + "," + sid_protect + "," + safeType + "," + isUse;
            }
        }
        List<relation_safe_strategy> data;
        private void button1_Click(object sender, EventArgs e)
        {
            data = new List<relation_safe_strategy>();
            relation_safe_strategy d1 = new relation_safe_strategy("1","s1","sp1","1","1");
          
            data.Add(d1);

            dataGridView1.DataSource = new BindingList<relation_safe_strategy>(data);
            dataGridView1.Refresh();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
           
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmp_DGV = (DataGridView)sender;


            if (e.RowIndex >= 0)
            {

                foreach (DataGridViewCell cell in tmp_DGV.Rows[e.RowIndex].Cells)
                {
                    Console.WriteLine(cell.Value.ToString());
                }
               
               
            }
        }
    }
}
