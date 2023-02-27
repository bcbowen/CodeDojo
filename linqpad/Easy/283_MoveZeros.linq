<Query Kind="Program" />

void Main()
{
	
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