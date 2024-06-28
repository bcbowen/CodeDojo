<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests(); 
}

public int NumberOfSpecialSubstrings(string s)
{
	int n = 1;
	int count = 0;
	Dictionary<char, int> charCounts = new Dictionary<char, int>();
	// handle n = 1 first
	count += s.Length;
	n++;
	while(n < s.Length)
	{
		charCounts.Clear(); 
		int l = 0; 
		charCounts.Add(s[0], 1);
		int r = 1;
		while (r <= n - 1)
		{
			if (!charCounts.ContainsKey(s[r]))
			{
				charCounts.Add(s[r], 0); 
			}
			charCounts[s[r]]++;
			r++;
		}
		if (!charCounts.Values.Any(v => v > 1)) count++; 
		while(r < s.Length - 1) 
		{
			charCounts[s[l]]--; 
			l++;
			r++;
			if (!charCounts.ContainsKey(s[r]))
			{
				charCounts.Add(s[r], 0);
			}
			charCounts[s[r]]++;
			if (!charCounts.Values.Any(v => v > 1)) count++; 
		}
		n++;
	}
	return count; 
}

/*
Example 1:
Input: s = "abcd"
Output: 10
Explanation: Since each character occurs once, every substring is a special substring. We have 4 substrings of length one, 3 of length two, 2 of length three, and 1 substring of length four. So overall there are 4 + 3 + 2 + 1 = 10 special substrings.

Example 2:
Input: s = "ooo"
Output: 3
Explanation: Any substring with a length of at least two contains a repeating character. So we have to count the number of substrings of length one, which is 3.

Example 3:
Input: s = "abab"
Output: 7
Explanation: Special substrings are as follows (sorted by their start positions):
Special substrings of length 1: "a", "b", "a", "b"
Special substrings of length 2: "ab", "ba", "ab"
And it can be shown that there are no special substrings with a length of at least three. So the answer would be 4 + 3 = 7.
*/

[Theory]
[InlineData("abcd", 10)]
[InlineData("ooo", 3)]
[InlineData("abab", 7)]
void Test(string s, int expected) 
{
	int result = NumberOfSpecialSubstrings(s); 
	Assert.Equal(expected, result); 
}
