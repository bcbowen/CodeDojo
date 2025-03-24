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
	public string RemoveStars(string s)
	{
		StringBuilder builder = new StringBuilder();
		foreach (char c in s)
		{
			if (c == '*') 
			{
				builder.Length--;
			}
			else 
			{
				builder.Append(c);
			}
		}
		
		return builder.ToString();
	}
}

/*

Example 1:

Input: s = "leet**cod*e"
Output: "lecoe"
Explanation: Performing the removals from left to right:
- The closest character to the 1st star is 't' in "leet**cod*e". s becomes "lee*cod*e".
- The closest character to the 2nd star is 'e' in "lee*cod*e". s becomes "lecod*e".
- The closest character to the 3rd star is 'd' in "lecod*e". s becomes "lecoe".
There are no more stars, so we return "lecoe".
Example 2:

Input: s = "erase*****"
Output: ""
Explanation: The entire string is removed, so we return an empty string.
*/

[Theory]
[InlineData("leet**cod*e", "lecoe")]
[InlineData("erase*****", "")]
[InlineData("nothing", "nothing")]
[InlineData("n", "n")]
void Test(string s, string expected) 
{
	string result = new Solution().RemoveStars(s); 
	Assert.Equal(expected, result);
	
}
