<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MaxArea(int[] height)
{
	int max = 0;
	int l = 0;
	int r = height.Length - 1;
	while (l < r)
	{
		int volume = Math.Min(height[r], height[l]) * (r - l);
		max = Math.Max(max, volume);
		if (height[l] > height[r])
		{
			r--;
		}
		else 
		{
			l++; 
		}
	}
	return max;
}

public int MaxAreaBrute(int[] height)
{
	int max = 0;
	int l = 0;
	while (l < height.Length - 1)
	{
		if (height[l] == 0) 
		{
			l++;
			continue;
		} 
		int r = height.Length - 1;
		while(r > l) 
		{
			if (height[r] == 0) 
			{
				r--;
				continue;	
			}
			
			int volume = CalcVolume(l, r, height); 
			max = Math.Max(max, volume); 
			// if r is at least as high as l, this will be the max possible and we can go to the next value for l
			if (height[r] >= height[l]) break;
			r--; 
		}
		
		l++; 
	}
	return max; 
}

internal int CalcVolume(int l, int r, int[] heights)
{
	int x = r - l;
	int y = Math.Min(heights[r], heights[l]);
	return x * y;
}

#region private::Tests

/*
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: height = [1,1]
Output: 1
*/

[Theory]
//[InlineData(new[] {}, )]
[InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
[InlineData(new[] { 1, 1 }, 1)]
[InlineData(new[] { 0, 2 }, 0)]
[InlineData(new[] { 2, 0 }, 0)]
void Test(int[] heights, int expected)
{
	int result = MaxArea(heights);
	Assert.Equal(expected, result);
}


[Theory]
[InlineData(1, 8, new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
[InlineData(0, 1, new[] { 1, 1 }, 1)]
void TestCalcVolume(int l, int r, int[] heights, int expected) 
{
	int result = CalcVolume(l, r, heights); 
	Assert.Equal(expected, result); 
}
#endregion