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
	public int[] NextGreaterElements(int[] nums)
	{
		int[] answers = new int[nums.Length];
		Stack<int> monoDecreasingStack = new Stack<int>();
		for (int i = 0; i < 2; i++)
		{
			for (int j = nums.Length - 1; j >= 0; j--)
			{
				while (monoDecreasingStack.Count > 0 && nums[monoDecreasingStack.Peek()] <= nums[j])
				{
					monoDecreasingStack.Pop();
				}

				answers[j] = monoDecreasingStack.Count > 0 ? nums[monoDecreasingStack.Peek()] : -1;

				monoDecreasingStack.Push(j);
			}
		}
		return answers;
	}
}

#region private::Tests
/*
Example 1:

Input: nums = [1,2,1]
Output: [2,-1,2]
Explanation: The first 1's next greater number is 2; 
The number 2 can't find next greater number. 
The second 1's next greater number needs to search circularly, which is also 2.
Example 2:

Input: nums = [1,2,3,4,3]
Output: [2,3,4,-1,4]
*/
[Theory]
[InlineData(new[] { 1, 2, 1 }, new[] { 2, -1, 2 })]
[InlineData(new[] { 1, 2, 3, 4, 3 }, new[] { 2, 3, 4, -1, 4 })]
// [InlineData(new[] { }, new[] {})]
void Test(int[] nums, int[] expected)
{
	int[] result = new Solution().NextGreaterElements(nums);
	Assert.Equal(expected, result);
}

#endregion