<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	
	long largestFactor = new Solution().GetLargestFactor(600851475143); 
	largestFactor.Dump(); 
}

class Solution{

	public long GetLargestFactor(long val)
	{
		long[] factors = GetPrimeFactors(val); 
		return factors.Max(); 
	}

	internal long[] GetPrimeFactors(long a)
	{
		List<long> factors = new List<long>();
		long mid = a / 2;
		for (long i = 2; i < mid; i++)
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

	internal bool IsPrime(long l)
	{
		long[] tinyPrimes = {1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29}; 
		if (tinyPrimes.Contains(l)) return true;
		if (l < 30) return false; 
		
		int limit = (int)Math.Ceiling(Math.Sqrt(l)); 
		for (int i = 2; i <= limit; i++) 
		{
			if (l % i == 0) return false;
		}
		
		return true;
	}
}


/*
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*/

[Theory]
[InlineData(13195, 29)]
void Test(long num, long expected) 
{
	long result = new Solution().GetLargestFactor(num); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData(13195, new long[] {5, 7, 13, 29})]
void GetPrimeFactorsTest(long val, long[] expected) 
{
	long[] result = new Solution().GetPrimeFactors(val); 
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
	bool result = new Solution().IsPrime(val);
	Assert.Equal(expected, result);
}
