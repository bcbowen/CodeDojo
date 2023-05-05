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
	public bool CanPlaceFlowers(int[] flowerbed, int n)
	{
		if (n == 0) return true;
		
		switch(flowerbed.Length) 
		{
			case 1: 
				return flowerbed[0] == 0; 
			case 2: 
				return n <= 1 && !flowerbed.Contains(1);
		}

		if (flowerbed[0] == 0 && flowerbed[1] == 0) 
		{
			flowerbed[0] = 1; 
			n--;
		}
		
		for(int i = 1; i < flowerbed.Length && n > 0; i++)
		{
			if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0)) 
			{
				flowerbed[i] = 1; 
				n--;
			}
		}
		
		return n == 0;
	}
}

#region private::Tests

/*
Example 1:

Input: flowerbed = [1,0,0,0,1], n = 1
Output: true
Example 2:

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
*/

[Theory]

[InlineData(new int[] { 0, 0 }, 2, false)]
/**/
[InlineData(new int[] { 1, 0, 0, 0, 1 }, 1, true)]
[InlineData(new int[] { 1, 0, 0, 0, 1 }, 2, false)]
[InlineData(new int[] { 1, 0, 0, 0, 0, 1 }, 2, false)]
[InlineData(new int[] { 1 }, 1, false)]
[InlineData(new int[] { 0 }, 1, true)]
[InlineData(new int[] { 0, 0, 0, 0, 1 }, 2, true)]
[InlineData(new int[] { 0, 1, 0 }, 1, false)]
void Test(int[] flowerBed, int n, bool expected)
{
	bool result = new Solution().CanPlaceFlowers(flowerBed, n);
	Assert.Equal(expected, result);
}

#endregion