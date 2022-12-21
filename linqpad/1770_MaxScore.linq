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
	private int[][] _memo;
	private int[] _nums;
	private int[] _multipliers;
	public int MaximumScore(int[] nums, int[] multipliers)
	{
		_nums = nums; 
		_multipliers = multipliers;
		int m = _multipliers.Length;
		_memo = new int[m][];
		for(int i = 0; i < m; i++)
		{
			_memo[i] = new int [m];
		}

		return dp(0, 0);
	}

	private int dp(int turn, int left)
	{
		if (turn == _multipliers.Length) return 0; 
		int multiplier = _multipliers[turn];
		int right = _nums.Length - 1 - (turn - left);

		if (_memo[turn][left] == 0)
		{
			_memo[turn][left] = Math.Max(multiplier * _nums[left] + dp(turn + 1, left + 1),
									 multiplier * _nums[right] + dp(turn + 1, left));
		}
		
		return _memo[turn][left];
	}
}

#region private::Tests

[Theory]
[InlineData(new[] {1,2,3}, new[] {3,2,1}, 14)]
[InlineData(new[] {-5,-3,-3,-2,7,1}, new[] {-10,-5,3,4,6}, 102)]
void Test(int[] nums, int[] multipliers, int expected ) 
{
	int result = new Solution().MaximumScore(nums, multipliers); 
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums = [1,2,3], multipliers = [3,2,1]
Output: 14
Explanation: An optimal solution is as follows:
- Choose from the end, [1,2,3], adding 3 * 3 = 9 to the score.
- Choose from the end, [1,2], adding 2 * 2 = 4 to the score.
- Choose from the end, [1], adding 1 * 1 = 1 to the score.
The total score is 9 + 4 + 1 = 14.

Example 2:
Input: nums = [-5,-3,-3,-2,7,1], multipliers = [-10,-5,3,4,6]
Output: 102
Explanation: An optimal solution is as follows:
- Choose from the start, [-5,-3,-3,-2,7,1], adding -5 * -10 = 50 to the score.
- Choose from the start, [-3,-3,-2,7,1], adding -3 * -5 = 15 to the score.
- Choose from the start, [-3,-2,7,1], adding -3 * 3 = -9 to the score.
- Choose from the end, [-2,7,1], adding 1 * 4 = 4 to the score.
- Choose from the end, [-2,7], adding 7 * 6 = 42 to the score. 
The total score is 50 + 15 - 9 + 4 + 42 = 102.
*/
#endregion