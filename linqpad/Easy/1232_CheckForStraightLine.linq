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
	// y1=m*x1+b
	// y2=m*x2+b
	// y1-y2=m*(x1-x2)
	// m=(y1-y2)/(x1-x2)
	// b=y1-m*x1;
	public bool CheckStraightLine(int[][] coordinates)
	{
		if (coordinates.Length == 2) return true;

		int x1 = coordinates[0][0];
		int x2 = coordinates[1][0];
		
		if (x1 == x2)
		{
			// horizontal line
			foreach(int[] point in coordinates)
			{
				if(point[0] != x1) return false;
			}
			return true;
		}

		int y1 = coordinates[0][1];
		int y2 = coordinates[1][1];
		if (y1 == y2)
		{
			// vertical line		
			foreach (int[] point in coordinates)
			{
				if (point[1] != y1) return false;
			}
			return true;
		}

		// m=(y1-y2)/(x1-x2)
		// b=y1-m*x1;
		double m = ((double)y1 - y2) / (x1 - x2);
		double b = y1 - m * x1;
		for(int i = 2; i < coordinates.Length; i++) 
		{
			int x = coordinates[i][0]; 
			int y = coordinates[i][1];
			if (b != y - m * x) return false;
		}
		return true;
	}
}

/*
Input: coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
Output: true

Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
Output: false


[[0,0],[0,1],[0,-1]]
true

[[2,1],[4,2],[6,3]]
true

*/

[Theory]
[InlineData(true, new[] {1, 2}, new[] {2, 3}, new[] {3, 4}, new[] {4, 5}, new[] {5, 6}, new[] {6, 7})]
[InlineData(false, new[] {1, 1}, new[] {2, 2}, new[] {3, 4}, new[] {4, 5}, new[] {5, 6}, new[] {7, 7})]
[InlineData(true, new[] {0, 0}, new[] {0, 1}, new[] {0, -1})]
[InlineData(true, new[] {2, 1}, new[] {4, 2}, new[] {6, 3})]
void Tests(bool expected, params int[][] coordinates) 
{
	bool result = new Solution().CheckStraightLine(coordinates); 
	Assert.Equal(expected, result);
}
