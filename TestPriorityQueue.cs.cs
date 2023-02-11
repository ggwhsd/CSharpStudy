using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketRiskUI
{
    class TestPriorityQueue
    {
        public void Test()
        {
            Random r = (new Random());
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(10);
            for (int i = 0; i < 10; i++)
            {
                int v = r.Next(i, 10);
                Console.Write(v + " ");
                priorityQueue.Push(v);
            }

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                var v = priorityQueue.Pop();
                Console.Write(v + " ");
            }

            Console.WriteLine();


            PriorityQueue<DataEvent> priorityQueue1 = new PriorityQueue<DataEvent>(new DataEventComparer());
            for (int i = 0; i < 10; i++)
            {
                DataEvent d1 = new DataEvent();
                d1.seq = i;
                d1.uptime = DateTime.Now + TimeSpan.FromSeconds(r.Next(1, 1));

                Console.WriteLine(d1);
                priorityQueue1.Push(d1);
            }
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                var v = priorityQueue1.Pop();
                Console.WriteLine(v);
            }



        }
    }

    class PriorityQueue<T>
    {
        IComparer<T> comparer;
        /// <summary>
        /// 使用数组方式构造一个堆
        /// </summary>
        T[] heap;

        public int Count { get; private set; }
        public PriorityQueue() : this(null) { }
        public PriorityQueue(int capacity) : this(capacity, null) { }
        public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }
        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = comparer == null ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }
        public void Push(T v)
        {
            if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
            heap[Count] = v;
            SiftUp(Count++); //构造大顶堆，将数值大的放在堆上面。

        }

        public T Pop()
        {
            //取出堆顶元素
            var v = Top();
            //将最后一个值放到堆顶
            heap[0] = heap[--Count];
            //此时堆顶元素并不是构成堆，所以要将其向下调整。
            if (Count > 0)
                SiftDown(0);
            return v;
        }
        public T Top()
        {
            if (Count > 0) return heap[0];
            throw new InvalidOperationException("优先队列为空，没有元素可以提供了");
        }
        void SiftUp(int n)
        {
            var v = heap[n];
            var n1 = n;
            for (var nParent = n1 / 2; n1 > 0 && comparer.Compare(v, heap[nParent]) > 0; n1 = nParent, nParent /= 2)
            {
                //从n1位置的父节点位置 nParent 开始调整
                //如果n1位置的值大于 nParent 位置的值，则将nParent的值向下移动到 n1 上，继续调整。
                heap[n1] = heap[nParent];
            }
            //调整完毕之后的最后一行执行，n1=nParent，所以n1位置目前就是带插入数据的位置。
            heap[n1] = v;
        }
        void SiftDown(int n)
        {
            var v = heap[n];
            var n1 = n;
            for (var nChild = n1 * 2; nChild < Count; n1 = nChild, nChild *= 2)
            {
                //往子节点调整
                //找出左右两个子节点中 较大的那个节点
                if (nChild + 1 < Count && comparer.Compare(heap[nChild + 1], heap[nChild]) > 0)
                    nChild++;
                if (comparer.Compare(v, heap[nChild]) >= 0)
                    //如果大于等于子节点，则无需调整，已经调整结束。
                    break;
                else
                {
                    heap[n1] = heap[nChild];
                }
            }
            heap[n1] = v;
        }


    }

    class DataEvent
    {
        public int seq;
        public DateTime uptime;
        public static int count = 0;
        public DataEvent()
        {
            Interlocked.Increment(ref count);
        }

        public override string ToString()
        {
            return uptime.ToLongTimeString() + "-" + seq + "-" + count;
        }
    }

    class DataEventComparer : IComparer<DataEvent>
    {
        public int Compare(DataEvent x, DataEvent y)
        {
            if (x.uptime < y.uptime)
                return -1;
            else if (x.uptime == y.uptime && x.seq == y.seq)
                return 0;
            else if (x.uptime == y.uptime && x.seq < y.seq)
                return -1;
            else if (x.uptime == y.uptime && x.seq > y.seq)
                return 1;
            else
                return 1;
        }
    }
}
