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
	public char FindTheDifference(string s, string t)
	{
		Dictionary<char, int> letters = new Dictionary<char, int>();
		foreach (char c in s)
		{
			if (!letters.ContainsKey(c))
			{
				letters.Add(c, 0); 
			}
			
			letters[c]++;
		}

		foreach (char c in t)
		{
			if (!letters.ContainsKey(c) || letters[c] == 0) return c;
			letters[c]--;
		}
		
		return ' ';
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

/*
Example 1:

Input: s = "abcd", t = "abcde"
Output: "e"
Explanation: 'e' is the letter that was added.
Example 2:

Input: s = "", t = "y"
Output: "y"
*/

[Theory]
[InlineData("abcd", "abcde", 'e')]
[InlineData("", "y", 'y')]
void Test(string s, string t, char expected)
{
	char result = new Solution().FindTheDifference(s, t); 
	Assert.Equal(expected, result);
}

#endregion