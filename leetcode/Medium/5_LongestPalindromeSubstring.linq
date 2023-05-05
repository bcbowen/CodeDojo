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
	public string LongestPalindrome(string s)
	{
		if (s.Length == 1) return s;
		
		int maxLen = 0; 
		int maxL = 0; 
		int maxR = 0; 
		int l = 0; 
		int r; 
		for (int i = 1; i < s.Length; i++)
		{
			r = i;
			l = i - 1;
			while (l >= 0 && r < s.Length && s[l] == s[r])
			{
				if (r - l + 1 > maxLen)
				{
					maxLen = r - l + 1;
					maxL = l; 
					maxR = r;
				}
				l--; 
				r++;
			}
			

			r = i + 1;
			l = i - 1;
			while (l >= 0 && r < s.Length && s[l] == s[r])
			{
				if (r - l + 1 > maxLen)
				{
					maxLen = r - l + 1; 
					maxL = l;
					maxR = r;
				}
				l--;
				r++;
			}


		}
		
		return s.Substring(maxL, maxR - maxL + 1); 
	}
}

/*
Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"
*/

[Theory]
[InlineData("babad", "bab")]
[InlineData("cbbd", "bb")]
[InlineData("s", "s")]
[InlineData("se", "s")]
[InlineData("ss", "ss")]
void Test(string s, string expected) 
{
	string result = new Solution().LongestPalindrome(s); 
	Assert.Equal(expected, result); 
}