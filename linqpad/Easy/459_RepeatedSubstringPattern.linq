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
	public bool RepeatedSubstringPattern(string s)
	{
		StringBuilder substring = new StringBuilder();
		foreach (char c in s) 
		{
			substring.Append(c); 
			if (Test(s, substring)) return true;
		}
		return false;
	}

	internal bool Test(string main, StringBuilder substring) 
	{
		if (main.Length == substring.Length ||  main.Length % substring.Length != 0) return false;

		int i = 0;
		foreach(char c in main) 
		{
			if (c != substring[i]) return false; 
			i = (i + 1) % substring.Length; 
		}
		return true;
	}
}

#region private::Tests

[Theory]
[InlineData("abab", "ab", true)]
[InlineData("abab", "aba", false)]
[InlineData("abab", "a", false)]
[InlineData("aba", "ab", false)]
[InlineData("ab", "ab", false)]
[InlineData("abcabcabcabc", "abc", true)]
[InlineData("abcabcabcabc", "abcabc", true)]
void TestTest(string m, string s, bool expected)
{
	bool result = new Solution().Test(m, new StringBuilder(s)); 
	Assert.Equal(expected, result);
}


[Theory]
[InlineData("abab", true)]
[InlineData("aba", false)]
[InlineData("abcabcabcabc", true)]
void Test(string s, bool expected) 
{
	bool result = new Solution().RepeatedSubstringPattern(s); 
	Assert.Equal(expected, result);
}

/*

Example 1:
Input: s = "abab"
Output: true
Explanation: It is the substring "ab" twice.

Example 2:
Input: s = "aba"
Output: false

Example 3:
Input: s = "abcabcabcabc"
Output: true
Explanation: It is the substring "abc" four times or the substring "abcabc" twice.

*/

#endregion