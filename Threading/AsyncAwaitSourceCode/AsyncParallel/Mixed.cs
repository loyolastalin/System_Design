using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncParallel
{
    class Mixed
    {
        static async Task Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Async Parallel execution..");
            List<Task<int>> tasks = new List<Task<int>>();
            tasks.Add(FistNum());
            tasks.Add(Second());
            var results =  await Task.WhenAll(tasks);
            

            Console.WriteLine("First Resut {0} second {1}", results[0], results[1]);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Total execution time: { elapsedMs }");
        }

        private static async Task<int> FistNum()
        {
            await Task.Delay(1000);
            return 1;
        }

        private static async Task<int> Second()
        {
            await Task.Delay(2000);
            return 2;
        }
    }
}
