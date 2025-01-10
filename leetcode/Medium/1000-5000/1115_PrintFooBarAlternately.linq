<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class FooBar
{
	private int n;
	private ManualResetEventSlim _fooEvent; 
	private ManualResetEventSlim _barEvent; 

	public FooBar(int n)
	{
		this.n = n;
		_fooEvent = new ManualResetEventSlim(true); 
		_barEvent = new ManualResetEventSlim(false); 
		
	}

	public void Foo(Action printFoo)
	{
		 
		for (int i = 0; i < n; i++)
		{
			_fooEvent.Wait(); 
			// printFoo() outputs "foo". Do not change or remove this line.
			printFoo();
			_barEvent.Set(); 
			_fooEvent.Reset(); 
		}
	}

	public void Bar(Action printBar)
	{
		
		for (int i = 0; i < n; i++)
		{
			_barEvent.Wait();

			// printBar() outputs "bar". Do not change or remove this line.
			printBar();
			_fooEvent.Set(); 
			_barEvent.Reset(); 
		}
	}
}


[Theory]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
[InlineData(7)]
void Test_Xunit(int n) 
{
	Console.WriteLine($"n={n}");
	FooBar f = new FooBar(n);
	Task[] tasks = new Task[]
	{
		Task.Run(() => PrintFoos(f)),
		Task.Run(() => PrintBars(f))
	}; 
	
	Task.WaitAll(tasks); 
}


private void PrintFoos(FooBar f) 
{
	f.Foo(() => Console.Write("foo")); 
}

private void PrintBars(FooBar f) 
{
	f.Bar(() => Console.Write("bar\r\n")); 	
}
