<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int HeightChecker(int[] heights)
{
	//return CheatSolution(heights);
	return BubbleSortSolution(heights); 
}

private int BubbleSortSolution(int[] heights) 
{
	int[] sorted = new int[heights.Length];
	bool isSorted = true;
	int last = heights[0]; 
	sorted[0] = last;
	for (int i = 1; i < heights.Length; i++) 
	{
		if (heights[i] < last) isSorted = false;
		sorted[i] = heights[i]; 
		last = heights[i]; 
	}
	if (isSorted) return 0;
	
	bool swapped = false;
	do
	{
		swapped = false;
		for (int i = 1; i < sorted.Length; i++)
		{
			if (sorted[i] < sorted[i - 1]) 
			{
				int temp = sorted[i]; 
				sorted[i] = sorted[i - 1]; 
				sorted[i - 1] = temp;
				swapped = true;
			}
		}
	}
	while(swapped);

	int diffs = 0;
	for (int i = 0; i < sorted.Length; i++) 
	{
		if (heights[i] != sorted[i]) diffs++;
	}
	
	return diffs;
}

/// <summary>Original solutin which is kind of cheating</summary>
private int CheatSolution(int[] heights) 
{
	int[] sorted = new int[heights.Length];
	Array.Copy(heights, sorted, heights.Length);
	Array.Sort(sorted);
	int result = 0;
	for (int i = 0; i < heights.Length; i++)
	{
		if (sorted[i] != heights[i]) result++;
	}
	return result;
}

#region private::Tests

/*
Example 1:
Input: heights = [1,1,4,2,1,3]
Output: 3
Explanation: 
heights:  [1,1,4,2,1,3]
expected: [1,1,1,2,3,4]
Indices 2, 4, and 5 do not match.

Example 2:
Input: heights = [5,1,2,3,4]
Output: 5
Explanation:
heights:  [5,1,2,3,4]
expected: [1,2,3,4,5]
All indices do not match.

Example 3:
Input: heights = [1,2,3,4,5]
Output: 0
Explanation:
heights:  [1,2,3,4,5]
expected: [1,2,3,4,5]
All indices match.
*/

[Theory]
[InlineData(new[] { 1,1,4,2,1,3}, 3)]
[InlineData(new[] { 5,1,2,3,4}, 5)]
[InlineData(new[] { 1,2,3,4,5 }, 0)]
void Test(int[] heights, int expected) 
{
	int result = HeightChecker(heights); 
	Assert.Equal(expected, result); 
}

#endregion