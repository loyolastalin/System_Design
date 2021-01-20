### Difference between the time taken for the Concurreny only vs Concurrency + Performance
dotnet build . /p:StartupObject=AsyncParallel.Concurrency
Concurenty execution..
First completed ! and result 1
First Resut 1 second 2
Total execution time: 3047

dotnet build . /p:StartupObject=AsyncParallel.Mixed
Async Parallel execution..
First Resut 1 second 2
Total execution time: 2021
