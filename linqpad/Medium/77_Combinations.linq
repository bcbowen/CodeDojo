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
	public IList<IList<int>> Combine(int n, int k)
	{
		List<IList<int>> result = new List<IList<int>>();
		HashSet<(int, int)> found = new HashSet<(int, int)>();

		if (n == 1 && k == 1)
		{
			result.Add(new List<int>() { 1 });
		}
		else
		{
			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= n; j++)
				{
					if (i == j) continue;
					int min = Math.Min(i, j);
					int max = Math.Max(i, j);
					if (!found.Contains((min, max)))
					{
						found.Add((min, max));
						result.Add(new List<int> { min, max });
					}
				}
			}
		}

		return result;
	}
}

/*
Example 1:
Input: n = 4, k = 2
Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
Explanation: There are 4 choose 2 = 6 total combinations.
Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.

Example 2:
Input: n = 1, k = 1
Output: [[1]]
Explanation: There is 1 choose 1 = 1 total combination.
*/

[Theory]
[InlineData(4, 2, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 1, 4 }, new[] { 2, 3 }, new[] { 2, 4 }, new[] { 3, 4 })]
[InlineData(1, 1, new[] { 1 })]
void Test(int n, int k, params int[][] expected)
{
	IList<IList<int>> result = new Solution().Combine(n, k);
	Assert.Equal(expected, result);
}
