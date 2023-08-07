<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool SearchMatrix(int[][] matrix, int target)
{
	int end = matrix[0].Length - 1;
	foreach(int[] row in matrix)
	{
		if (row[end] == target || row[0] == target)
		{
			return true;
		}
		else if (row[end] > target)
		{
			return SearchRow(row, target); 
		} 
		
	}
	return false;
	
}
internal bool SearchRow(int[] row, int target) 
{
	if (row.Length == 0) return false;
	if (row.Length == 1) return row[0] == target;
	int mid = row.Length / 2;
	if (row[mid] == target) return true;
	if (row[mid] < target)
	{ 
		int[] subarray = new int[row.Length - mid]; 
		Array.Copy(row, mid, subarray, 0, subarray.Length);
		return SearchRow(subarray, target);
	}
	else
	{
		int[] subarray = new int[mid];
		Array.Copy(row, 0, subarray, 0, subarray.Length);
		return SearchRow(subarray, target);
	}
}
#region private::Tests

[Theory]
[InlineData(3, true, new[] {1, 3, 5, 7}, new[] {10, 11, 16, 20}, new[] {23, 30, 34, 60})]
[InlineData(13, false, new[] {1, 3, 5, 7}, new[] {10, 11, 16, 20}, new[] {23, 30, 34, 60})]
void Test(int target, bool expected, params int[][] matrix) 
{
	bool result = SearchMatrix(matrix, target); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData(new[] {1, 3, 5, 7}, 1, true)]
[InlineData(new[] {1, 3, 5, 7}, 0, false)]
[InlineData(new[] {1, 3, 5, 7}, 9, false)]
[InlineData(new[] {1, 3, 5, 7}, 3, true)]
[InlineData(new[] {1, 3, 5, 7}, 5, true)]
[InlineData(new[] {1, 3, 5, 7}, 7, true)]
[InlineData(new[] {1, 3, 5, 7, 9}, 5, true)]
[InlineData(new[] {1, 3, 5, 7, 9}, 3, true)]
[InlineData(new[] {1, 3, 5, 7, 9}, 7, true)]
[InlineData(new[] {1, 3, 5, 7, 9}, 4, false)]
[InlineData(new[] {1, 3, 5, 7, 9}, 6, false)]
void SearchRowTest(int[] row, int target, bool expected) 
{
	bool result = SearchRow(row, target); 
	Assert.Equal(expected, result); 
}

#endregion