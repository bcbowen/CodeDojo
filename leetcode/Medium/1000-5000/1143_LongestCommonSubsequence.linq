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
	private string _text1; 
	private string _text2;
	private int[][] _memo;
	
	public int LongestCommonSubsequence(string text1, string text2)
	{
		_text1 = text1;
		_text2 = text2;

		_memo = new int[text1.Length + 1][];
		for(int i = 0; i < _memo.Length; i++) 
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
				_memo[i + 1][j + 1] =  DP(i + 1, j + 1);
			}
			
			return 1 +_memo[i + 1][j + 1];
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

[Theory]
[InlineData("abcde", "ace", 3)]
[InlineData("ace", "ace", 3)]
[InlineData("abc", "def", 0)]
[InlineData("pmjghexybyrgzczy", "hafcdqbgncrcbihkd", 4)]
void Test(string text1, string text2, int expected) 
{
	DateTime testStart = DateTime.Now;
	int result = new Solution().LongestCommonSubsequence(text1, text2); 
	TimeSpan totalMilliseconds = DateTime.Now.Subtract(testStart);
	Assert.Equal(expected, result);
}

/*
"pmjghexybyrgzczy"
"hafcdqbgncrcbihkd"


Example 1:
Input: text1 = "abcde", text2 = "ace" 
Output: 3  
Explanation: The longest common subsequence is "ace" and its length is 3.

Example 2:
Input: text1 = "abc", text2 = "abc"
Output: 3
Explanation: The longest common subsequence is "abc" and its length is 3.

Example 3:
Input: text1 = "abc", text2 = "def"
Output: 0
Explanation: There is no such common subsequence, so the result is 0.
 
*/
