<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	internal int SearchRoot(long min, long max, long x)
	{
		if (min == max) return (int)min;
		if (max - min == 1) 
		{
			if (max * max > x) return (int)min; 
			return (int)max;
		}
		
		long mid = min + (max - min) / 2; 
		
		long square = mid * mid; 
		if (square == x) return (int)mid;
		
		if (square < x) return SearchRoot(mid, max, x);
		return SearchRoot(min, mid, x);
	}

	public int MySqrt(long x)
	{
		switch (x) 
		{
			case 0: 
			case 1: 
				return (int)x; 
			case 2: 
			case 3: 
				return 1;
		}

		int max = x > int.MaxValue ? int.MaxValue : (int)x;
		return SearchRoot(2, max, x); 
		
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);


[Theory]
[InlineData(0, 0)]
[InlineData(1, 1)]
[InlineData(2, 1)]
[InlineData(3, 1)]
[InlineData(4, 2)]
[InlineData(6, 2)]
[InlineData(8, 2)]
[InlineData(10, 3)]
[InlineData(64, 8)]
[InlineData(66, 8)]
[InlineData(8192, 90)]
[InlineData(4_294_967_295, 65_535)]
/**/
void SqrtTest(long x, int expected) 
{
	int result = new Solution().MySqrt(x); 
	Assert.Equal(expected, result);
}

[Fact]
void FixProblemChild() 
{
	/*
	8192
Output
64
Expected
90
	*/
	int expected = 3; 
	int result = new Solution().MySqrt(10); 
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: x = 4
Output: 2

Example 2:
Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.
*/
#endregion