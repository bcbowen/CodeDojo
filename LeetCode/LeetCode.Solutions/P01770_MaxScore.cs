namespace LeetCode.Solutions.P01770_MaxScore;

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
        for (int i = 0; i < m; i++)
        {
            _memo[i] = new int[m];
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

