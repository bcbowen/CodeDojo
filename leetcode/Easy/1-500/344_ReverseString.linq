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
	public void ReverseString(char[] s)
	{
		int i = 0;
		int j = s.Length - 1;
		while (i < j) 
		{
			char c = s[i];
			s[i] = s[j];
			s[j] = c;
			i++; 
			j--;
		}
		
	}
}

#region private::Tests


/*
Example 1:

Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]
Example 2:

Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
*/

[Theory]
[InlineData(new[] { 'h', 'e', 'l', 'l', 'o' }, new[] { 'o', 'l', 'l', 'e', 'h' })]
[InlineData(new[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
void TestReverseString(char[] s, char[] expected)
{
	new Solution().ReverseString(s);
	Assert.Equal(expected, s);
}

#endregion