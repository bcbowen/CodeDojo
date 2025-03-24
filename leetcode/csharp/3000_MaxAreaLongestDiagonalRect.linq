<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int AreaOfMaxDiagonal(int[][] dimensions)
{
	double maxLength = 0;
	int maxArea = 0;
	foreach(int[] pair in dimensions) 
	{
		double length = Math.Sqrt(Math.Pow(pair[0], 2) + Math.Pow(pair[1], 2));
		if (length >= maxLength) 
		{
			int area = pair[0] * pair[1];
			if (length == maxLength) 
			{
				maxArea = Math.Max(maxArea, area);
			}
			else 
			{
				maxArea = area; 
				maxLength = length; 
			}
		}
		
		
	}
	
	return maxArea; 
}

/*
Example 1:
Input: dimensions = [[9,3],[8,6]]
Output: 48
Explanation: 
For index = 0, length = 9 and width = 3. Diagonal length = sqrt(9 * 9 + 3 * 3) = sqrt(90) ≈ 9.487.
For index = 1, length = 8 and width = 6. Diagonal length = sqrt(8 * 8 + 6 * 6) = sqrt(100) = 10.
So, the rectangle at index 1 has a greater diagonal length therefore we return area = 8 * 6 = 48.

Example 2:
Input: dimensions = [[3,4],[4,3]]
Output: 12
Explanation: Length of diagonal is the same for both which is 5, so maximum area = 12.

[[2,6],[5,1],[3,10],[8,4]]
30

*/

[Theory]
[InlineData(48, new[] {9, 3 }, new[] {8, 6})]
[InlineData(12, new[] {3, 4 }, new[] {4, 3})]
[InlineData(30, new[] {2, 6 }, new[] {5, 1}, new[] {3, 10}, new[] {8, 4})]
void Test(int expected, params int[][] dimensions) 
{
	int result = AreaOfMaxDiagonal(dimensions); 
	Assert.Equal(expected, result); 
}

