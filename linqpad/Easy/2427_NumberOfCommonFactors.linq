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
	public int CommonFactors(int a, int b)
	{
		int[] aFactors = GetFactors(a);
		int[] bFactors = GetFactors(b);

		return aFactors.Intersect(bFactors).Count();
	}

	internal int[] GetFactors(int a)
	{
		List<int> factors = new List<int>() { 1, a };
		for (int i = 2; i < a / 2; i++)
		{
			if ((a % i) == 0 && !factors.Contains(i))
			{
				factors.Add(i);
				factors.Add(a / i);
			}
		}

		return factors.ToArray();
	}
}

/*

Example 1:
Input: a = 12, b = 6
Output: 4
Explanation: The common factors of 12 and 6 are 1, 2, 3, 6.

Example 2:
Input: a = 25, b = 30
Output: 2
Explanation: The common factors of 25 and 30 are 1, 5.

*/

[Theory]
[InlineData(12, 6, 4)]
[InlineData(25, 30, 2)]
void Test(int a, int b, int expected) 
{
	int result = new Solution().CommonFactors(a, b);
	Assert.Equal(result, expected); 
}

