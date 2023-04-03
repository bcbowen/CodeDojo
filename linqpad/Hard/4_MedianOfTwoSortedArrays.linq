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
	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		double[] merged = Merge(nums1, nums2);

		double median = 0;

		if (merged.Length % 2 == 0)
		{
			median = (merged[(merged.Length / 2) - 1] + merged[merged.Length / 2]) / 2;
		}
		else
		{
			median = merged[merged.Length / 2];
		}

		return median;
	}

	internal double[] Merge(int[] nums1, int[] nums2)
	{
		double[] merged = new double[nums1.Length + nums2.Length];
		int i1 = 0;
		int i2 = 0;
		int i3 = 0;
		while (i3 < merged.Length)
		{
			if (i1 == nums1.Length)
			{
				merged[i3++] = nums2[i2++];
			}
			else if (i2 == nums2.Length)
			{
				merged[i3++] = nums1[i1++];
			}
			else if (nums1[i1] < nums2[i2])
			{
				merged[i3++] = nums1[i1++];
			}
			else
			{
				merged[i3++] = nums2[i2++];
			}
		}

		return merged;
	}
}

[Theory]
[InlineData(new[] { 1, 3 }, new[] { 2 }, 2)]
[InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
[InlineData(new[] { 1, 2, 3 }, new int[0], 2)]
[InlineData(new[] { 1, 2, 3, 4 }, new int[0], 2.5)]
[InlineData(new int[0], new[] { 1, 2, 3 }, 2)]
[InlineData(new int[0], new[] { 1, 2, 3, 4 }, 2.5)]
public void FindMedianTest(int[] nums1, int[] nums2, double expected)
{
	double result = new Solution().FindMedianSortedArrays(nums1, nums2);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(new[] { 1, 3 }, new[] { 2 }, new[] { 1.0, 2.0, 3.0 })]
[InlineData(new[] { 1, 2 }, new[] { 3, 4 }, new[] { 1.0, 2.0, 3.0, 4.0 })]
[InlineData(new[] { 3, 4 }, new[] { 1, 2 }, new[] { 1.0, 2.0, 3.0, 4.0 })]
[InlineData(new[] { 1, 4 }, new int[0], new[] { 1.0, 4.0 })]
[InlineData(new int[0], new[] { 2, 3 }, new[] { 2.0, 3.0 })]
[InlineData(new int[0], new int[0], new double[0])]
public void MergeTest(int[] nums1, int[] nums2, double[] expected)
{
	double[] result = new Solution().Merge(nums1, nums2);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
*/

