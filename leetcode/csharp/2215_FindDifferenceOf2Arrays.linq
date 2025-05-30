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
	public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) 
	{
		List<IList<int>> diffs = new List<IList<int>>(); 
		
		diffs.Add(new List<int>());
		diffs.Add(new List<int>());

		foreach (int num in nums1) 
		{
			if (!nums2.Contains(num) && !diffs[0].Contains(num)) diffs[0].Add(num); 	
		}

		foreach (int num in nums2)
		{
			if (!nums1.Contains(num) && !diffs[1].Contains(num)) diffs[1].Add(num);
		}

		return diffs;
	}
	
}

/*
Example 1:

Input: nums1 = [1,2,3], nums2 = [2,4,6]
Output: [[1,3],[4,6]]
Explanation:
For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].
Example 2:

Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
Output: [[3],[]]
Explanation:
For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
Every integer in nums2 is present in nums1. Therefore, answer[1] = [].
*/

[Theory]
[InlineData(new[] {1,2,3}, new[] {2,4,6}, new[] {1,3}, new[] {4,6})]
[InlineData(new[] {1,2,3,3}, new[] {1,1,2,2}, new[] {3}, new int[0])]
void Test(int[] nums1, int[] nums2, int[] diff1, int[] diff2)
{
	IList<IList<int>> result = new Solution().FindDifference(nums1, nums2); 
	Assert.Equal(result[0], diff1); 
	Assert.Equal(result[1], diff2); 
}

