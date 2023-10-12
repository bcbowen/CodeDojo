<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class ZeroEvenOdd
{
	private int n;
	private int remaining; 
	private System.Threading.ManualResetEventSlim _zeroEvent; 
	private System.Threading.ManualResetEventSlim _oddEvent;
	private System.Threading.ManualResetEventSlim _evenEvent;

	public ZeroEvenOdd(int n)
	{
		this.n = n;
		remaining = n * 2; 
		_zeroEvent = new ManualResetEventSlim(true);
		_evenEvent = new ManualResetEventSlim(false);
		_oddEvent = new ManualResetEventSlim(false); 
	}

	// printNumber(x) outputs "x", where x is an integer.
	public void Zero(Action<int> printNumber)
	{
		while (remaining > 0)
		{
			_zeroEvent.Wait(); 
			
			if (remaining > 0) printNumber(0);
			Interlocked.Decrement(ref remaining); 
			_zeroEvent.Reset();
			_oddEvent.Set();
			
			_zeroEvent.Wait();
			
			if (remaining > 0) printNumber(0);
			Interlocked.Decrement(ref remaining);
			_zeroEvent.Reset();
			_evenEvent.Set();
		}
	}

	public void Even(Action<int> printNumber)
	{
		int val = 2; 
		
		while (remaining > 0) 
		{
			_evenEvent.Wait();
			
			if (remaining > 0) printNumber(val); 
			val += 2; 
			Interlocked.Decrement(ref remaining); 
			_zeroEvent.Set(); 
			_evenEvent.Reset(); 
		}
	}

	public void Odd(Action<int> printNumber)
	{
		int val = 1;
		
		while (remaining > 0)
		{
			_oddEvent.Wait();
			if (remaining > 0) printNumber(val);
			val += 2;
			Interlocked.Decrement(ref remaining); 
			_zeroEvent.Set(); 
			_oddEvent.Reset();
		}
	}
}



[Theory]
[InlineData(1)]
[InlineData(2)]
[InlineData(5)]
[InlineData(19)]
void Test(int n) 
{
	ZeroEvenOdd z = new ZeroEvenOdd(n);
	Console.WriteLine($"Processing n:{n}");
	Action<int> printNumber = (n) => Console.Write(n);
	Task[] tasks = new Task[] 
	{
		Task.Run (() => z.Zero(x => printNumber(x))),
		Task.Run (() => z.Odd(x => printNumber(x))),
		Task.Run (() => z.Even(x => printNumber(x))),
	}; 
	Task.WaitAll(tasks); 
	Console.WriteLine(); 
}
