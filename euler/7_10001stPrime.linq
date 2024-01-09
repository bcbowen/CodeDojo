<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	int n = 10001;
	int result = FindPrime(n);
	Console.WriteLine($"Prime {n}: {result}"); 
}

int FindPrime(int n) 
{
	int count = 1; 
	if (n == 2) return count;

	int val = 1;
	while (count < n) 
	{
		val += 2; 
		if (IsPrime(val))
		{
			count++;
			//Console.WriteLine(val);
		}
	}
	
	return val;
}

bool IsPrime(int n) 
{
	if (n < 15)
	{
		return new[] { 2, 3, 5, 7, 11, 13}.Contains(n); 
	}
	
	int limit = (int)Math.Ceiling(Math.Sqrt(n));

	for (int i = 2; i <= limit; i++) 
	{
		if (n % i == 0) return false;
	}
	return true;
}



[Theory]
[InlineData(6, 13)]
[InlineData(21, 73)]
[InlineData(181, 1087)]
[InlineData(261, 1663)]
[InlineData(1000, 7919)]
void Test(int n, int expected) 
{
	int result = FindPrime(n); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData(2, true)]
[InlineData(3, true)]
[InlineData(13, true)]
[InlineData(1187, true)]
[InlineData(6113, true)]
[InlineData(4482, false)]
[InlineData(4485, false)]
[InlineData(4753, false)]
[InlineData(21269, true)]
[InlineData(1555, false)]
[InlineData(121, false)]
[InlineData(25, false)]
void PrimeTest(int n, bool expected) 
{
	bool result = IsPrime(n); 
	Assert.Equal(expected, result); 
}
