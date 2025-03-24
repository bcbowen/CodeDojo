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
	public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
	{
		List<bool> result = new List<bool>();
		for (int i = 0; i < l.Length; i++)
		{
			int start = l[i];
			int end = r[i];
			List<int> temp = new List<int>();
			for (int j = start; j < end + 1; j++)
			{
				temp.Add(nums[j]);
			}
			result.Add(CheckIsArithmeticSubarrays(temp));
		}
		return result;
	}

	internal bool CheckIsArithmeticSubarrays(List<int> nums)
	{
		if (nums.Count() < 2) return false;
		nums.Sort();
		int delta = nums[1] - nums[0];
		for (int i = 0; i < nums.Count() - 1; i++)
		{
			if (nums[i + 1] - nums[i] != delta)
				return false;
		}
		return true;
	}

}

#region private::Tests

[Theory]
[InlineData(new[] { 4, 6, 5, 9, 3, 7 }, new[] { 0, 0, 2 }, new[] { 2, 3, 5 }, new[] { true, false, true })]
[InlineData(new[] { -12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10 }, new[] { 0, 1, 6, 4, 8, 7 }, new[] { 4, 4, 9, 7, 9, 10 }, new[] { false, true, false, false, true, true })]
// [InlineData(new[] { }, new[] { }, new[] { }, new[] {})]
void Test(int[] nums, int[] l, int[] r, bool[] expected)
{
	bool[] result = new Solution().CheckArithmeticSubarrays(nums, l, r).ToArray();
	Assert.Equal(expected, result); 
}

/*

Example 1:
Input: nums = [4,6,5,9,3,7], l = [0,0,2], r = [2,3,5]
Output: [true,false,true]
Explanation:
In the 0th query, the subarray is [4,6,5]. This can be rearranged as [6,5,4], which is an arithmetic sequence.
In the 1st query, the subarray is [4,6,5,9]. This cannot be rearranged as an arithmetic sequence.
In the 2nd query, the subarray is [5,9,3,7]. This can be rearranged as [3,5,7,9], which is an arithmetic sequence.

Example 2:
Input: nums = [-12,-9,-3,-12,-6,15,20,-25,-20,-15,-10], l = [0,1,6,4,8,7], r = [4,4,9,7,9,10]
Output: [false,true,false,false,true,true]
 

Constraints:
n == nums.length
m == l.length
m == r.length
2 <= n <= 500
1 <= m <= 500
0 <= l[i] < r[i] < n
-105 <= nums[i] <= 105
*/

#endregion