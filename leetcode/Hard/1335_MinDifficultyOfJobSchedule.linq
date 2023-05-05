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

#region private::Tests

[Theory]
[InlineData(new[] { 6, 5, 4, 3, 2, 1 }, 2, 7)]
[InlineData(new[] { 9, 9, 9 }, 4, -1)]
[InlineData(new[] { 1, 1, 1 }, 3, 3)]
void Test(int[] jobDifficulty, int d, int expected)
{
	int result = new Solution().MinDifficulty(jobDifficulty, d);
	Assert.Equal(expected, result);
}

/*

Example 1:
Input: jobDifficulty = [6,5,4,3,2,1], d = 2
Output: 7
Explanation: First day you can finish the first 5 jobs, total difficulty = 6.
Second day you can finish the last job, total difficulty = 1.
The difficulty of the schedule = 6 + 1 = 7 

Example 2:
Input: jobDifficulty = [9,9,9], d = 4
Output: -1
Explanation: If you finish a job per day you will still have a free day. you cannot find a schedule for the given jobs.

Example 3:
Input: jobDifficulty = [1,1,1], d = 3
Output: 3
Explanation: The schedule is one job per day. total difficulty will be 3.
*/
#endregion