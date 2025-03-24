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
	public int Tribonacci(int n)
	{
		if (n < 3) return n < 2 ? n : 1;
		

		int[] tribs = new int[n + 1];
		tribs[0] = 0; 
		tribs[1] = 1; 
		tribs[2] = 1;

		for(int i = 3; i < tribs.Length; i++) 
		{
			tribs[i] = tribs[i - 3] + tribs[i - 2] + tribs[i - 1];
		}
		
		return tribs[tribs.Length - 1];
	}
}

#region Tests

[Theory]
[InlineData(0, 0)]
[InlineData(1, 1)]
[InlineData(2, 1)]
[InlineData(4, 4)]
[InlineData(25, 1389537)]
void Test(int n, int expected) 
{
	int result = new Solution().Tribonacci(n); 
	Assert.Equal(expected, result);
}
/*
Example 1:
Input: n = 4
Output: 4
Explanation:
T_3 = 0 + 1 + 1 = 2
T_4 = 1 + 1 + 2 = 4

Example 2:
Input: n = 25
Output: 1389537
*/
#endregion