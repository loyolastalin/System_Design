using System;
using System.Threading.Tasks;

namespace AsyncParallel
{
    class Concurrency
    {
        private static async Task Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Concurenty execution..");
            var first  = await FistNum();
            Console.WriteLine($"First completed ! and result {first}" );
            var second  = await Second();

            Console.WriteLine("First Resut {0} second {1}", first, second);
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
