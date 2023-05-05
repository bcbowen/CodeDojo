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
	public string ToLowerCase(string s)
	{
		// 'A': 65
		// 'Z': 90
		// 'a': 97
		StringBuilder lower = new StringBuilder();
		foreach (char c in s)
		{
			int code = (int)c;
			char replacement;
			if (code >= 65 && code <= 90)
			{
				replacement = (char)(code + 32);
			}
			else
			{
				replacement = c;
			}
			lower.Append(replacement);
		}

		return lower.ToString();
	}
}

/*
Example 1:

Input: s = "Hello"
Output: "hello"
Example 2:

Input: s = "here"
Output: "here"
Example 3:

Input: s = "LOVELY"
Output: "lovely"
*/
[Theory]
[InlineData("Hello", "hello")]
[InlineData("here", "here")]
[InlineData("LOVELY", "lovely")]
[InlineData("", "")]
void TestToLowerCase(string input, string expected)
{
	string result = new Solution().ToLowerCase(input);
	Assert.Equal(expected, result);
}
