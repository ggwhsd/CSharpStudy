using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class CsvHelperTest : Form
    {
        public CsvHelperTest()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 直接将csv文件中第二行开始的记录转换到对应的数据类中，
        /// csv文件中的列名需要和类的属性名相同。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<Foo>(); //一次性读取所有数据，并且转换为对象集合。
                
                foreach (Foo line in records)
                {
                    Console.WriteLine($"{line.Id} {line.Name}");
                }
            }
        }
        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<Foo>();
                csv.Read();//开始读取文件
                csv.ReadHeader();  //读取首行记录作为表头
                while (csv.Read())  //逐行读取
                {
                    var record = new Foo
                    {
                        Id = csv.GetField<int>("Id"),  //读取Id列
                        Name = csv.GetField("Name")   //读取Name列
                    };
                    records.Add(record);
                }

                foreach (Foo line in records)
                {
                    Console.WriteLine($"{line.Id} {line.Name}");
                }
            }
        }
        private DataTable dt_new = new DataTable();
        private void button4_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.
                using (var dr = new CsvDataReader(csv))
                {
                    dt_new.Columns.Clear();
                    var dt = new DataTable();
                    dt.Load(dr);
                    
                    //如果想实现datagridview修改同步到datatable，需要重新生成一个datatable对象，不能直接使用csv初始化
                    foreach (DataColumn col in dt.Columns)
                    {
                        dt_new.Columns.Add(col.ColumnName, col.DataType);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        dt_new.Rows.Add(row["Id"],row["Name"]);
                    }
                    dt_new.TableName = "ddd";


                    dataGridView1.DataSource = dt_new;
                    Console.WriteLine(dataGridView1.Columns.IsReadOnly);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var records = new List<Foo>();
            DataTable dt = dataGridView1.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                Foo foo = new Foo();
                foo.Id = Int32.Parse(row["Id"].ToString());
                foo.Name = row["Name"].ToString();
                records.Add(foo);
            }

            using (var writer = new StreamWriter("file.csv", false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var records = new List<Foo>
            {
                new Foo { Id = 1, Name = "one" },
            };

            using (var writer = new StreamWriter("file.csv",false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
