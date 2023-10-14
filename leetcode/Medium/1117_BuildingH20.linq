<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class H2O
{
	private SemaphoreSlim hydrosem = new SemaphoreSlim(2); 
	private SemaphoreSlim oxysem = new SemaphoreSlim(1); 
	private int count = 0; 
	private Object locker = new Object(); 
	
	public H2O()
	{

	}

	public void Hydrogen(Action releaseHydrogen)
	{
		hydrosem.Wait();
		// releaseHydrogen() outputs "H". Do not change or remove this line.
		lock (locker) 
		{
			releaseHydrogen();
			if (++count % 2 == 0)
			{
				oxysem.Release();
			}
		}
		
	}

	public void Oxygen(Action releaseOxygen)
	{
		oxysem.Wait(); 
		// releaseOxygen() outputs "O". Do not change or remove this line.
		releaseOxygen();
		hydrosem.Release(2); 
	}
}

#region private::Tests

[Theory]
[InlineData("OHH")]
[InlineData("OOHHHH")]
[InlineData("HHHHOO")]
void Test(string inputs) 
{
	Console.WriteLine($"Testing {inputs}"); 
	H2O watermaker = new H2O(); 
	Task[] tasks = new Task[inputs.Length];
	for(int i = 0; i < inputs.Length; i++)
	{
		Char c = inputs[i]; 
		if (c == 'H')
		{
			tasks[i] = Task.Run(() => watermaker.Hydrogen(() => Console.WriteLine("H")));
		}
		else 
		{
			tasks[i] = Task.Run(() => watermaker.Oxygen(() => Console.WriteLine("O")));
		}
	}
	Task.WaitAll(); 
	Console.WriteLine(); 
}
#endregion