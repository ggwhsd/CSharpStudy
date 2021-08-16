using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 所有游戏中涉及的对象，都要被该类管理，可以把该类理解为一个容器，游戏对象的容器。
    /// </summary>
    class ObjectManager
    {
        private Dictionary<int, Objects> objectdict = new Dictionary<int, Objects>();
        static int counter = 0;

        internal Dictionary<int, Objects> Objectdict { get => objectdict; set => objectdict = value; }

        public void AddObject(Objects objects)
        {
            counter += 1;
            objectdict[counter] = objects;
            objects.Id = counter;
        }
        public void RemoveObjectByid(int id)
        {
            objectdict.Remove(id);
        }
    }
}
