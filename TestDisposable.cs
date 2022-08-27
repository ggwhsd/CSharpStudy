using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI
{
    class TestDisposable
    {
        public static void Example()
        {
            using (UnmanagedDisposable ud = new UnmanagedDisposable())
            {
                ud.DoSomething();
            }

        }
    }

    /// <summary>
    /// C#中的资源分为：
    ///     托管资源,由CLR管理，new时创造，没有引用时，会被垃圾回收。
    ///     非托管资源，不由CLR管理，如操作系统内核，以及访问C++的动态链接库等。
    /// 非托管对象，如果要释放一些系统资源，则需要自己释放。实现了IDisposable接口后，当不在使用该对象时，垃圾回收器会检查是否由IDisposable接口，如果有，则会先处理这个接口，在下一次垃圾回收时，才会释放自己，即托管资源。
    /// 以上是自动处理。也可以手动调用释放非托管资源,但是注意资源不可多次释放。
    /// </summary>
    class UnmanagedDisposable : IDisposable
    {
        public void DoSomething()
        {
            Console.WriteLine("Do some thing....");
        }
        public void Dispose()
        {
            if (!isDisposed)
            {
                Console.WriteLine("及时释放资源，一般在使用using{}方式时会自动被动调用");
                isDisposed = true;
            }
        }
        private bool isDisposed = false;

        ~UnmanagedDisposable()
        {
            Console.WriteLine("析构函数的时候，可以主动调用Dispose");
            Dispose();
        }
    }
}
