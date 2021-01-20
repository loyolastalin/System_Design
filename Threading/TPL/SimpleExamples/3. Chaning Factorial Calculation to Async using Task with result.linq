<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var factorialCalculator = new Factorial();	
	var factorialTasks = new List<Task>();
	var stopWatch = new Stopwatch();
	stopWatch.Start();	
	
	var factorialTask = factorialCalculator.GenerateAsync(23);
	factorialTask.Result.Dump("The factorial of " + 23 + " is:");
	
	(stopWatch.ElapsedMilliseconds/ 1000).Dump("Total number of seconds it took to calculate factorial");
	
	"Program Ends here".Dump();
}

// Define other methods and classes here
public class Factorial
{

	public Task<int> GenerateAsync(int input)
	{
		return Task.Factory.StartNew( ()=> 
		{			
			return Generate(input);
		});
	}
	
	private int Generate(int input)
	{
		Thread.Sleep(200);
		return ((input == 0) ? 1 : input * Generate(input - 1));
	}	
}