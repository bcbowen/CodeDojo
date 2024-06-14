<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public int MinIncrementForUnique(int[] nums)
{
	Array.Sort(nums);
	int moves = 0; 
	for(int i = 1; i < nums.Length; i++)
	{
		while (nums[i] <= nums[i - 1])
		{
			nums[i]++;
			moves++; 
		}
	}
	
	return moves; 
}


[Theory]
[InlineData(new[] { 1, 2, 2 }, 1)]
[InlineData(new[] { 3, 2, 1, 2, 1, 7 }, 6)]
void Test(int[] nums, int expected)
{
	int result = MinIncrementForUnique(nums);
	Assert.Equal(expected, result);
}
