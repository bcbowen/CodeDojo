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
	public int NumSquares(int n)
	{
		if (n < 2) return 1;
		
		double root = Math.Sqrt(n);
		if (root % 1 == 0) 
		{
			return 1;
		}
		
		int count = 1; 
		root = Math.Floor(root);
		int rootSquared = (int)root * (int)root;

		while(n > rootSquared) 
		{
			count++; 
			n -= rootSquared;
		}
		
		count += NumSquares(n);
		return count;
	}
}

#region Tests

[Theory]
[InlineData(12, 3)]
[InlineData(13, 2)]
void Test(int n, int expected) 
{
	int result = new Solution().NumSquares(n); 
	Assert.Equal(expected, result);
}
/*
Example 1:
Input: n = 12
Output: 3
Explanation: 12 = 4 + 4 + 4.

Example 2:
Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
*/
#endregion