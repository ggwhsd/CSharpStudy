using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MarketRiskUI.LittleExamples
{
    class IOStudy
    {
        /*
         * 按存储位置分，FileStream, MemoryStream, BufferedStream
         */
        public void MemoryStream()
        {
           
        }
        //赋值src文件到dst文件,并且除去注释
        public void StreamInFileStream(string src, string dst)
        {
            string infname = src;
            string outfname = dst;
            try {
                FileStream fin = new FileStream(infname, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outfname, FileMode.Create, FileAccess.Write);

                StreamReader brin = new StreamReader(fin, System.Text.Encoding.Default);
                StreamWriter brout = new StreamWriter(fout, System.Text.Encoding.Default);

                int cnt = 0;
                string s = brin.ReadLine();
                while (s != null)
                {
                    cnt++;
                    s = DeleteComments(s);
                    if (s != null)
                    {
                        brout.WriteLine(s);
                        Console.WriteLine(cnt + ":\t" + s);
                    }
                    s = brin.ReadLine();
                }
                brin.Close();
                brout.Close();

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
            catch(IOException e2)
            {
                Console.WriteLine(e2);
            }
        }

        private bool BlockComments=false;
        private string DeleteComments(string s) //去掉注释
        {
            if (s == null)
                return s;
            int pos = -1;
            if (BlockComments)
            {
                pos = s.IndexOf("*/");
                if (pos >= 0)
                {
                    s = s.Substring(pos + 2);
                    BlockComments = false;
                }
                else
                    return null;
            }

            pos = s.IndexOf("//");
            if (pos >= 0)
                s = s.Substring(0, pos);
            else
            {
                pos = s.IndexOf("/*");
                if (pos >= 0)
                {
                    BlockComments = true;
                    s = s.Substring(0, pos);
                }
            }
            return s;
        }
    }
}
