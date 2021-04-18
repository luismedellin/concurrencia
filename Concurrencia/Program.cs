using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrencia
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var data = await Task.FromResult(100);

            //var task1 = new Task(() => {
            //    Thread.Sleep(1000);    
            //    Console.WriteLine("Hola task 1"); 
            //});
            //task1.Start();

            //var task2 = new Task(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("task 2");
            //});
            //task2.Start();

            //Console.WriteLine("Otro mensaje");

            //await task1;
            //await task2;

            //PrintItems();
            total();
            Console.WriteLine(_total);

            Console.WriteLine("Hello World!");

            //task1.Wait();
        }

        public static void PrintItems()
        {
            Parallel.For(1, 10, i =>
            {
                Console.WriteLine($"value of count = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            });
        }

        private static object _lock = new object();
        private static int _total = 0;

        public static void total()
        {
            Parallel.For(1, 5, i =>
            {
                lock (_lock)
                {
                    _total += GetValue(i);
                    Thread.Sleep(100);
                }
            });
        }

        static int GetValue(int i)
        {
            return i;
        }
    }
}
