using HappyWpf.MyViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            EditCommand = new BaseCommand(new Action<object>(obj =>
            {
                Int32 id = obj is Int32 ? (Int32)obj : 0;
                Edit(id);

            }));

            DelCommand = new BaseCommand(new Action<object>(obj =>
            {
                Int32 id = obj is Int32 ? (Int32)obj : 0;
                Del(id);
            }));

            AddCommand = new BaseCommand(new Action<object>(obj =>
            {
               
                Add();
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
            GridModelList = new ObservableCollection<gridViewModelStudent>();
            if (models != null)
            {
                models.ForEach(arg =>
                {
                    GridModelList.Add(arg);
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

        public BaseCommand QueryCommand { get;set; }

        public BaseCommand ResetCommand { get;set; }

        public BaseCommand TestCommand { get; set; }

        public BaseCommand EditCommand { get; set; }

        public BaseCommand DelCommand { get; set; }

        public BaseCommand AddCommand { get; set; }

        public void Edit(int Id)
        {
            var model =ld.GetStudentById(Id);
            if (model != null)
            {
                girdEditView view = new girdEditView(model);
                var rtn = view.ShowDialog();
                if (rtn.Value)
                {
                    var newModel = GridModelList.FirstOrDefault(t => t.Id == model.Id);
                    if (newModel != null)
                    {
                        newModel.Name = model.Name;
                    }
                }
            }
        }

        public void Del(int Id)
        {
            var model = ld.GetStudentById(Id);
            if (model != null)
            {
                var r = MessageBox.Show($"确定删除当前用户id {Id}", "操作提示", MessageBoxButton.OK, MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                {
                    ld.DelStudent(model.Id);
                }
                this.Query();
            }
        }

        public void Add()
        {
            gridViewModelStudent model = new gridViewModelStudent();
            girdEditView view = new girdEditView(model);
            var rtn = view.ShowDialog();
            if (rtn.Value)
            {
                model.Id = GridModelList.Max(t => t.Id) + 1;
                ld.AddStudent(model);
                this.Query();
            }
        }


    }
}
