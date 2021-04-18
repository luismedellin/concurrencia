using System;
using System.Threading;

namespace ThreadingCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(CycleMethod);
            thread.Start();
            thread.Name = "Worker 1";

            Thread.CurrentThread.Name = "Main thread";
            for (var i = 0; i < 50; i++)
            {
                Console.Write($"A {i}");
            }

            Console.ReadLine();
        }

        private static void CycleMethod()
        {
            for (var i = 0; i < 50; i++)
            {
                Console.Write($"Z {i}");
            }
        }
    }
}
