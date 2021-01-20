<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var factorialCalculator = new Factorial();	

	var stopWatch = new Stopwatch();
	stopWatch.Start();	
	
	var t = new Task(() => factorialCalculator.Generate(23).Dump("The factorial of " + 23 + " is "));
	t.Start();		
	
	(stopWatch.ElapsedMilliseconds/ 1000).Dump("Total number of seconds it took to calculate factorial");
	
	"Program Ends here".Dump();
}

// // n! = n * (n-1)
public class Factorial
{
	public int Generate(int input)
	{
		Thread.Sleep(200);
		return ((input == 0) ? 1 : input * Generate(input - 1));
	}	
}