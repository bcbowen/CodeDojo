<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/*
Example 1:

Input: nums = [2,1,2]
Output: 5
Example 2:

Input: nums = [1,2,1]
Output: 0
*/
[Theory]
[InlineData(new[] {2, 1, 2}, 5)]
[InlineData(new[] {1, 2, 1}, 0)]
[InlineData(new[] {3,6,2,3}, 8)]
void LargestPerimeterTest(int[] nums, int expected) 
{
	int result = new Solution().LargestPerimeter(nums);
	Assert.Equal(expected, result);
}

public class Solution
{
	public int LargestPerimeter(int[] nums)
	{
		if (nums == null || nums.Length < 3) return 0;
		int p = 0; 
		Array.Sort(nums);
		int i = nums.Length - 1;
		while (i > 1)
		{
			int a = nums[i - 2]; 
			int b = nums[i - 1];
			int c = nums[i];
			if (a + b > c)
			{
				p = a + b + c;
				break;
			}
			i--;
		}	
		return p;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion