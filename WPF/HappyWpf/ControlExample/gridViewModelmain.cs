using HappyWpf.MyViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.ControlExample
{
    public class gridViewModelmain : NotificationObject
    {
        LocalDb ld = new LocalDb();

        
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<gridViewModelStudent> gridModelList;

        public gridViewModelmain()
        {
            QueryCommand = new BaseCommand(new Action<object> ( obj => {
                Query1(searchText);
            }));
            ResetCommand = new BaseCommand(new Action<object>(obj => {
                searchText = string.Empty;
                this.Query1(searchText);
                
            }));

            TestCommand = new BaseCommand(new Action<object>(obj => {
                

                DateTime begin = DateTime.Now;
                DateTime end = begin.AddSeconds(30);
                Task.Run(async () =>
                {
                    while (DateTime.Now <= end)
                    {
                        await Task.Delay(1);
                        foreach (var ele in gridModelList)
                        {
                            ele.Name = DateTime.Now.ToString(" hh:mm:ss.ffff");
                        }
                    }
                });

            }));
        }

        public ObservableCollection<gridViewModelStudent> GridModelList { 
            get => gridModelList;
            set
            {
                gridModelList = value;
                OnPropertyChanged("GridModelList");
            }
        }
        public void Query()
        {
            var models = ld.GetStudents();
            gridModelList = new ObservableCollection<gridViewModelStudent>();
            if (models != null)
            {
                models.ForEach(arg =>
                {
                    gridModelList.Add(arg);
                });
            }
        }

        private string searchText;
        public string Search
        {
            get => searchText;
            set {
                searchText = value;
                OnPropertyChanged("Search");
            }
        }

        public void Query1(string searchText)
        {
            var models = ld.GetStudentByName(searchText);
            GridModelList = new ObservableCollection<gridViewModelStudent>();
            if (models != null)
            {
                models.ForEach(arg =>
                {
                    GridModelList.Add(arg);
                });
            }
        }

        public BaseCommand QueryCommand {
            get;set;
        }

        public BaseCommand ResetCommand
        {
            get;set;
        }

        public BaseCommand TestCommand
        { get; set; }


    }
}
