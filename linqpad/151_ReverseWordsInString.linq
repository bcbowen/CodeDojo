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
	public string ReverseWords(string s)
	{
		StringBuilder result = new StringBuilder();
		string[] words = s.Split(' ');
		for(int i = words.Length - 1; i >= 0; i--) 
		{
			if (!string.IsNullOrEmpty(words[i])) result.Append(words[i] + ' ');
		}
		return result.ToString().Trim();
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

/*
Example 1:

Input: s = "the sky is blue"
Output: "blue is sky the"
Example 2:

Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
Example 3:

Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
*/

[Theory]
/*&*/
[InlineData("the sky is blue", "blue is sky the")]
[InlineData("hello world  ", "world hello")]
[InlineData("a good   example", "example good a")]

[InlineData("  hello world  ", "world hello")]

void TestReverseWords(string s, string expected) 
{
	string result = new Solution().ReverseWords(s);
	Assert.Equal(expected, result);
}

#endregion