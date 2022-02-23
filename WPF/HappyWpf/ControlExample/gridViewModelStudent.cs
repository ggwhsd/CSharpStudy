using HappyWpf.MyViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.ControlExample
{
    public class gridViewModelStudent : NotificationObject
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

    }
}
