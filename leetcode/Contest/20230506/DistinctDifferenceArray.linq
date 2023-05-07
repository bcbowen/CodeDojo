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
	public int[] DistinctDifferenceArray(int[] nums)
	{
		Dictionary<int, int> prefixCounts = new Dictionary<int, int>();
		Dictionary<int, int> suffixCounts = new Dictionary<int, int>();

		int[] result = new int[nums.Count()];

		prefixCounts.Add(nums[0], 1);

		for (int i = 1; i < nums.Length; i++)
		{
			if (!suffixCounts.ContainsKey(nums[i]))
			{
				suffixCounts.Add(nums[i], 0);
			}
			suffixCounts[nums[i]]++;
		}

		int j = 0;
		while (j < nums.Length)
		{
			result[j] = prefixCounts.Keys.Count() - suffixCounts.Keys.Count();
			j++;
			if (j < nums.Length) 
			{
				if (!prefixCounts.ContainsKey(nums[j]))
				{
					prefixCounts.Add(nums[j], 0);
				}
				prefixCounts[nums[j]]++;
				suffixCounts[nums[j]]--;
				if (suffixCounts[nums[j]] == 0)
				{
					suffixCounts.Remove(nums[j]);
				}
			}
		}

		return result;
	}


}

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { -3, -1, 1, 3, 5 })]
[InlineData(new[] { 3, 2, 3, 4, 2 }, new[] { -2, -1, 0, 2, 3 })]
void Test(int[] nums, int[] expected)
{
	int[] result = new Solution().DistinctDifferenceArray(nums);
	Assert.Equal(expected, result);
}
/*
Example 1:

Input: nums = [1,2,3,4,5]
Output: [-3,-1,1,3,5]
Explanation: For index i = 0, there is 1 element in the prefix and 4 distinct elements in the suffix. Thus, diff[0] = 1 - 4 = -3.
For index i = 1, there are 2 distinct elements in the prefix and 3 distinct elements in the suffix. Thus, diff[1] = 2 - 3 = -1.
For index i = 2, there are 3 distinct elements in the prefix and 2 distinct elements in the suffix. Thus, diff[2] = 3 - 2 = 1.
For index i = 3, there are 4 distinct elements in the prefix and 1 distinct element in the suffix. Thus, diff[3] = 4 - 1 = 3.
For index i = 4, there are 5 distinct elements in the prefix and no elements in the suffix. Thus, diff[4] = 5 - 0 = 5.
Example 2:

Input: nums = [3,2,3,4,2]
Output: [-2,-1,0,2,3]
Explanation: For index i = 0, there is 1 element in the prefix and 3 distinct elements in the suffix. Thus, diff[0] = 1 - 3 = -2.
For index i = 1, there are 2 distinct elements in the prefix and 3 distinct elements in the suffix. Thus, diff[1] = 2 - 3 = -1.
For index i = 2, there are 2 distinct elements in the prefix and 2 distinct elements in the suffix. Thus, diff[2] = 2 - 2 = 0.
For index i = 3, there are 3 distinct elements in the prefix and 1 distinct element in the suffix. Thus, diff[3] = 3 - 1 = 2.
For index i = 4, there are 3 distinct elements in the prefix and no elements in the suffix. Thus, diff[4] = 3 - 0 = 3.
*/