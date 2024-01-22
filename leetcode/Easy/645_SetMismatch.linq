<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int[] FindErrorNums(int[] nums)
{
	int n = nums.Length; 
	int expectedSum = (n * (n + 1)) / 2;
	int dupe = -1;

	Array.Sort(nums);
	int actualSum = nums[0]; 
	for(int i = 1; i < nums.Length; i++)
	{
		actualSum += nums[i]; 
		if (nums[i] == nums[i - 1]) 
		{
			dupe = nums[i]; 
		}
	}
	int missing = expectedSum - (actualSum - dupe);

	return new int[] {dupe, missing}; 
}

public int[] FindErrorNums1(int[] nums)
{
	int[] result = null;
	Array.Sort(nums);
	int missing = -1;
	int dupe = -1;
	for (int i = 1; i < nums.Length; i++)
	{
		if (missing == -1)
		{
			if (nums[i - 1] != i) { missing = i; }
			else if (nums[i] != i + 1) { missing = i + 1; }
		}

		if (nums[i - 1] == nums[i]) dupe = nums[i];
		if (missing > -1 && dupe > -1)
		{
			result = new[] { dupe, missing };
			break;
		}
	}

	return result;
}

/*
Example 1:
Input: nums = [1,2,2,4]
Output: [2,3]

Example 2:
Input: nums = [1,1]
Output: [1,2]

Input: nums = [3,2,2]
Output: [2,1]

[3,2,3,4,6,5]
[3,1]
*/

[Theory]
[InlineData(new[] { 1, 2, 2, 4 }, new[] { 2, 3 })]
[InlineData(new[] { 1, 1 }, new[] { 1, 2 })]
[InlineData(new[] { 2, 2 }, new[] { 2, 1 })]
[InlineData(new[] { 3, 2, 2 }, new[] { 2, 1 })]
[InlineData(new[] { 3, 2, 3, 4, 6, 5 }, new[] { 3, 1 })]
void Test(int[] nums, int[] expected)
{
	int[] result = FindErrorNums(nums);
	Assert.Equal(expected, result);
}


