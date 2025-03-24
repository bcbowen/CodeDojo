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
	public bool IsAnagram(string s, string t)
	{
		if (s.Length != t.Length) return false;
		char[] cs = s.ToCharArray();
		char[] ct = t.ToCharArray();
		Array.Sort(cs); 
		Array.Sort(ct); 
		return cs.SequenceEqual(ct);
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

/*
Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false
*/

[Theory]
[InlineData("anagram", "nagaram", true)]
[InlineData("rat", "car", false)]
[InlineData("ab", "a", false)]
[InlineData("a", "ab", false)]
void AnagramTest(string s, string t, bool expected) 
{
	bool result = new Solution().IsAnagram(s, t);
	Assert.Equal(expected, result);
}

#endregion