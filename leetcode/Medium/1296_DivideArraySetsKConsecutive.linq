<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool IsPossibleDivide(int[] nums, int k)
{
	if (nums.Length < k || nums.Length % k != 0) return false;

	Array.Sort(nums);
	int groupCount = nums.Length / k;
	Stack<int>[] groups = new Stack<int>[groupCount];
	for (int i = 0; i < groups.Length; i++)
	{
		groups[i] = new Stack<int>();
	}
	foreach (int num in nums)
	{
		bool pushed = false;
		foreach (Stack<int> group in groups)
		{
			if (group.Count < k && (group.Count == 0 || group.Peek() == num - 1))
			{
				group.Push(num);
				pushed = true;
				break;
			}
		}
		if (!pushed) return false;
	}
	return true;
}

/*
Input: nums = [1,2,3,3,4,4,5,6], k = 4
Output: true

Input: nums = [3,2,1,2,3,4,3,4,5,9,10,11], k = 3
Output: true

Input: nums = [1,2,3,4], k = 3
Output: false
*/

[Theory]
[InlineData(new[] { 1, 2, 3, 3, 4, 4, 5, 6 }, 4, true)]
[InlineData(new[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11 }, 3, true)]
[InlineData(new[] { 1, 2, 3, 4 }, 3, false)]
[InlineData(new[] { 2, 1 }, 2, true)]
[InlineData(new[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 }, 3, true)]
[InlineData(new[] { 9, 2, 3, 6, 5, 1, 4, 7, 8 }, 3, true)]
[InlineData(new[] { 1, 2, 3, 2, 3, 4, 1, 2, 3 }, 3, true)]
[InlineData(new[] { 1, 2, 3, 9, 7, 8, 6, 4, 5 }, 3, true)]
[InlineData(new[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3, true)]
[InlineData(new[] { 1, 2, 3, 6, 2, 3, 4, 7, 9 }, 3, false)]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 4, false)]
void Test(int[] hand, int groupSize, bool expected)
{
	bool result = IsPossibleDivide(hand, groupSize);
	Assert.Equal(expected, result);

}

