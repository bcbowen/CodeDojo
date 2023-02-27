<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	/*
	Example 1:

	Input: x = 3, y = 4, points = [[1,2],[3,1],[2,4],[2,3],[4,4]]
	Output: 2
	Explanation: Of all the points, only [3,1], [2,4] and [4,4] are valid. Of the valid points, [2,4] and [4,4] have the smallest Manhattan distance from your current location, with a distance of 1. [2,4] has the smallest index, so return 2.
	Example 2:

	Input: x = 3, y = 4, points = [[3,4]]
	Output: 0
	Explanation: The answer is allowed to be on the same location as your current location.
	Example 3:

	Input: x = 3, y = 4, points = [[2,3]]
	Output: -1
	Explanation: There are no valid points.
	*/
}

[Theory]
[InlineData(3, 4, 2,
	new[] { 1, 2 },
	new[] { 3, 1 },
	new[] { 2, 4 },
	new[] { 2, 3 },
	new[] { 4, 4 }
	)]
[InlineData(3, 4, 0,
	new[] { 3, 4 }
	)]
[InlineData(3, 4, -1,
	new[] { 2, 3 }
	)]
void NearestPointTests(int x, int y, int expected, params int[][] points)
{
	int result = new Solution().NearestValidPoint(x, y, points);
	Assert.Equal(expected, result);
}

public class Solution
{
	public int NearestValidPoint(int x, int y, int[][] points)
	{
		int mindex = -1;
		double minDistance = double.MaxValue;
		for (int i = 0; i < points.Length; i++)
		{
			if (points[i][0] == x || points[i][1] == y)
			{
				double distance = CalcDistance(x, y, points[i][0], points[i][1]);
				if (distance < minDistance) 
				{
					mindex = i;
					minDistance = distance;
				}
			}
		}
		return mindex;
	}

	private double CalcDistance(int x1, int y1, int x2, int y2)
	{
		return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion