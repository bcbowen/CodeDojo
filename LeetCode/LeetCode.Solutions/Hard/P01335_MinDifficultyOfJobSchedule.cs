namespace LeetCode.Solutions.Hard.P01335_MinDifficultyOfJobSchedule;

public class Solution
{
    private int[][] _jobMatrix;
    private int[] _jobDifficulty;

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        int jobCount = jobDifficulty.Length;

        if (jobCount < d) return -1;

        _jobDifficulty = jobDifficulty;
        _jobMatrix = new int[jobCount][];
        for (int i = 0; i < jobCount; i++)
        {
            _jobMatrix[i] = new int[d + 1];
            Array.Fill(_jobMatrix[i], -1);
        }

        return MinDiff(0, d);
    }

    private int MinDiff(int i, int daysRemaining)
    {
        if (_jobMatrix[i][daysRemaining] != -1)
        {
            return _jobMatrix[i][daysRemaining];
        }

        int dailyResult;
        if (daysRemaining == 1)
        {
            dailyResult = 0;

            for (int j = i; j < _jobDifficulty.Length; j++)
            {
                dailyResult = Math.Max(dailyResult, _jobDifficulty[j]);
            }
        }
        else
        {
            dailyResult = int.MaxValue;
            int dailyMaxDiff = 0;
            for (int j = i; j < _jobDifficulty.Length - daysRemaining + 1; j++)
            {
                dailyMaxDiff = Math.Max(dailyMaxDiff, _jobDifficulty[j]);
                dailyResult = Math.Min(dailyResult, dailyMaxDiff + MinDiff(j + 1, daysRemaining - 1));
            }

            _jobMatrix[i][daysRemaining] = dailyResult;
        }

        return dailyResult;
    }
}