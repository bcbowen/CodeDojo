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
	public int[] NextGreaterElement(int[] nums1, int[] nums2)
	{
		int[] result = new int[nums1.Length];
		Dictionary<int, int> lookUp = new Dictionary<int, int>();
		for(int i = 0; i < nums2.Length; i++) 
		{
			lookUp.Add(nums2[i], i);
		}
		
		for(int i = 0; i < nums1.Length; i++) 
		{
			int value = nums1[i];
			int n2Index = lookUp[value];
			for(int j = n2Index; j < nums2.Length; j++)
			{
				if (nums2[j] > value) 
				{
					result[i] = nums2[j];
					break;
				}
			}
			if (result[i] == 0) result[i] = -1;
		}
		
		return result;
	}
}

// You can define other methods, fields, classes and namespaces here

#region private::Tests


[Theory]
[InlineData(new[] { 4, 1, 2 }, new[] { 1, 3, 4, 2 }, new[] { -1, 3, -1 })]
[InlineData(new[] { 2, 4 }, new[] { 1, 2, 3, 4 }, new[] { 3, -1 })]
void Test(int[] nums1, int[] nums2, int[] expected)
{
	int[] result = new Solution().NextGreaterElement(nums1, nums2);
	Assert.Equal(expected, result);
}

#endregion