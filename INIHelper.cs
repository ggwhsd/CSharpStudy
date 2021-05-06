using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI
{
    class INIHelper
    {
        private static INIHelper instance = new INIHelper();
        public static INIHelper getInstance()
        {
            return instance;
        }
        /// <summary>
        /// 返回value
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public string Get(string fileName, string key, string default_value)
        {
            if (File.Exists(fileName) == false)
            {
                return default_value;
            }
            string rtn = default_value;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.IndexOf('=') >= 0)
                    {
                        if (line.Split('=')[0].Equals(key) == true)
                        {
                            rtn = line.Split('=')[1];
                            break;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
            }
            return rtn;
        }
        /// <summary>
        /// 写入key 和 value
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string fileName, string key, string value)
        {
            bool rtn = false;
            FileStream fs = null;
            if (File.Exists(fileName) == false)
            {
                fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            }
            else
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            Dictionary<string, string> key_values = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(fs))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.IndexOf('=') >= 0)
                    {
                        string[] splits = line.Split('=');
                        if (key_values.ContainsKey(splits[0]) == false)
                            key_values.Add(splits[0], splits[1]);
                    }
                    else
                    {
                    }

                }
            }
            key_values[key] = value;

            using (StreamWriter sw = new StreamWriter(fileName,false))
            {
               
                foreach (KeyValuePair<string,string> pair in key_values)
                {
                    sw.WriteLine($"{pair.Key}={pair.Value}");
                }
            }

            return rtn;
        }
    }
}
