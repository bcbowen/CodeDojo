<Query Kind="Program" />

void Main()
{
	Test(new[] { 1,2,3,0,0,0}, 3, new[] { 2,5,6 }, 3, new[] {1,2,2,3,5,6});
	Test(new[] { 1 }, 1, new int[0], 0, new[] { 1 });
	Test(new[] { 0 }, 1, new int[] {1}, 1, new[] { 1 });
	Test(new[] { 0 }, 0, new int[] {1}, 1, new[] { 1 });
}

public void Test(int[] nums1, int m, int[] nums2, int n, int[] expected) 
{
	new Solution().Merge(nums1, m, nums2, n); 
	Console.WriteLine("expected"); 
	expected.Dump();
	Console.WriteLine("result"); 
	nums1.Dump();
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