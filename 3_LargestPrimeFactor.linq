<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

internal static long GetLargestFactor(long val)
{
	long[] factors = GetPrimeFactors(val);
	return factors.Max();
}

internal static long[] GetPrimeFactors(long a)
{


	List<long> factors = new List<long>();
	while (a % 2 == 0)
	{
		factors.Add(2);
		a /= 2;
	}

	if (IsPrime(a)) 
	{
		factors.AddRange( new [] {1, a } );
		return factors.ToArray();
	}
	
	
	long mid = a / 2;
	for (long i = 3; i <= mid; i += 2)
	{
		while ((a % i) == 0)
		{
			factors.Add(i);
			a /= i;
		}
		if (a == 1) break;
	}

	return factors.ToArray();
}

internal static bool IsPrime(long l)
{
	long[] tinyPrimes = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
	if (tinyPrimes.Contains(l)) return true;
	if (l < 30) return false;

	int limit = (int)Math.Ceiling(Math.Sqrt(l));
	for (int i = 2; i <= limit; i++)
	{
		if (l % i == 0) return false;
	}

	return true;
}

/*
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*/

[Theory]
[InlineData(13195, 29)]
[InlineData(10, 5)]
[InlineData(17, 17)]
void Test(long num, long expected)
{
	long result = GetLargestFactor(num);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(13195, new long[] { 5, 7, 13, 29 })]
void GetPrimeFactorsTest(long val, long[] expected)
{
	long[] result = GetPrimeFactors(val);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(1, true)]
[InlineData(2, true)]
[InlineData(4, false)]
[InlineData(3, true)]
[InlineData(13, true)]
[InlineData(19, true)]
[InlineData(76, false)]
[InlineData(89, true)]
[InlineData(97, true)]
[InlineData(7901, true)]
[InlineData(7902, false)]
[InlineData(8633, false)]
[InlineData(200560490131, true)]
[InlineData(87178291199, true)]
[InlineData(600851475143, false)]
void IsPrimeTest(long val, bool expected)
{
	bool result = IsPrime(val);
	Assert.Equal(expected, result);
}
