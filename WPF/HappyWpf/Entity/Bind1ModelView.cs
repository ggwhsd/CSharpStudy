using HappyWpf.MyViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.Entity
{
    //动态通知
    class Bind1ModelView  : NotificationObject
    {
        public Bind1ModelView()
        {
            name = "hello Bind1Modelview";
            DateTime begin  = DateTime.Now;
            DateTime end = begin.AddSeconds(30);
            Task.Run(async () =>
            {
                while (DateTime.Now <= end)
                {
                    await Task.Delay(3000);
                    Name = DateTime.Now.ToString();
                }
            });
        }
        
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            }
        }


        private BaseCommand clickUpdateCommand;
        public BaseCommand ClickUpdateCommand
        {
            get
            {
                if (clickUpdateCommand == null)
                {
                    clickUpdateCommand = new BaseCommand(new Action<object>(o =>
                    {
                        Name = "点击了我" + DateTime.Now.ToString();
                    }));
                }
                return clickUpdateCommand;
            }
        }



    }

}
