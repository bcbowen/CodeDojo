<Query Kind="Program">
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

	public FooBar(int n)
	{
		this.n = n;
	}

	public void Foo(Action printFoo)
	{

		for (int i = 0; i < n; i++)
		{

			// printFoo() outputs "foo". Do not change or remove this line.
			printFoo();
		}
	}

	public void Bar(Action printBar)
	{

		for (int i = 0; i < n; i++)
		{

			// printBar() outputs "bar". Do not change or remove this line.
			printBar();
		}
	}
}

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
