<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/*
F(0) = 0, F(1) = 1
F(n) = F(n - 1) + F(n - 2), for n > 1.
*/

public class Solution
{
	int[] cache; 
	public int Fib(int n)
	{
		cache = new int[n + 1];
		return Recurse(n);
	}

	internal int Recurse(int n) 
	{
		if (n <= 1) return n;
		
		if (cache[n - 1] == 0)
		{
			cache[n - 1] = Recurse(n - 1);
		}

		if (cache[n - 2] == 0)
		{ 
			cache[n - 2] = Recurse(n - 2); 			
		}
		
		return cache[n - 1] + cache[n - 2];
	}
}

#region private::Tests

/*
Example 1:
Input: n = 2
Output: 1
Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.

Example 2:
Input: n = 3
Output: 2
Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.

Example 3:
Input: n = 4
Output: 3
Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.
*/

[Theory]
[InlineData(2, 1)]
[InlineData(3, 2)]
[InlineData(4, 3)]
[InlineData(7, 13)]
[InlineData(8, 21)]
void Test(int n, int expected) 
{
	int result = new Solution().Fib(n); 
	Assert.Equal(expected, result); 
}

#endregion