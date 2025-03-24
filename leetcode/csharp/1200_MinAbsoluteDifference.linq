<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<IList<int>> MinimumAbsDifference(int[] arr)
{
	Array.Sort(arr); 
	int minDiff = int.MaxValue;
	Dictionary<int, IList<IList<int>>> diffs = new Dictionary<int, IList<IList<int>>>(); 
	int diff;
	for(int i = 1; i < arr.Length; i++) 
	{
		diff = arr[i] - arr[i - 1];
		if (!diffs.ContainsKey(diff)) 
		{
			diffs[diff] = new List<IList<int>>();
		}
		diffs[diff].Add(new List<int>{arr[i - 1], arr[i]});
		minDiff = Math.Min(minDiff, diff);
	}
	return diffs[minDiff]; 
}


#region private::Tests

/*
Input: arr = [4,2,1,3]
Output: [[1,2],[2,3],[3,4]]
Explanation: The minimum absolute difference is 1. List all pairs with difference equal to 1 in ascending order.

Example 2:
Input: arr = [1,3,6,10,15]
Output: [[1,3]]

Example 3:
Input: arr = [3,8,-10,23,19,-4,-14,27]
Output: [[-14,-10],[19,23],[23,27]]
*/

[Theory]
[InlineData(new[] {4,2,1,3}, new[] {1, 2}, new[] {2, 3}, new[] {3, 4})]
[InlineData(new[] {1,3,6,10,15}, new[] {1, 3})]
[InlineData(new[] {3,8,-10,23,19,-4,-14,27}, new[] {-14,-10}, new[] {19, 23}, new[] {23, 27})]
void Test(int[] arr, params int[][] expected)
{
	IList<IList<int>> result = MinimumAbsDifference(arr);
	List<List<int>> expectedList = new List<List<int>>();

	Assert.Equal(expected.ToList(), result);
}

#endregion