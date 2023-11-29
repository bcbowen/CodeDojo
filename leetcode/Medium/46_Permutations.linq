<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<IList<int>> Permute(int[] nums)
{
	IList<IList<int>> result = new List<IList<int>>();
	List<int> numsList = nums.ToList(); 
	int n = nums.Length; 
	BackTrack(n, numsList, result, 0); 
	return result; 
}

private void BackTrack(int n, List<int> nums, IList<IList<int>> output, int first) 
{
	// if all ints are used up
	if (first == n) output.Add(new List<int>(nums));

	for (int i = first; i < n; i++) 
	{
		Swap(nums, first, i);
		BackTrack(n, nums, output, first + 1); 
		Swap(nums, first, i); 
	}
}

private void Swap(List<int> nums, int i, int j)
{
	int temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}

/*
Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
*/

[Theory]
[InlineData(new int[] { 1, 2, 3 },
	new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 },
	new int[] { 2, 1, 3 }, new int[] { 2, 3, 1 },
	new int[] { 3, 1, 2 }, new int[] { 3, 2, 1 })]
[InlineData(new int[] { 0, 1 },
	new int[] { 0, 1 }, new int[] { 1, 0 })]
[InlineData(new int[] { 1 }, new int[] { 1 })]
void Test(int[] nums, params int[][] expected)
{
	IList<IList<int>> result = Permute(nums);
	int[][] resultArray = result.Select(r => r.ToArray()).ToArray(); 
	Assert.Equal(expected.Length, result.Count);
	foreach(int[] row in expected) 
	{
		List<int> rowList = row.ToList(); 
		Assert.Contains(rowList, resultArray.Select(r => r.ToList() )); 
	}
}

