<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public partial class Solution
{

	public int Jump(int[] nums)
	{
		if (nums.Count() == 1) return 0; 
		
		int jumps = 0;
		int i = 0;
		int next = 0;
		while(i < nums.Length)
		{
			if (i + nums[i] >= nums.Length - 1)
			{
				jumps++; 
				break;
			}
			else 
			{
				int max = -1;
				for(int j = i + 1; j <= i + nums[i]; j++)
				{
					if (j + nums[j] > max) 
					{
						next = j; 
						max = j + nums[j]; 
					}
				}
				i = next; 
				jumps++;
			}
			
		}
		
		return jumps; 
	}

}

[Theory]
/**/
[InlineData(new[] { 2, 3, 1, 1, 4 }, 2)]
[InlineData(new[] { 2, 3, 0, 1, 4 }, 2)]
[InlineData(new[] { 1, 2, 1, 1, 1 }, 3)]
[InlineData(new[] { 3, 2, 1 }, 1)]
[InlineData(new[] { 2, 1, 1, 1, 1 }, 3)]
[InlineData(new[] { 4,1,1,3,1,1,1 }, 2)]
[InlineData(new[] { 0 }, 0)]
public void JumpTest(int[] nums, int expected)
{
	int result = new Solution().Jump(nums);
	Assert.Equal(expected, result);
}