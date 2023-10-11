<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Foo
{
	public ManualResetEventSlim slimEvent { get; set; }
	public ManualResetEventSlim secondslimEvent { get; set; }
	
	public Foo()
	{
		slimEvent = new ManualResetEventSlim(false);
		secondslimEvent = new ManualResetEventSlim(false);
	}

	public void First(Action printFirst)
	{
		// printFirst() outputs "first". Do not change or remove this line.
		printFirst();
		slimEvent.Set();
	}

	public void Second(Action printSecond)
	{
		slimEvent.Wait();
		// printSecond() outputs "second". Do not change or remove this line.
		printSecond();
		secondslimEvent.Set(); 
	}

	public void Third(Action printThird)
	{
		secondslimEvent.Wait(); 

		// printThird() outputs "third". Do not change or remove this line.
		printThird();
	}
}

public class FooCaller 
{
	public static void DoTheFoo(int[] schedule)
	{
		Foo foo = new Foo();
		foreach (int pos in schedule)
		{
			switch(pos) 
			{
				case 1: 
					Task.Run (() => foo.First (PrintFirst));
					break;
				case 2: 
					Task.Run (() =>foo.Second(PrintSecond));
					break;
				case 3:
					Task.Run (() =>foo.Third(PrintThird));
					break;
			}
		}
	}

	private static void PrintFirst() 
	{
		Console.Write("first");
	}
	
	private static void PrintSecond()
	{
		Console.Write("second");
	}
	
	private static void PrintThird()
	{
		Console.Write("third");
	}
}


[Theory]
[InlineData(new[] { 1, 2, 3})]
[InlineData(new[] { 1, 3, 2})]
[InlineData(new[] { 2, 1, 3})]
[InlineData(new[] { 2, 3, 1})]
[InlineData(new[] { 3, 1, 3 })]
[InlineData(new[] { 3, 2, 1 })]
void Test(int[] nums)
{
	FooCaller.DoTheFoo(nums);
	Console.WriteLine(); 
}

