using System.Threading.Tasks;
using System;
using System.Diagnostics;
namespace cApp1
{
    class Synchronus
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
	        stopWatch.Start();
            MyMethod1();
            MyMethod2();
            System.Console.WriteLine( "Total Time Taken : {0} " , stopWatch.ElapsedMilliseconds/ 1000);
            System.Console.WriteLine("My Method1 completed.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
          
        }
        
         public static void MyMethod1()
        {
            Task.Delay(2000).Wait();
            System.Console.WriteLine("My Method completed..");
        }

          public static void MyMethod2()
        {
            Task.Delay(2000).Wait();
            System.Console.WriteLine("My Method completed..");
        }
    }
}
