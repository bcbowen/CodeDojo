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
	public IList<int> Generate(int rowIndex)
	{
		List<int> last = null;
		List<int> row = null;
		for (int i = 0; i <= rowIndex; i++)
		{
			row = new List<int>(i + 1);

			row.Add(1);
			if (i > 1)
			{
				for (int j = 1; j < last.Count; j++)
				{
					row.Add(last[j - 1] + last[j]);
				}
			}
			if (i > 0) row.Add(1);
			last = row;
		}

		return row;
	}
}

#region private::Tests


/*
Input: rowIndex = 3
Output: [1,3,3,1]
Example 2:

Input: rowIndex = 0
Output: [1]
Example 3:

Input: rowIndex = 1
Output: [1,1]
*/
[Theory]
[InlineData(0, new[] { 1 })]
[InlineData(1, new[] { 1, 1 })]
[InlineData(2, new[] { 1, 2, 1 })]
[InlineData(3, new[] { 1, 3, 3, 1 })]
[InlineData(4, new[] { 1, 4, 6, 4, 1 })]
[InlineData(5, new[] { 1, 5, 10, 10, 5, 1 })]
void Test(int numRows, int[] expected)
{
	IList<int> result = new Solution().Generate(numRows);
	Assert.Equal(expected, result.ToArray());
}

#endregion