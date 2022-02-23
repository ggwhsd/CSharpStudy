using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWpf.MyViewModelBase
{
    /// <summary>
    /// 设置一个实现MVVM模式的基类，以此增加后续复用代码.
    /// 作用就是将后台属性修改之后发送给绑定好的数据，通过ui对象的datacenter进行相关的绑定。
    /// 数据流:  后台model ->  ui
    /// 
    /// </summary>
    public class NotificationObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
