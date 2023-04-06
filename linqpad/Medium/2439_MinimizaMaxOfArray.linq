<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	
	
	public int MinimizeArrayValue_first(int[] nums)
	{
		bool swapped = false;
		do
		{
			swapped = false;
			for (int i = 1; i < nums.Length; i++)
			{
				int diff = (int)Math.Ceiling((nums[i] - (double)nums[i - 1]) / 2);
				if (diff > 0)
				{
					nums[i] -= diff;
					nums[i - 1] += diff;
					swapped = true;
				}
			}

		} while (swapped);

		return nums.Max();
	}

}

/*
Example 1:
Input: nums = [3,7,1,6]
Output: 5
Explanation:
One set of optimal operations is as follows:
1. Choose i = 1, and nums becomes [4,6,1,6].
2. Choose i = 3, and nums becomes [4,6,2,5].
3. Choose i = 1, and nums becomes [5,5,2,5].
The maximum integer of nums is 5. It can be shown that the maximum number cannot be less than 5.
Therefore, we return 5.

Example 2:
Input: nums = [10,1]
Output: 10
Explanation:
It is optimal to leave nums as is, and since 10 is the maximum value, we return 10.
*/

[Theory]
[InlineData(new[] { 6, 9, 3, 8, 14 }, 8)]
[InlineData(new[] { 3, 7, 1, 6 }, 5)]
[InlineData(new[] { 10, 1 }, 10)]
void Test(int[] nums, int expected)
{
	int result = new Solution().MinimizeArrayValue(nums);
	Assert.Equal(expected, result);
}

[Fact]
void Troubleshooting()
{
	int[] nums = new[] { 6, 9, 3, 8, 14 };
	int expected = 8;
	int result = new Solution().MinimizeArrayValue(nums);
	Assert.Equal(expected, result);

}

[Theory]
[InlineData("2439_BigTestNums.txt", 921_389_843)]
[InlineData("2439_BigTest2Nums.txt", 750_185_974)]
public void BigTests(string fileName, int expected)
{
	string path = Path.Combine(GetDataDirectoryPath(), fileName);
	Assert.True(File.Exists(path));
	int[] nums = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	int result = new Solution().MinimizeArrayValue(nums);
	result.Dump();
	Assert.Equal(expected, result);
}

private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}
