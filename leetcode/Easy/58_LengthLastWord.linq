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
	public int LengthOfLastWord(string s)
	{
		int count = 0;
		int i = s.Length - 1;
		while (s[i] == ' ') 
		{
			i--;
		}
		while (i >= 0 && s[i] != ' ') 
		{
			i--; 
			count++; 
		}
		
		return count;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData("Hello World", 5)]
[InlineData("   fly me   to   the moon  ", 4)]
[InlineData("luffy is still joyboy", 6)]
[InlineData("balls", 5)]
void Test(string s, int expected) 
{
	int result = new Solution().LengthOfLastWord(s);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.

Example 2:
Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.

Example 3:
Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.

*/

#endregion