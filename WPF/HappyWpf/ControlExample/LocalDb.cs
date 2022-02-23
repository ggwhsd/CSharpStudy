using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.ControlExample
{
    public class LocalDb
    {
        public LocalDb()
        {
            init();
        }
        private List<gridViewModelStudent> students;
        private void init()
        {
            students = new List<gridViewModelStudent>();
            for (int i = 0; i < 30; i++)
            {
                students.Add(new gridViewModelStudent()
                {
                    Id = i,
                    Name = $"Name {i}"
                });
            }
        }

        public List<gridViewModelStudent> GetStudents()
        {
            return students;
        }

        public void AddStudent(gridViewModelStudent e)
        {
            students.Add(e);
        }

        public void DelStudent(int id)
        {
            var model = students
                .FirstOrDefault(t => t.Id == id);
            if (model != null)
            {
                students.Remove(model);
            }
        }

        public List<gridViewModelStudent> GetStudentByName(string name)
        {
            if (name == null)
                return new List<gridViewModelStudent>();
            return students
                .Where(q => q.Name.Contains(name))
                .ToList();
        }
    }
}
