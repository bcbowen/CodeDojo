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
	public IList<IList<int>> Generate(int numRows)
	{
		IList<IList<int>> triangle = new List<IList<int>>();
		for (int i = 0; i < numRows; i++)
		{
			List<int> row = new List<int>(i + 1);

			row.Add(1);
			if (i > 1)
			{
				for (int j = 1; j < triangle[i - 1].Count; j++)
				{
					row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
				}
			}
			if (i > 0) row.Add(1);
			triangle.Add(row);
		}

		return triangle;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
/*
Example 1:

Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
Example 2:

Input: numRows = 1
Output: [[1]]
*/
[Theory]
[InlineData(1, new[] { 1 })]
[InlineData(2, new[] { 1 }, new[] { 1, 1 })]
[InlineData(3, new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 })]
[InlineData(4, new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 })]
[InlineData(5, new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 }, new[] { 1, 4, 6, 4, 1 })]
[InlineData(6, new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 }, new[] { 1, 4, 6, 4, 1 }, new[] { 1, 5, 10, 10, 5, 1 })]
void Test(int numRows, params int[][] expected)
{
	IList<IList<int>> result = new Solution().Generate(numRows);
	Assert.Equal(expected, result.ToArray());
}

#endregion