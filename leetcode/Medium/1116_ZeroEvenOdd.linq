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
	private int current; 
	private System.Threading.ManualResetEventSlim _zeroEvent; 
	private System.Threading.ManualResetEventSlim _oddEvent;
	private System.Threading.ManualResetEventSlim _evenEvent;

	public ZeroEvenOdd(int n)
	{
		this.n = n;
		current = 1;
		_zeroEvent = new ManualResetEventSlim(true);
		_evenEvent = new ManualResetEventSlim(false);
		_oddEvent = new ManualResetEventSlim(false); 
	}

	public void Zero(Action<int> printNumber)
	{
		for (int i = 0; i < n; i++)
		{
			_zeroEvent.Wait(); 
			printNumber(0);
			_zeroEvent.Reset();
			
			if (current++ % 2 == 0)
				_evenEvent.Set();
			else 
				_oddEvent.Set();
		}
	
	}

	public void Even(Action<int> printNumber)
	{
		for (int val = 2; val <= n; val += 2) 
		{
			_evenEvent.Wait();
			printNumber(val); 
			_zeroEvent.Set(); 
			_evenEvent.Reset(); 
		}
	}

	public void Odd(Action<int> printNumber)
	{	
		for (int val = 1; val <= n; val += 2)
		{
			_oddEvent.Wait();
			printNumber(val);
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
[InlineData(100)]
[InlineData(1000)]
void Test(int n) 
{
	ZeroEvenOdd z = new ZeroEvenOdd(n);
	Console.WriteLine($"Processing n:{n}");
	Action<int> printNumber = (n) => Console.Write(n);
	Task[] tasks = new Task[] 
	{
		Task.Run (() => z.Odd(x => printNumber(x))),
		Task.Run (() => z.Even(x => printNumber(x))),
		Task.Run (() => z.Zero(x => printNumber(x)))
	}; 
	Task.WaitAll(tasks); 
	Console.WriteLine(); 
}
