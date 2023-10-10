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
	private int lastStep = 0; 
	public Foo()
	{

	}

	public void First(Action printFirst)
	{

		// printFirst() outputs "first". Do not change or remove this line.
		printFirst();
	}

	public void Second(Action printSecond)
	{

		// printSecond() outputs "second". Do not change or remove this line.
		printSecond();
	}

	public void Third(Action printThird)
	{

		// printThird() outputs "third". Do not change or remove this line.
		printThird();
	}
}

public class FooCaller 
{
	private Foo _foo; 
	private Action[] _invocations;
	
	public FooCaller(int[] schedule) 
	{
		_foo = new Foo();
		_invocations = new Action[3];
		_invocations[schedule[0] - 1] =  Console.WriteLine("first");
		_invocations[schedule[1] - 1] = PrintSecond;
		_invocations[schedule[2] - 1] = PrintThird;
	}

	public void DoTheFoo() 
	{
		_foo.First (() => _invocations[0]()); 
	}

	private void PrintFirst() 
	{
		Console.Write("first");
	}
	
	private void PrintSecond()
	{
		Console.Write("second");
	}
	
	private void PrintThird()
	{
		Console.Write("third");
	}
}


#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 3})]
[InlineData(new[] { 1, 3, 2})]
[InlineData(new[] { 2, 1, 3})]
[InlineData(new[] { 2, 3, 1})]
[InlineData(new[] { 3, 1, 3 })]
[InlineData(new[] { 3, 2, 1 })]
void Test(int[] nums)
{
	new FooCaller(nums);
	Console.WriteLine(); 
}

#endregion