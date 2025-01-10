<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

}

public IList<int> LongestCommonSubsequence(int[][] arrays)
{
	if (arrays.Length == 1) return arrays[0];

	int[] result = arrays[0];
	for(int i = 1; i < arrays.Length; i++)
	{
		result = result.Intersect(arrays[i]).ToArray(); 
	}
		
	return result;
}

/*
Input: arrays = [[1,3,4],
                 [1,4,7,9]]
Output: [1,4]

Input: arrays = [[2,3,6,8],
                 [1,2,3,5,6,7,10],
                 [2,3,4,6,9]]
Output: [2,3,6]

Input: arrays = [[1,2,3,4,5],
                 [6,7,8]]
Output: []
				 
input: [[1,2,3,4,5,6,7,9,10],
		[1,3,4,5,7,8,9,10],
		[1,2,6,7,8,10],
		[1,2,3,4,5,6,7,8,9,10],
		[2,4,5,6,7,8,9,10],
		[2,6,7,8,9]]
		
Output: [7]
*/

[Theory]
[InlineData(new[] { 7 }, new[] { 1, 2, 3, 4, 5, 6, 7, 9, 10 }, new[] { 1, 3, 4, 5, 7, 8, 9, 10 }, new[] { 1, 2, 6, 7, 8, 10 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new[] { 2, 4, 5, 6, 7, 8, 9, 10 }, new[] { 2, 6, 7, 8, 9 })]
[InlineData(new[] { 1, 4 }, new[] { 1, 3, 4 }, new[] { 1, 4, 7, 9 })]
[InlineData(new[] { 2, 3, 6 }, new[] { 2, 3, 6, 8 }, new[] { 1, 2, 3, 5, 6, 7, 10 }, new[] { 2, 3, 4, 6, 9 })]
[InlineData(new int[0], new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8 })]
void Test(int[] expected, params int[][] input)
{
	int[] result = LongestCommonSubsequence(input).ToArray();

	Array.Sort(expected);
	Array.Sort(result);

	Assert.Equal(expected, result);
}

