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
	for(int i = 0; i < queries.Length; i++) 
	{
		int[] query = queries[i]; 
		heap.Clear();
		for(int j = 0; j < nums.Length; j++)
		{
			string num = nums[j]; 
			int value = int.Parse(TrimNumber(num, query[1])); 
			heap.Enqueue((j, value), value); 
		}

		for(int k = 0; k < query[0]; k++) 
		{
			(result[i], _) = heap.Dequeue(); 
		}
	}

	return result;
}

internal string TrimNumber(string num, int places) 
{
	if (places == num.Length) return num; 
	if (places > num.Length) return num.PadLeft(places, '0'); 
	
	return num.Substring(num.Length - places); 
}

#region Tests

[Theory]
[InlineData("123", 2, "23")]
[InlineData("23", 2, "23")]
[InlineData("3", 2, "03")]
[InlineData("1234", 2, "34")]
[InlineData("1234", 4, "1234")]
[InlineData("1234", 5, "01234")]
[InlineData("1234", 1, "4")]



private void TrimNumberTests(string num, int places, string expected) 
{
	string result = TrimNumber(num, places); 
	Assert.Equal(expected, result); 
}

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
[InlineData(new[] { "64333639502", "65953866768", "17845691654", "87148775908", "58954177897", "70439926174", "48059986638", "47548857440", "18418180516", "06364956881", "01866627626", "36824890579", "14672385151", "71207752868" },
new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
new[] { 9, 4 },
new[] { 6, 1 },
new[] { 3, 8 },
new[] { 12, 9 },
new[] { 11, 4 },
new[] { 4, 9 },
new[] { 2, 7 },
new[] { 10, 3 },
new[] { 13, 1 },
new[] { 13, 1 },
new[] { 6, 1},
new[]{5,10})]
void Test(string[] nums, int[] expected, params int[][] queries)
{
	int[] result = SmallestTrimmedNumbers(nums, queries);
	Assert.Equal(expected, result);
}

#endregion