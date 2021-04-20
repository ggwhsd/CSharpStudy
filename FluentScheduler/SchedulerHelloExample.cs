using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI.FluentScheduler
{
    class SchedulerHelloExample
    {
        public static void Hello()
        {
            JobManager.Initialize();

            JobManager.AddJob(
                () => Console.WriteLine("5 seconds just passed."),
                s => s.ToRunEvery(5).Seconds()
            );
        }

        public static void AddJob()
        {
            JobManager.AddJob(
                () => Console.WriteLine("10 seconds just passed."),
                s => s.ToRunEvery(10).Seconds()
                );
        }

        public static void AddOnceJob()
        {
            JobManager.AddJob(
                () => Console.WriteLine("10 seconds just passed. once."),
                s => s.ToRunOnceIn(10).Seconds()
                );
        }

        public static void AddOnceJobAt()
        {
            JobManager.AddJob(
                () => Console.WriteLine("now+10 seconds just passed. once."),
                s => s.ToRunOnceAt(DateTime.Now.AddSeconds(10))
                );
        }

    }
}
