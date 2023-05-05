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
	public bool IsUgly(int n)
	{
		if (n < 1) return false;

		int[] factors = {2, 3, 5};

		foreach (int factor in factors)
		{
			while (n % factor == 0) 
			{
				n /= factor;
			}
		}
		
		return n == 1;
	}
}

#region private::Tests

[Theory]
[InlineData(6, true)]
[InlineData(1, true)]
[InlineData(14, false)]
[InlineData(80440, false)]
[InlineData(56380, false)]
[InlineData(24_300_000, true)]
[InlineData(-2147483648, false)]
void Test(int n, bool expected) 
{
	bool result = new Solution().IsUgly(n); 
	Assert.Equal(expected, result);	
}

/*
Example 1:

Input: n = 6
Output: true
Explanation: 6 = 2 × 3
Example 2:

Input: n = 1
Output: true
Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.
Example 3:

Input: n = 14
Output: false
Explanation: 14 is not ugly since it includes the prime factor 7.
*/

#endregion