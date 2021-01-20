<Query Kind="Program" />

void Main()
{
	var factorialCalculator = new Factorial();	

	var stopWatch = new Stopwatch();
	stopWatch.Start();
	
	factorialCalculator.Generate(23).Dump("The factorial of " + 23 + " is ");	
	
	(stopWatch.ElapsedMilliseconds/ 1000).Dump("Total number seconds it took to calculate factorial");
	
	"Program Ends here".Dump();
}

// n! = n * (n-1)
public class Factorial
{
	public int Generate(int input)
	{
		Thread.Sleep(200);
		return ((input == 0) ? 1 : input * Generate(input - 1));
	}	
}