namespace LeetCode.Solutions.P01143_LongestCommonSubsequence;

public class Solution
{
    private string _text1;
    private string _text2;
    private int[][] _memo;

    public int LongestCommonSubsequence(string text1, string text2)
    {
        _text1 = text1;
        _text2 = text2;

        _memo = new int[text1.Length + 1][];
        for (int i = 0; i < _memo.Length; i++)
        {
            _memo[i] = new int[text2.Length + 1];
        }

        return memoSolve(0, 0);
    }

    private int memoSolve(int p1, int p2)
    {

        // Check whether or not we've already solved this subproblem.
        // This also covers the base cases where p1 == text1.length
        // or p2 == text2.length.
        if (_memo[p1][p2] != 0)
        {
            return _memo[p1][p2];
        }

        if (p1 == _text1.Length || p2 == _text2.Length)
        {
            return 0;
        }

        // Option 1: we don't include text1[p1] in the solution.
        int option1 = memoSolve(p1 + 1, p2);

        // Option 2: We include text1[p1] in the solution, as long as
        // a match for it in text2 at or after p2 exists.
        int firstOccurence = _text2.IndexOf(_text1[p1], p2);
        int option2 = 0;
        if (firstOccurence != -1)
        {
            option2 = 1 + memoSolve(p1 + 1, firstOccurence + 1);
        }

        // Add the best answer to the memo before returning it.
        _memo[p1][p2] = Math.Max(option1, option2);
        return _memo[p1][p2];
    }

    private int DP(int i, int j)
    {
        if (i == _text1.Length || j == _text2.Length)
        {
            return 0;
        }

        if (_text1[i] == _text2[j])
        {
            if (_memo[i + 1][j + 1] == 0)
            {
                _memo[i + 1][j + 1] = DP(i + 1, j + 1);
            }

            return 1 + _memo[i + 1][j + 1];
        }
        else
        {
            if (_memo[i + 1][j] == 0)
            {
                _memo[i + 1][j] = DP(i + 1, j);
            }

            if (_memo[i][j + 1] == 0)
            {
                _memo[i][j + 1] = DP(i, j + 1);
            }

            return Math.Max(_memo[i + 1][j], _memo[i][j + 1]);
        }
    }
}
