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
	public int[] TwoSum(int[] nums, int target)
	{
		int[] solution = new int[2];
		Dictionary<int, int> map = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++)
		{
			int compliment = target - nums[i];
			if (map.ContainsKey(compliment))
			{
				solution[0] = map[compliment];
				solution[1] = i;
				break;
			}
			else
			{
				if (!map.ContainsKey(nums[i]))
				{
					map.Add(nums[i], i);
				}
			}
		}

		return solution;
	}

	public int[] TwoSumBrute(int[] nums, int target)
	{
		int[] solution = new int[2];
		bool done = false;

		for (int x = 0; x < nums.Length - 1; x++)
		{
			for (int y = x + 1; y < nums.Length; y++)
			{
				if (nums[x] + nums[y] == target)
				{
					solution[0] = x;
					solution[1] = y;
					done = true;
					break;
				}
			}
			if (done) break;
		}
		return solution;
	}
}


#region private::Tests

[Theory]
[InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
[InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
[InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
[InlineData(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 5, 11 })]
public void Test(int[] nums, int target, int[] expected)
{
	int[] solution = new Solution().TwoSum(nums, target);
	Assert.Equal(expected, solution);
}

#endregion