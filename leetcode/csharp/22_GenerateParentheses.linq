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
	List<string> Result = new List<string>();

	public IList<string> GenerateParenthesis(int n)
	{
		Backtrack(n * 2, 0, 0, "");
		return Result;
	}

	internal void Backtrack(int n, int openCount, int closeCount, string s)
	{
		if (s.Length == n)
		{
			Result.Add(s);
			return;
		}
		if (openCount < n / 2) Backtrack(n, openCount + 1, closeCount, s + "(");
		if (openCount > closeCount) Backtrack(n, openCount, closeCount + 1, s + ")");
	}
}

/*
Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
Example 2:

Input: n = 1
Output: ["()"]
*/

[Theory]
[InlineData(3, new[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
[InlineData(1, new[] { "()" })]
void Test(int n, IList<string> expected)
{
	IList<string> result = new Solution().GenerateParenthesis(n);
	Assert.Equal(expected, result);
}
