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
	public void MoveZeroes(int[] nums)
	{
		int i = 0;
		int j = 0;

		while (i < nums.Length)
		{
			if (nums[i] != 0)
			{
				nums[j++] = nums[i];
			}
			i++;
		}

		while (j < nums.Length)
		{
			nums[j++] = 0;
		}
	}
}

#region private::Tests
[Theory]
[InlineData(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
[InlineData(new[] { 0 }, new[] { 0 })]
public void MoveZerosTest(int[] nums, int[] expected)
{
	new Solution().MoveZeroes(nums);
	Assert.Equal(expected, nums);
}

#endregion