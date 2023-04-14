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
	private int[][] _matrix;
	private int _target;

	public bool SearchMatrix(int[][] matrix, int target)
	{
		_matrix = matrix;
		_target = target;

		int top = 0;
		int bottom = matrix.Length;
		int left = 0; 
		int right = matrix[0].Length; 

		return Find(top, bottom, left, right); 

	}


	/// <summary>
	/// 1. If the target is less than the min value in the mid column, search a single area to the left of the mid column
	/// 2. If the target is greater than the max value in the mid column, search a single area to the right of the mid column
	/// 3. If the target is found on the mid column ... yada yada yada
	/// 4. If the target is between the min and max values, there will be an area to the lower left and upper right to search
	/// </summary>
	internal bool Find(int top, int bottom, int left, int right) 
	{
		int mid = right == left ? right : (left + right - left) / 2;

		// if target less than the min value in the mid column, the value has to be to the left if it exists
		if (_target < _matrix[0][mid]) 
		{
			if (mid == right) return false; // only one column and the target is less then the min value
			
			return Find(top, bottom, left, mid - 1); 
		}

		// if target greater than max value in the mid column, the value has to be on the right if it exists
		if (_target > _matrix[bottom][mid]) 
		{
			if (mid == right) return false; // only one column and target is more than max value
			
			return Find(top, bottom, mid + 1, right); 
		}
		
		// target beween min and max in the mid column, target will be on the column, 
		// to the lower left, or upper right if it exists
		// Find where the value > _target, that will be the division
		for (int i = top; i < bottom; i++)
		{
			if (_matrix[i][mid] == _target) return true;

			if (_matrix[i][mid] > _target) 
			{
				bool found; 
				int newTop, newBottom, newLeft, newRight; 
				// first area: lower left of current cell
				newTop = i + 1;
				newBottom = bottom; 
				newLeft = left; 
				newRight = mid - 1;
				found = Find(newTop, newBottom, newLeft, newRight); 
				
				if (found) return true; 
				
				// second area, upper right of current cell
				newTop = top; 
				newBottom = i - 1; 
				newLeft = mid + 1; 
				newRight = right;
				return Find(newTop, newBottom, newLeft, newRight); 
			}
		}
		
		return false;
	}
}

/*
Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
Output: true

Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 20
Output: false
*/

[Theory]
[InlineData(true, 5, new[] {1,4,7,11,15}, new[] {2,5,8,12,19}, new[] {3,6,9,16,22}, new[] {10,13,14,17,24}, new[] {18,21,23,26,30})]
[InlineData(false, 20, new[] {1,4,7,11,15}, new[] {2,5,8,12,19}, new[] {3,6,9,16,22}, new[] {10,13,14,17,24}, new[] {18,21,23,26,30})]
void Test(bool expected, int target, params int[][] matrix) 
{
	bool result = new Solution().SearchMatrix(matrix, target); 
	Assert.Equal(expected, result);
}

