<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public void SortColors(int[] nums)
{
	int i = 0;
	int mindex = 0; 
	while (i < nums.Length) 
	{
		mindex = i;
		for (int j = i + 1; j < nums.Length; j++)
		{
			if (nums[j] < nums[mindex]) 
			{
				mindex = j;
			}
		}
		if (mindex > i) 
		{
			int temp = nums[mindex]; 
			nums[mindex] = nums[i]; 
			nums[i] = temp;
		}
		i++;
	}
}

#region private::Tests

/*
Example 1:
Input: nums = [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]

Example 2:
Input: nums = [2,0,1]
Output: [0,1,2]
*/

[Theory]
[InlineData(new[] {2,0,2,1,1,0})]
[InlineData(new[] {2,0,1})]
void Test(int[] nums) 
{
	SortColors(nums);

	int last = nums[0];
	for (int i = 1; i < nums.Length; i++) 
	{
		Assert.True(nums[i] >= last);
		last = nums[i];
	}
}

#endregion