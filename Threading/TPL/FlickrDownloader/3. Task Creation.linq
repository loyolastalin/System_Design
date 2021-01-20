<Query Kind="Statements">
  <GACReference>System.Reactive, Version=1.0.2787.104, Culture=neutral, PublicKeyToken=31bf3856ad364e35</GACReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>



// === Backgroud thread ================

// Without TPL
var thread = new Thread(DoWork);
thread.IsBackground = true;
thread.Start();


// With TPL
var task = Task.Factory.StartNew(DoWork, TaskCreationOptions.LongRunning);




// === ThreadPool.Queue ================

// Without TPL
ThreadPool.QueueUserWorkItem(DoWork);


// With TPL
var task = Task.Factory.StartNew(DoWork);



