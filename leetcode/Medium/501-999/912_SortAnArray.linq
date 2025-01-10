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
	public int[] SortArray(int[] nums)
	{
		if (nums.Length == 1) return nums;
		
		int i = nums.Length / 2;
		int[] a = SortArray(nums.Take(i).ToArray());
		int[] b = SortArray(nums.Skip(i).Take(nums.Length - i).ToArray()); 
		
		return Merge(a, b); 
	}

	internal int[] Merge(int[] a, int[] b) 
	{
		int[] merged = new int[a.Length + b.Length]; 
		
		int i = 0; 
		int j = 0;
		int k = 0; 

		while (k < merged.Length)
		{
			if (i == a.Length)
			{
				while (j < b.Length) 
				{
					merged[k++] = b[j++];
				}
			}
			else if (j == b.Length)
			{
				while(i < a.Length) 
				{
					merged[k++] = a[i++];
				}
			}
			else if (a[i] < b[j]) 
			{
				merged[k++] = a[i++];
			}
			else 
			{
				merged[k++] = b[j++];
			}
		}
		
		return merged; 
	}
}

[Theory]
[InlineData(new[] { 5, 2, 3, 1 })]
[InlineData(new[] { 5, 1, 1, 2, 0, 0 })]
public void Test(int[] nums)
{
	int[] result = new Solution().SortArray(nums);
	Assert.True(CheckSort(result));
}

[Theory]
[InlineData(new[] { 1 }, true)]
[InlineData(new[] { 1, 2, 3, 4, 5, 6 }, true)]
[InlineData(new[] { 5, 2, 3, 1 }, false)]
[InlineData(new[] { 1, 2, 3, 5 }, true)]
[InlineData(new[] { 5, 1, 1, 2, 0, 0 }, false)]
[InlineData(new[] { 0, 0, 1, 1, 2, 5 }, true)]
public void CheckSortTest(int[] nums, bool expected)
{
	bool result = CheckSort(nums);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(new[] {1, 3}, new[] { 2, 4}, new[] {1, 2, 3, 4})]
[InlineData(new[] {2}, new[] {1, 3 }, new[] {1, 2, 3})]
[InlineData(new[] {1, 3}, new[] {2 }, new[] {1, 2, 3})]
[InlineData(new[] {1, 2}, new[] {3, 4 }, new[] {1, 2, 3, 4})]
[InlineData(new[] {3, 4}, new[] { 1, 2}, new[] {1, 2, 3, 4})]
public void MergeTest(int[] a, int[] b, int[] expected) 
{
	int[] result = new Solution().Merge(a, b); 
	Assert.Equal(expected, result); 
}

/*
Input: nums = [5,2,3,1]
Output: [1,2,3,5]
Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).


Input: nums = [5,1,1,2,0,0]
Output: [0,0,1,1,2,5]
Explanation: Note that the values of nums are not necessairly unique.

*/

private bool CheckSort(int[] nums)
{
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] < nums[i - 1]) return false;
	}
	return true;
}