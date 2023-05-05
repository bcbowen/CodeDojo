<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public void Test(int[] nums, IList<IList<int>> expected) 
{
	Solution solution = new Solution(); 
	IList<IList<int>> result = solution.ThreeSum(nums);

	Console.WriteLine("Nums:");
	nums.Dump();
	Console.WriteLine("Expected:");
	expected.Dump(); 
	Console.WriteLine("Result:");
	result.Dump(); 
}

public class Solution
{
	public IList<IList<int>> ThreeSum(int[] nums)
	{
		Array.Sort(nums);
		IList<IList<int>> result = new List<IList<int>>();

		for (int x = 0; x < nums.Length - 2; x++)
		{
			if (x == 0 || (x > 0 && nums[x] != nums[x - 1])) 
			{
				int y = x + 1;
				int z = nums.Length - 1;
				while (y < z)
				{
					int diff = 0 - nums[x];
					int current = nums[y] + nums[z];
					if (current == diff)
					{
						while (y < z && nums[y + 1] == nums[y]) y++;
						while (z > y && nums[z - 1] == nums[z]) z--;
						result.Add(new List<int> { nums[x], nums[y], nums[z] });
						z--;
					}
					else if (current < diff)
					{

						y++;
					}
					else
					{

						z--;
					}

				}
			}

		}
		return result;
	}

	public IList<IList<int>> ThreeSumBrute(int[] nums)
	{
		// exceeds max time
		Array.Sort(nums);
		IList<IList<int>> result = new List<IList<int>>();

		for (int x = 0; x < nums.Length - 2; x++)
		{
			for (int y = x + 1; y < nums.Length - 1; y++)
			{
				for (int z = y + 1; z < nums.Length; z++)
				{
					if (nums[x] + nums[y] + nums[z] == 0)
					{
						if (!result.Any(r => r[0] == nums[x] && r[1] == nums[y] && r[2] == nums[z]))
						{
							result.Add(new List<int> { nums[x], nums[y], nums[z] });
						}

					}
				}

			}
		}
		return result;
	}

	public IList<IList<int>> ThreeSum1(int[] nums)
	{
		// doesn't work sometimes
		Array.Sort(nums);
		IList<IList<int>> result = new List<IList<int>>();

		for (int x = 0; x < nums.Length - 2; x++)
		{
			//if (nums[x] == nums[x + 1]) x++; 
			int y = x + 1;
			int z = nums.Length - 1;

			while (y < z)
			{
				if (nums[x] + nums[y] + nums[z] == 0)
				{
					if (!result.Any(r => r[0] == nums[x] && r[1] == nums[y] && r[2] == nums[z]))
					{
						result.Add(new List<int> { nums[x], nums[y], nums[z] });
					}

				}
				while (y < z && nums[y + 1] == nums[y]) y++;
				while (z > y && nums[z - 1] == nums[z]) z--;
				y++;
				z--;
			}
		}
		return result;
	}
}

[Theory]
[InlineData(new[] { -1, 0, 1, 2, -1, -4 }, new[] { -1, -1, 2 }, new[] { -1, 0, 1 })]
[InlineData(new[] { 3, 0, -2, -1, 1, 2 }, new[] { -2, -1, 3 }, new[] { -2, 0, 2 }, new[] { -1, 0, 1 })]
[InlineData(new[] { 0, 0, 0 }, new[] { 0, 0, 0 })]
[InlineData(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0 })]
[InlineData(new[] { 1, -1, -1, 0 }, new[] { -1, 0, 1 })]
public void Test(int[] nums, params int[][] expected)
{
	IList<IList<int>> result = new Solution().ThreeSum(nums);
	List<List<int>> expectedList = new List<List<int>>();
	foreach (int[] intArray in expected)
	{
		Array.Sort(intArray);
		expectedList.Add(intArray.ToList());
	}

	HashSet<List<int>> sets = new HashSet<List<int>>();
	foreach (List<int> list in result)
	{
		list.Sort();
		Assert.False(sets.Contains(list));
		Assert.True(Contains(expectedList, list));
		sets.Add(list);
	}

	Assert.Equal(expected.Length, sets.Count);
}

private bool Contains(List<List<int>> expected, List<int> result)
{
	foreach (List<int> list in expected)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != result[i]) break;
			if (i == result.Count - 1) return true;
		}
	}

	return false;
}