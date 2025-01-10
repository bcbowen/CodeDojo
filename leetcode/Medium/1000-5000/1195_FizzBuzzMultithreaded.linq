<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class FizzBuzz
{
	private int n;
	SemaphoreSlim fizz; 
	SemaphoreSlim buzz; 
	SemaphoreSlim fizzBuzz; 
	SemaphoreSlim noa; 


	public FizzBuzz(int n)
	{
		this.n = n;
		fizz = new SemaphoreSlim(0, 1); 
		buzz = new SemaphoreSlim(0, 1); 
		fizzBuzz = new SemaphoreSlim(0, 1);
		noa = new SemaphoreSlim(1, 1); 
	}

	// printFizz() outputs "fizz".
	public void Fizz(Action printFizz)
	{
		for (int i = 3; i <= n; i += 3)
		{
			if (i % 5 != 0)
			{
				fizz.Wait();
				printFizz(); 
				noa.Release(); 
			}
		}
	}

	// printBuzzz() outputs "buzz".
	public void Buzz(Action printBuzz)
	{
		for (int i = 5; i <= n; i += 5)
		{
			if (i % 3 != 0)
			{
				buzz.Wait();
				printBuzz();
				noa.Release();
			}
		}
	}

	// printFizzBuzz() outputs "fizzbuzz".
	public void Fizzbuzz(Action printFizzBuzz)
	{
		for (int i = 15; i <= n; i += 15)
		{
			fizzBuzz.Wait();
			printFizzBuzz();
			noa.Release();			
		}
	}

	// printNumber(x) outputs "x", where x is an integer.
	public void Number(Action<int> printNumber)
	{
		for (int i = 1; i <= n; i++)
		{
			noa.Wait();
			if (i % 15 == 0)
			{
				fizzBuzz.Release();
			}
			else if (i % 5 == 0) 
			{
				buzz.Release();
			}
			else if (i % 3 == 0)
			{
				fizz.Release();
			}
			else 
			{
				printNumber(i);
				noa.Release();
			}
		}
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion