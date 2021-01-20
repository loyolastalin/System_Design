using System.Threading;
using System.Threading.Tasks.Sources;
using System.Diagnostics.Tracing;
using System.Diagnostics.SymbolStore;
using System.IO.Enumeration;
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System;

namespace cApp1
{
    class Parallel_Model
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(MyMethod1Parallel);   
            Task.Factory.StartNew(MyMethod2Parallel);                     
            System.Console.WriteLine("My Parallel Method1 completed.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Main Mathod completed and waits from other process..");
            Console.Read();
             System.Console.WriteLine("Main method ID after all async process.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
        
        public static void MyMethod1Parallel()
        {
          System.Console.WriteLine("My Parallel Method1 begins with the ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
             Task.Delay(2000).Wait();
            System.Console.WriteLine("My Parallel Method1 resume with ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

          public static void MyMethod2Parallel()
        {
             System.Console.WriteLine("My Parallel Method2 begins with ID.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Task.Delay(2000).Wait();
             System.Console.WriteLine("My Parallel Method2 resume with id.." + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

       
    }
}
