using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            [JsonProperty("active")]
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
                          'active': true,
                          'CreatedDate': '2013-01-20T00:00:00Z',
                          'Roles': [
                            'User',
                            'Admin'
                          ]
                        }";

            Account account = JsonConvert.DeserializeObject<Account>(json);
            MessageBox.Show("json反序列化为对象，Email字段值" + account.Active);
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


        public class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie
            {
                Name = "Bad Boys",
                Year = 1995
            };

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"C:\Users\a\Desktop\movie1.json", JsonConvert.SerializeObject(movie));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Users\a\Desktop\movie2.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movie);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // read file into a string and deserialize JSON to a type
            Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"C:\Users\a\Desktop\movie1.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\a\Desktop\movie1.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dictionary<string, Movie> points = new Dictionary<string, Movie>
                    {
                        { "James", new Movie{ Name = "One Boys", Year = 1995} },
                        { "Jo", new Movie{ Name = "Two Boys", Year = 1996} },
                        { "Jess", new Movie{ Name = "Three Boys", Year = 1997} }
                    };

            string json = JsonConvert.SerializeObject(points, Formatting.None);

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"C:\Users\a\Desktop\points1.json", JsonConvert.SerializeObject(points));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Users\a\Desktop\points2.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, points);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
  


            // read file into a string and deserialize JSON to a type
            Dictionary<string, Movie> points = JsonConvert.DeserializeObject<Dictionary<string, Movie>>(File.ReadAllText(@"C:\Users\a\Desktop\points2.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\a\Desktop\points2.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dictionary<string, Movie> points2 = (Dictionary<string, Movie>)serializer.Deserialize(file, typeof(Dictionary<string, Movie>));
            }
        }
    }
}
