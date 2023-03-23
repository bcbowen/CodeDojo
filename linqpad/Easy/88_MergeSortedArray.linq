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
	public void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		int l = nums1.Length - 1;
		m--;
		n--;
		while (n >= 0)
		{
			if (m >= 0 && nums1[m] > nums2[n])
			{
				nums1[l] = nums1[m];
				m--;
			}
			else
			{
				nums1[l] = nums2[n];
				n--;
			}
			l--;
		}
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
[InlineData(new[] { 1 }, 1, new int[0], 0, new[] { 1 })]
[InlineData(new[] { 0 }, 1, new int[] { 1 }, 1, new[] { 1 })]
[InlineData(new[] { 0 }, 0, new int[] { 1 }, 1, new[] { 1 })]
public void TestMerge(int[] nums1, int m, int[] nums2, int n, int[] expected)
{
	new Solution().Merge(nums1, m, nums2, n);
	Assert.Equal(expected, nums1);
}

#endregion