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
[InlineData(1, "01")]
[InlineData(2, "0102")]
[InlineData(5, "0102030405")]
[InlineData(19, "010203040506070809010011012013014015016017018019")]
void Test(int n, string expected) 
{
	ZeroEvenOdd z = new ZeroEvenOdd(n);
	Console.WriteLine($"Processing n:{n}");
	using (StringWriter sw = new StringWriter())
	{
		TextWriter defaultConsoleOut = Console.Out;
		string output = ""; 
		try 
		{
			Console.SetOut(sw); 
			Action<int> printNumber = (n) => Console.Write(n);
			Task[] tasks = new Task[]
			{
				Task.Run (() => z.Odd(x => printNumber(x))),
				Task.Run (() => z.Even(x => printNumber(x))),
				Task.Run (() => z.Zero(x => printNumber(x)))
			};
			Task.WaitAll(tasks);
			output = sw.ToString();
			sw.Close(); 
		}
		finally 
		{
			Console.SetOut(defaultConsoleOut); 	
		}
		
		
		Assert.Equal(output, expected); 
	}

	//Console.WriteLine(); 
}

[Theory]
[InlineData(100, "0910920930940950960970980990100")]
[InlineData(1000, "099609970998099901000")]
void BigTest(int n, string expectedEnd)
{
	const string expectedBegin = "01020304050607"; 
	ZeroEvenOdd z = new ZeroEvenOdd(n);
	Console.WriteLine($"Processing n:{n}");
	using (StringWriter sw = new StringWriter())
	{
		TextWriter defaultConsoleOut = Console.Out;
		string output = "";
		try 
		{
			Console.SetOut(sw);
			Action<int> printNumber = (n) => Console.Write(n);
			Task[] tasks = new Task[]
			{
				Task.Run (() => z.Odd(x => printNumber(x))),
				Task.Run (() => z.Even(x => printNumber(x))),
				Task.Run (() => z.Zero(x => printNumber(x)))
			};
			Task.WaitAll(tasks);
			output = sw.ToString();
		}
		finally 
		{
			Console.SetOut(defaultConsoleOut);
		}
		
		Assert.True(output.StartsWith(expectedBegin));
		Assert.True(output.EndsWith(expectedEnd));
	}
	//Console.WriteLine();
}

[Fact]
public void TestConsoleOutput()
{
	// Arrange: Redirect Console.Out to a StringWriter
	using (StringWriter sw = new StringWriter())
	{
		Console.SetOut(sw);

		// Act: Run your test code that writes to the console
		YourTestCode();

		// Assert: Check the captured output
		string consoleOutput = sw.ToString();
		Assert.Contains("expected text", consoleOutput);
	} // StringWriter is automatically disposed, which restores Console.Out
}

// Replace this with your actual test code that writes to the console
private void YourTestCode()
{
	Console.WriteLine("expected text");
}
