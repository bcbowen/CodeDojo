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
	int[] sortedHeights = new int[heights.Length]; 
	heights.CopyTo(sortedHeights, 0); 
	Array.Sort(sortedHeights);
	int result = 0;
	for(int i = 0; i < heights.Length; i++) 
	{
		if (sortedHeights[i] != heights[i]) result++; 
	}
	
	return result;
}

[Theory]
[InlineData(new[] { 1, 1, 4, 2, 1, 3 }, 3)]
[InlineData(new[] { 5, 1, 2, 3, 4 }, 5)]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 0)]
void Test(int[] heights, int expected)
{
	int result = HeightChecker(heights);
	Assert.Equal(expected, result);
}