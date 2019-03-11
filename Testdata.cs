using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketRiskUI
{
    class Testdata
    {

        public char dataType;
        public char[] name;
        public int port;
        Testdata(char d, string n, int p)
        {
            dataType = d;
            name = n.ToCharArray();
            port = p;

        }
    }
}
