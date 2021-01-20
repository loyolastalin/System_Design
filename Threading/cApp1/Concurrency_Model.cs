using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace cApp1
{
    class Concurrency_Model
    {
        static void Main(string[] args)
        {
             var stopWatch = new Stopwatch();
	        stopWatch.Start();
            MyMethod1Async();
            MyMethod2Async();
            System.Console.WriteLine("My Parallel Method1 completed.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Main Mathod completed and waits from other process..");
            System.Console.WriteLine( "Total Time Taken : {0} " , stopWatch.ElapsedMilliseconds/ 1000);
            Console.Read();     
             System.Console.WriteLine("Main method ID after all async process.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
        
        public static async void MyMethod1Async()
        {
          System.Console.WriteLine("My Parallel Method1 begins with the ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            System.Console.WriteLine("My Parallel Method1 resume with ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

          public static async void MyMethod2Async()
        {
             System.Console.WriteLine("My Parallel Method2 begins with ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
             System.Console.WriteLine("My Parallel Method2 resume with id.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
}
