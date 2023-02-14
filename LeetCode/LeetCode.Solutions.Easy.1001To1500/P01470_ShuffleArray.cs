namespace LeetCode.Solutions.Easy.P01470_ShuffleArray;

public class Solution
{
	public int[] Shuffle(int[] nums, int n)
	{
		if (n == 1) return nums;

		int[] result = new int[nums.Length];
		int j = 0;
		for (int i = 0; i < n; i++)
		{
			result[j++] = nums[i];
			result[j++] = nums[i + n];
		}
		return result;
	}
}