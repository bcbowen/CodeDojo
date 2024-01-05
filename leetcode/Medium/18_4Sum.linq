<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<IList<int>> FourSum(int[] nums, int target)
{
	List<IList<int>> result = new List<IList<int>>();
	if (nums.Length < 4) return result;
	HashSet<(int, int, int, int)> uniqueResults = new HashSet<(int, int, int, int)>();
	Array.Sort(nums);
	for (int x1 = 0; x1 < nums.Length - 3; x1++)
	{
		for (int x2 = x1 + 1; x2 < nums.Length - 2; x2++)
		{
			int x3 = x2 + 1;
			int x4 = nums.Length - 1;
			while (x3 < x4)
			{
				long sum = (long)nums[x1] + (long)nums[x2] + (long)nums[x3] + (long)nums[x4];
				if (sum == target)
				{
					(int, int, int, int) tuple = (nums[x1], nums[x2], nums[x3], nums[x4]);
					if (!uniqueResults.Contains(tuple))
					{
						uniqueResults.Add(tuple);
						result.Add(new List<int> { nums[x1], nums[x2], nums[x3], nums[x4] });
					}
					x3++;
				}
				else if (sum < target)
				{
					x3++;
				}
				else
				{
					x4--;
				}
			}
		}
	}

	return result;
}

/*
Example 1:
Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

Example 2:
Input: nums = [2,2,2,2,2], target = 8
Output: [[2,2,2,2]]
*/

[Theory]
[InlineData(new[] { 1, 0, -1, 0, -2, 2 }, 0, new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 })]
[InlineData(new[] { 2, 2, 2, 2, 2 }, 8, new[] { 2, 2, 2, 2 })]
void Test(int[] nums, int target, params int[][] expected)
{
	IList<IList<int>> result = FourSum(nums, target);
	List<List<int>> expectedList = new List<List<int>>();
	foreach (int[] row in expected)
	{
		expectedList.Add(row.ToList());
	}
	Assert.Equal(expectedList, result);
}

[Fact]
void OverFlowTest()
{
	int[] nums = new[] { 1000000000, 1000000000, 1000000000, 1000000000 }; 
	int target = -294967296;
	IList<IList<int>> result = FourSum(nums, target); 
	Assert.Empty(result); 
}
