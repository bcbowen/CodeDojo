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
	public void NextPermutation(int[] nums)
	{
		for (int i = nums.Length - 1; i > 0; i--)
		{
			if (nums[i] > nums[i - 1])
			{
				int index = i;
				int value = nums[i];
				for (int j = i; j < nums.Length; j++)
				{
					if (nums[j] < value && nums[j] > nums[i - 1])
					{
						index = j;
						value = nums[j];
					}
				}

				SwapDigits(nums, i - 1, index);
				Array.Sort(nums, i, nums.Length - i);
				return;
			}

		}
		Array.Sort(nums);
	}


	internal void SwapDigits(int[] a, int i, int j)
	{
		int temp = a[i]; 
		a[i] = a[j]; 
		a[j] = temp; 
	}
}

#region helperTests

[Theory]
[InlineData(new[] { 1, 2, 3 }, 1, 2, new[] {1, 3, 2})]
void SwapDigitsTest(int[] nums, int i, int j, int[] expected)
{
	new Solution().SwapDigits(nums, i, j);
	Assert.Equal(expected, nums);
}


#endregion

#region private::Tests

/*
Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]
Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]
Example 3:

Input: nums = [1,1,5]
Output: [1,5,1]
*/

[Theory]
[InlineData(new[] {1,2,3}, new[] {1,3,2})]
[InlineData(new[] {3,2,1}, new[] {1,2,3})]
[InlineData(new[] {1,1,5}, new[] {1,5,1})]
/**/
//[InlineData(new[] {}, new[] {})]
/**/
void TestMain(int[] nums, int[] expected)
{
	new Solution().NextPermutation(nums);
	Assert.Equal(expected, nums);
}


#endregion