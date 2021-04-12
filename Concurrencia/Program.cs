using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrencia
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = await Task.FromResult(100);

            var task1 = new Task(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("Hola task 1");
            });
            task1.Start();

            var task2 = new Task(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("task 2");
            });
            task2.Start();

            System.Console.WriteLine("Otro mensaje");

            await task1;
            await task2;

            System.Console.WriteLine("Hello World!");

            //task1.Wait();
        }

        //public static async Task CallThread()
        //{
        //    return 
        //}
    }
}
