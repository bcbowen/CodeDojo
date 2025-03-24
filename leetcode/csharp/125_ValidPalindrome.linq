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
	public bool IsPalindrome(string s)
	{
		s = s.ToUpper();
		int i = 0;
		int j = s.Length - 1;
		while (i < j)
		{
			while(i < s.Length && !char.IsLetterOrDigit(s[i])) i++; 
			while(j > 0 && !char.IsLetterOrDigit(s[j])) j--;
			if (i > j) break;
			if (s[i++] != s[j--]) return false; 
		}
		return true;
	}
}

#region private::Tests
[Theory]
[InlineData("A man, a plan, a canal: Panama", true)]
[InlineData("race a car", false)]
[InlineData(" ", true)]
[InlineData("abba", true)]
[InlineData("aba", true)]
[InlineData("..", true)]
[InlineData("0P", false)]
[InlineData("1001", true)]
[InlineData("1011", false)]
void IsPalindromeTest(string s, bool expected) 
{
	bool result = new Solution().IsPalindrome(s); 
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Example 3:
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
*/

#endregion