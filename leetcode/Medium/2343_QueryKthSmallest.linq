<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
{
	PriorityQueue<(int, int), int> heap = new PriorityQueue<(int, int), int>();
	int[] result = new int[queries.Length];
	foreach(int[] query in queries) 
	{
		heap.Clear();
		foreach(string num in nums) 
		{
			int value = num.Length 
		}
	}

	return result;
}

#region private::Tests

/*
Example 1:

Input: nums = ["102","473","251","814"], queries = [[1,1],[2,3],[4,2],[1,2]]
Output: [2,2,1,0]
Explanation:
1. After trimming to the last digit, nums = ["2","3","1","4"]. The smallest number is 1 at index 2.
2. Trimmed to the last 3 digits, nums is unchanged. The 2nd smallest number is 251 at index 2.
3. Trimmed to the last 2 digits, nums = ["02","73","51","14"]. The 4th smallest number is 73.
4. Trimmed to the last 2 digits, the smallest number is 2 at index 0.
   Note that the trimmed number "02" is evaluated as 2.
Example 2:

Input: nums = ["24","37","96","04"], queries = [[2,1],[2,2]]
Output: [3,0]
Explanation:
1. Trimmed to the last digit, nums = ["4","7","6","4"]. The 2nd smallest number is 4 at index 3.
   There are two occurrences of 4, but the one at index 0 is considered smaller than the one at index 3.
2. Trimmed to the last 2 digits, nums is unchanged. The 2nd smallest number is 24.
*/

[Theory]
[InlineData(new[] { "102", "473", "251", "814" }, new[] { 2, 2, 1, 0 }, new[] { 1, 1 }, new[] { 2, 3 }, new[] { 4, 2 }, new[] { 1, 2 })]
[InlineData(new[] { "24", "37", "96", "04" }, new[] { 3, 0 }, new[] { 2, 1 }, new[] { 2, 2 })]
void Test(string[] nums, int[] expected, params int[][] queries)
{
	int[] result = SmallestTrimmedNumbers(nums, queries);
	Assert.Equal(expected, result);
}

#endregion