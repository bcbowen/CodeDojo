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
	public int ClimbStairs(int n)
	{
		if (n == 1) return n;
		
		int[] results = new int[n + 1];
		
		int index = 1; 
		results[index++] = 1;
		results[index++] = 2;
		while (index <= n) 
		{
			results[index] = results[index - 1] + results[index - 2]; 
			index++;
		}
		
		return results[n]; 
	}
}

#region Tests

[Theory]
[InlineData(2, 2)]
[InlineData(3, 3)]
void Test(int n, int expected) 
{
	int result = new Solution().ClimbStairs(n);
	Assert.Equal(expected, result);
}
/*
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

*/
#endregion