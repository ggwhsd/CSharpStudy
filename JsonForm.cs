using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketRiskUI
{
    public partial class JsonForm : Form
    {
        public JsonForm()
        {
            InitializeComponent();
        }
        /*
         * 最简单的字符串示例
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //string jsonText = "{\"zone\":\"上海\",\"zone_en\":\"shanghai\"}";
            string jsonText = txtJson.Text;
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
            
            string zone = jo["zone"].ToString();
            string zone_en = jo["zone_en"].ToString();
            MessageBox.Show("zone="+zone+"\r\n"+"zone_en="+zone_en);

        }
        /*
         * json是一个数组
         */
        private void button3_Click(object sender, EventArgs e)
        {
            string jsonArrayText = "[{'a':'a1','b':'b1'},{'a':'a2','b':'b2'}]"; //"[{'a':'a1','b':'b1'}]即使只有一个元素，也需要加上[]
            //string jsonArrayText = "[{\"a\":\"a1\",\"b\":\"b1\"},{\"a\":\"a2\",\"b\":\"b2\"}]";  //上面写法和此写法效果一样
            JArray jArray = (JArray)JsonConvert.DeserializeObject(jsonArrayText);//jsonArrayText必须是带[]数组格式字符串
            string str = jArray[0]["a"].ToString();
            MessageBox.Show("数组[0]的key为a的值:"+ jArray[0]["a"].ToString());
        }
        public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
            public bool nullField;
            public int nullInt;
            public string nullStr;
        }
        /*对象序列化*/
        private void button2_Click(object sender, EventArgs e)
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
            {
                "User",
                "Admin"
            }
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            MessageBox.Show("对象序列化为json="+json);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string json = @"{
                          'Email': 'james@example.com',
                          'Active': true,
                          'CreatedDate': '2013-01-20T00:00:00Z',
                          'Roles': [
                            'User',
                            'Admin'
                          ]
                        }";

            Account account = JsonConvert.DeserializeObject<Account>(json);
            MessageBox.Show("json反序列化为对象，Email字段值" + account.Email);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> videogames = new List<string>
            {
                "Starcraft",
                "Halo",
                "Legend of Zelda"
            };
            string json = JsonConvert.SerializeObject(videogames);

            MessageBox.Show(json);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string json = @"['Starcraft','Halo','Legend of Zelda']";

            List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);

            MessageBox.Show(string.Join(", ", videogames.ToArray()));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string json = @"{
                          'href': '/account/login.aspx',
                          'target': '_blank'
                        }";

            Dictionary<string, string> htmlAttributes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            MessageBox.Show(htmlAttributes["href"]);
            // /account/login.aspx

            MessageBox.Show(htmlAttributes["target"]);
            // _blank
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> points = new Dictionary<string, int>
                    {
                        { "James", 9001 },
                        { "Jo", 3474 },
                        { "Jess", 11926 }
                    };

            string json = JsonConvert.SerializeObject(points, Formatting.None);
            Console.WriteLine(json);
        }
    }
}
