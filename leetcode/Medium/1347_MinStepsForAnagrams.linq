<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MinSteps(string s, string t)
{
	Dictionary<char, int> counts = new Dictionary<char, int>();
	foreach(char c in s)
	{
		if (!counts.ContainsKey(c)) 
		{
			counts.Add(c, 0); 
		}
		counts[c]++; 
	}
	int diffs = 0;
	foreach(char c in t)
	{
		if (!counts.ContainsKey(c) || counts[c] < 1) 
		{
			diffs++;
		}
		else
		{
			counts[c]--; 
		}
	}
	return diffs;
	
}

/*
Example 1:

Input: s = "bab", t = "aba"
Output: 1
Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.
Example 2:

Input: s = "leetcode", t = "practice"
Output: 5
Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.
Example 3:

Input: s = "anagram", t = "mangaar"
Output: 0
Explanation: "anagram" and "mangaar" are anagrams. 
*/

[Theory]
[InlineData("bab", "aba", 1)]
[InlineData("leetcode", "practice", 5)]
[InlineData("anagram", "mangaar", 0)]
void Test(string s, string t, int expected) 
{
	int result = MinSteps(s, t);
	Assert.Equal(expected, result); 
	
}
