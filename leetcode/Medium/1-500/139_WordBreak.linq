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
	private bool[] _characters;
	public bool WordBreak(string s, IList<string> wordDict)
	{
		_characters = new bool[s.Length + 1];
		int i = 0;
		Scan(i, s, wordDict);
		
		for (i = 1; i < s.Length; i++)
		{
			if (_characters[i])
			{
				Scan(i, s, wordDict);
			}
		}

		return _characters[_characters.Length - 1];
	}

	private void Scan(int i, string s, IList<string> wordDict)
	{
		foreach (string word in wordDict)
		{
			if (word[0] == s[i] && i + word.Length < _characters.Length)
			{
				if (s.Substring(i, word.Length) == word)
				{
					_characters[i + word.Length] = true;
				}

			}
		}

	}
}

#region private::Tests

[Theory]
[InlineData("leetcode", new[] { "leet", "code" }, true)]
[InlineData("applepenapple", new[] { "apple", "pen" }, true)]
[InlineData("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
[InlineData("bb", new[] { "a", "b", "bbb", "bbbb" }, true)]
void Test(string s, IList<string> wordDict, bool expected)
{
	bool result = new Solution().WordBreak(s, wordDict);
	Assert.Equal(expected, result);
}

/*
"bb"
["a","b","bbb","bbbb"]


Example 1:
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
*/

#endregion