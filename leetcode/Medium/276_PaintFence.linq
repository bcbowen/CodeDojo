<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

Dictionary<int, int> cache = new Dictionary<int, int>(); 

public int NumWays(int n, int k)
{
	if (n < 2) return k;
	if (n == 2) return k * k;
	else
	{
		if (!cache.ContainsKey(n - 1))
		{
			cache.Add(n - 1, NumWays(n - 1, k));
		}

		if (!cache.ContainsKey(n - 2))
		{
			cache.Add(n - 2, NumWays(n - 2, k));
		}
		
		return (k - 1) * cache[n - 1] + (k - 1) * cache[n - 2]; 
	}
}

#region Tests

/*
Input: n = 3, k = 2
Output: 6
Explanation: All the possibilities are shown.
Note that painting all the posts red or all the posts green is invalid because there cannot be three posts in a row with the same color.
Example 2:

Input: n = 1, k = 1
Output: 1
Example 3:

Input: n = 7, k = 2
Output: 42
*/

[Theory]
[InlineData(3, 2, 6)]
[InlineData(1, 1, 1)]
[InlineData(7, 2, 42)]
void Test(int n, int k, int expected) 
{
	int result = NumWays(n, k);
	Assert.Equal(expected, result);
}

#endregion