﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.Entity
{
    class Person
    {
        string name = "No Name";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
